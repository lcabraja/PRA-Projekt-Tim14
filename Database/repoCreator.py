def prettyprintdividors(table):
    tmp = f'{table}'
    left = 60 - round((len(tmp) / 2))
    right = 60 - round((len(tmp) / 2))
    if (len(tmp) % 2 == 1):
        right += 1
    round(left)
    print("//" + left*"-" + tmp + right*"-")

#{table.lower()}.{getColumnID(table)}, {table.lower()}.Username, {table.lower()}.PasswordHash, {table.lower()}.Email
def generateProps(title, table, skip):
    lower = title.lower()
    store = []
    for row in table:
        if skip and row.startswith("ID"):
            continue
        store.append(f'{lower}.{row}')
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

for table in variables:
    prettyprintdividors(table)
    print(f'''
public static int Create{table}({table} {table.lower()}) =>
    (int)SqlHelper.ExecuteScalar(cs, "proc_create_{table}", {generateProps(table, variables[table], True)});

public static {table} Get{table}(int {getColumnID(table)})
{{
    List<{table}> collection = new List<{table}>();
    DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_{table}", {getColumnID(table)});
    return Get{table}FromDataRow(ds.Tables[0].Rows[0]);
}}

public static List<{table}> GetMultiple{table}()
{{
    List<{table}> collection = new List<{table}>();
    DataSet ds = SqlHelper.ExecuteDataset(cs, "proc_select_multiple_{table}");
    foreach (DataRow row in ds.Tables[0].Rows)
    {{
        collection.Add(Get{table}FromDataRow(row));
    }}
    return collection;
}}

public static void Update{table}({table} {table.lower()})
{{
    SqlHelper.ExecuteDataset(cs, "proc_update_{table}", {generateProps(table, variables[table], False)});
}}

public static void Delete{table}(int {getColumnID(table)})
{{
    SqlHelper.ExecuteDataset(cs, "proc_delete_{table}", {getColumnID(table)});
}}
''')
