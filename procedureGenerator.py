import os

def generateVariables(table):

    store = []
    for row in table:
        store.append(f'@{row} {table[row]}')
    store[0] += " OUTPUT"
    return ",\n\t".join(store)

def generateRowHeaders(table, prefix = ""):
    return prefix +f',\n\t{prefix}'.join(table.keys()) 

def getColumnID(table):
    for row in table:
        if row.strip().startswith("ID"):
            return row.strip()

sqlfile = open("database.sql")

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
        variableName = line[0]
        variableType = line[1]
        if (tableName not in variables):
            variables[tableName] = {}
        variables[tableName][variableName] = variableType

output = """\
IF OBJECT_ID('proc_create_{}') IS NOT NULL
BEGIN 
DROP PROC proc_create_{} 
END
GO
CREATE PROCEDURE proc_create_{}
	{}
AS
BEGIN
INSERT INTO Customer  (
    {})
    VALUES (
    {})
 
SET @{} = SCOPE_IDENTITY()
END"""

for table in variables:
    print(50*"-" + f'proc_create_{table}' +  50*"-")
    print(output.format(
        table, table, table, generateVariables(variables[table]), generateRowHeaders(variables[table]), generateRowHeaders(variables[table], "@"), getColumnID(variables[table])
    ))
