import os

def prettyprintdividors(table):
    tmp = f'{table}'
    left = 60 - round((len(tmp) / 2))
    right = 60 - round((len(tmp) / 2))
    if (len(tmp) % 2 == 1):
        right += 1
    round(left)
    print("//" + left*"-" + tmp + right*"-")
    return("//" + left*"-" + tmp + right*"-")

def generateProps(table):
    store = []
    for row in table:
        store.append(f'{row}: {{{row}}}')
    return ", ".join(store)

def getColumnID(table):
    for row in table:
        if row.strip().startswith("ID"):
            return row.strip()

def removecomma(word):
    word.removeprefix(",")
    word.removesuffix(",")
    return word

sqlfile = open("tables.sql")
folder = os.path.join(os.getcwd(), "Models")

def printToFile(string, classname):
    writing = open(os.path.join(folder, f'{classname}.cs'), 'w')
    writing.write(string)
    writing.close()


variables = {}
inTable = False
for line in sqlfile.readlines():
    text = line.strip()
    line = text.split(" ")
    if text.endswith("("):
        tableName = line[2]
        inTable = True
        continue
    if text.endswith(")"):
        inTable = False
        continue
    if inTable:
        if text.startswith("constraint"):
            continue
        variableName = removecomma(line[0])
        variableType = removecomma(line[1])
        if (tableName not in variables):
            variables[tableName] = {}
        variables[tableName][variableName] = variableType

modelstring = """\
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quizkey.Models
{{
    {}
    public class {}
    {{
        {}
    }}
}}
"""


def model(table):
    printToFile(modelstring.format(
        prettyprintdividors(table),
        table,
        generateProps(variables[table])
    ), table)

for table in variables:
    #model(table) # generates files for model
    prettyprintdividors(table)
    #print(f'private static {table} Get{table}FromDataRow(DataRow row)\n{{')
    #print("        " + generateProps(variables[table]))
    #print(f'private static List<{table}> {table.lower()}Cache = null;')
#    print(f'''\
#if ({table.lower()}Cache.Contains(new {table} {{ {getColumnID(variables[table])} = {getColumnID(variables[table])} }}))
#    return {table.lower()}Cache.Find(x => x.{getColumnID(variables[table])} == {getColumnID(variables[table])});''')
    print(f'\npublic override string ToString() =>\n\t\t$"{generateProps(variables[table])}";\n')
