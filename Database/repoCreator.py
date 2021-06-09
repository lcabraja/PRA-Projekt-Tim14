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

repoGetOne = """\
public static List<{}> Get{}(int {})
    {
        List<{}> collection = new List<{}>();
        DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_{}}", {}, {}, {}, {}, {});
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            collection.Add(Get{}FromDataRow(row));
        }
        return collection;
    }
"""

repoGetOne = """\
public static List<{}> Get{}(int {})
    {
        List<{}> collection = new List<{}>();
        DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_{}}", {});
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            collection.Add(Get{}FromDataRow(row));
        }
        return collection;
    }
"""

repoGetMultiple = """\
public static List<{}> GetMultiple{}()
    {
        List<{}> collection = new List<{}>();
        DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_multiple_{}}");
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            collection.Add(Get{}FromDataRow(row));
        }
        return collection;
    }
"""

repoGetMultiple = """\
public static List<{}> GetMultiple{}()
    {
        List<{}> collection = new List<{}>();
        DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_multiple_{}}");
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            collection.Add(Get{}FromDataRow(row));
        }
        return collection;
    }
"""

def model(table):
    print(model.format(
        table,
        generateProps(variables[table])
    ))

for table in variables:
    prettyprintdividors(table)
    model(table)