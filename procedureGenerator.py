from os import remove


def generateVariables(table):
    store = []
    for row in table:
        store.append(f'@{row} {table[row]}')
    store[0] += " OUTPUT"
    local = ",\n\t".join(store)
    local = local.replace(",,", ",")
    local = local.removesuffix(",")
    return local


def generateRowHeaders(table, prefix="", skipID=True):
    keys = list(table.keys())
    if skipID == True:
        for key in keys:
            if key.strip().startswith("ID"):
                keys.remove(key)
    return prefix + f',\n\t{prefix}'.join(keys)


def getColumnID(table):
    for row in table:
        if row.strip().startswith("ID"):
            return row.strip()

def removecomma(word):
    word.removeprefix(",")
    word.removesuffix(",")
    return word

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
        variableName = removecomma(line[0])
        variableType = removecomma(line[1])
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
INSERT INTO {}  (
    {})
    VALUES (
    {})
 
SET @{} = SCOPE_IDENTITY()
END"""

for table in variables:
    print(50*"-" + f'proc_create_{table}' + 50*"-")
    print(output.format(
        table,
        table,
        table,
        generateVariables(variables[table]),
        table,
        generateRowHeaders(variables[table], skipID=True),
        generateRowHeaders(variables[table], "@", True),
        getColumnID(variables[table])
    ))
