def prettyprintdividors(crud, table):
    tmp = f'{table}'
    left = 60 - round((len(tmp) / 2))
    right = 60 - round((len(tmp) / 2))
    if (len(tmp) % 2 == 1):
        right += 1
    round(left)
    print("//" + left*"-" + tmp + right*"-")

def generateProps(table):
    store = []
    for row in table:
        vartype = ""
        if table[row] == "int":
            vartype = "int"
        elif table[row].startswith("datetime"):
            vartype = "DateTime"
        else:
            vartype = "string"
        store.append(f'{vartype} {row}')
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

model = """\
{
    public class {}
    {
        public {} { get; set; }
        public {} { get; set; }
        public {} { get; set; }
        public {} { get; set; }
        public {} { get; set; }
    }
}"""

def model(table):
    print(model.format(
        table,
        generateProps(variables[table])
    ))

for table in variables:
    prettyprintdividors(table)
    model(table)