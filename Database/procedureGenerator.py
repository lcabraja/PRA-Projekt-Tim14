def prettyprintdividors(crud, table):
    tmp = f'proc_{crud}_{table}'
    left = 60 - round((len(tmp) / 2))
    right = 60 - round((len(tmp) / 2))
    if (len(tmp) % 2 == 1):
        right += 1
    round(left)
    print(left*"-" + tmp + right*"-")

def generateUpdateString(table):
    store = []
    for row in table:
        if (row.startswith("ID")):
            continue
        store.append(f'{row} = @{row}')
    return ", ".join(store)

def generateVariables(table):
    store = []
    for row in table:
        store.append(f'@{row} {table[row]}')
    store[0] += " OUTPUT"
    local = ",\n    ".join(store)
    local = local.replace(",,", ",")
    local = local.removesuffix(",")
    return local

def generateUpdateVariables(table):
    store = []
    for row in table:
        store.append(f'@{row} {table[row]}')
    return ",\n    ".join(store)

def generateIdVariable(table):
    for row in table:
        if row.strip().startswith("ID"):
            return f'{row} {table[row]}'

def generateRowHeaders(table):
    keys = list(table.keys())
    for key in keys:
        if key.strip().startswith("ID"):
            keys.remove(key)
    return "@" + f', @'.join(keys)

def generateUpdateHeaders(table):
    store = []
    for row in table:
        store.append(f'@{row} {table[row]}')
    return ', '.join(store)


def getColumnID(table):
    for row in table:
        if row.strip().startswith("ID"):
            return row.strip()

def removecomma(word):
    word.removeprefix(",")
    word.removesuffix(",")
    return word

sqlfile = open("tables.sql")

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

create = """\
IF OBJECT_ID('proc_create_{}') IS NOT NULL
BEGIN 
    DROP PROCEDURE proc_create_{} 
END
GO
CREATE PROCEDURE proc_create_{}
    {}
AS
BEGIN
INSERT INTO {}
    VALUES ({})
 
SET @{} = SCOPE_IDENTITY()
END
GO"""

read = """\
IF OBJECT_ID('proc_select_{}') IS NOT NULL
BEGIN
    DROP PROCEDURE proc_select_{}
END
GO
CREATE PROCEDURE proc_select_{}
    @{}
AS
BEGIN
    SELECT * FROM {} WHERE {} = @{}
END
GO
"""

read_multiple = """\
IF OBJECT_ID('proc_select_multiple_{}') IS NOT NULL
BEGIN
    DROP PROCEDURE proc_select_multiple_{}
END
GO
CREATE PROCEDURE proc_select_multiple_{}
AS
BEGIN
    SELECT * FROM {}
END
GO
"""

update = """\
IF OBJECT_ID('proc_update_{}') IS NOT NULL
BEGIN
    DROP PROCEDURE proc_update_{}
END
GO
CREATE PROCEDURE proc_update_{}
    {}
AS
BEGIN
    UPDATE {} SET {} WHERE {} = @{} 
END
GO
"""

delete = """\
IF OBJECT_ID('proc_delete_{}') IS NOT NULL
BEGIN
    DROP PROCEDURE proc_delete_{}
END
GO
CREATE PROCEDURE proc_delete_{}
    @{}
AS 
BEGIN 
    DELETE FROM {} WHERE {} = @{}
END
GO
"""

def crud_create(table):
    print(create.format(
        table,
        table,
        table,
        generateVariables(variables[table]),
        table,
        generateRowHeaders(variables[table]),
        getColumnID(variables[table])
    ))
def crud_read(table):
    print(read.format(
        table, 
        table, 
        table,
        generateIdVariable(variables[table]),
        table,
        getColumnID(variables[table]),
        getColumnID(variables[table])
    ))
def crud_read_multiple(table):
    print(read_multiple.format(
        table, 
        table, 
        table,
        table,
    ))
def crud_update(table):
    print(update.format(
        table,
        table,
        table,
        generateUpdateVariables(variables[table]),
        table,
        generateUpdateString(variables[table]),
        getColumnID(variables[table]),
        getColumnID(variables[table])
    ))
def crud_delete(table):
    print(delete.format(
        table,
        table,
        table,
        generateIdVariable(variables[table]),
        table,
        getColumnID(variables[table]),
        getColumnID(variables[table])
    ))

print("USE Quizkey\nGO")
for table in variables:
    prettyprintdividors("create", table)
    crud_create(table)
    prettyprintdividors("select", table)
    crud_read(table)
    prettyprintdividors("select_multiple", table)
    crud_read_multiple(table)
    prettyprintdividors("update", table)
    crud_update(table)
    prettyprintdividors("delete", table)
    crud_delete(table)