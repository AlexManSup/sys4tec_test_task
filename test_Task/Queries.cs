using System.Data;
using System.Data.SQLite;

namespace test_Task
{
    class Queries
    {
        int amount;
        static string connectionString = @"Data Source=employees.db;Version=3;";
        SQLiteConnection conn = new SQLiteConnection(connectionString);
        DataTable bufferTable;
        SQLiteDataAdapter dataAdapter;
        SQLiteCommand command;
        //Запрос для авторизации
        public bool auth(string login, string pass)
        {
            bufferTable = new DataTable();
            conn.Open();
            dataAdapter = new SQLiteDataAdapter($@"SELECT [ID] FROM [Login] WHERE [Login] = '{login}' AND [Password] = '{pass}'", conn);
            conn.Close();
            bufferTable.Clear();
            dataAdapter.Fill(bufferTable);

            if (bufferTable.Rows.Count == 1) return true;
            else return false;
        }
        //Получение всех сотрудников
        public DataTable getEmployees()
        {
            amount = 1;
            bufferTable = new DataTable();
            conn.Open();
            dataAdapter = new SQLiteDataAdapter(@"SELECT * FROM [Managers]", conn);
            
            dataAdapter.SelectCommand.ExecuteNonQuery();
            bufferTable.Clear();
            bufferTable.Columns.Add("Role");

            dataAdapter.Fill(bufferTable);
            bufferTable.Columns["Role"].SetOrdinal(2);
            roleAssign(1);

            dataAdapter.SelectCommand.CommandText = @"SELECT * FROM [Salesmen]";
            dataAdapter.Fill(bufferTable);
            roleAssign(2);

            dataAdapter.SelectCommand.CommandText = @"SELECT * FROM [Employees]";
            dataAdapter.Fill(bufferTable);
            roleAssign(3);

            conn.Close();
            return bufferTable;
        }
        //Удаление сотрудника
        public void deleteWorker(string table, string fio)
        {
            string login = employeeID(fio, table);
            conn.Open();
            command = new SQLiteCommand($"DELETE FROM [Login] WHERE [Login] = '{login}'", conn);
            command.ExecuteNonQuery();
            command.CommandText = $"UPDATE [Salesmen] SET [chief] = '' WHERE [chief] = '{login}'";
            command.ExecuteNonQuery();
            command.CommandText = $"UPDATE [Managers] SET [chief] = '' WHERE [chief] = '{login}'";
            command.ExecuteNonQuery();
            command.CommandText = $"UPDATE [Employees] SET [chief] = '' WHERE [chief] = '{login}'";
            command.ExecuteNonQuery();
            command.CommandText = $"DELETE FROM [{table}] WHERE [fio] = '{fio}'";
            command.ExecuteNonQuery();
            conn.Close();
        }

        //Полчение списка подчиненных
        public DataTable getSubords(string chief, string chiefTable)
        {
            amount = 1;
            string id = employeeID(chief, chiefTable);
            bufferTable = new DataTable();

            conn.Open();
            dataAdapter = new SQLiteDataAdapter($@"SELECT [fio],[eic],[chief],[rate] FROM [Managers] WHERE [chief] = '{id}' ", conn);
            bufferTable.Clear();
            bufferTable.Columns.Add("Role");

            dataAdapter.Fill(bufferTable);
            bufferTable.Columns["Role"].SetOrdinal(1);
            roleAssign(1);

            dataAdapter.SelectCommand.CommandText = $@"SELECT [fio],[eic],[chief],[rate] FROM [Salesmen] WHERE [chief] = '{id}'";
            dataAdapter.Fill(bufferTable);
            roleAssign(2);

            dataAdapter.SelectCommand.CommandText = $@"SELECT [fio],[eic],[chief],[rate] FROM [Employees] WHERE [chief] = '{id}'";
            dataAdapter.Fill(bufferTable);
            roleAssign(3);

            return bufferTable;
        }
        //Получение списка сотрудников, которые могут быть начальниками (Менеджеров и Продавцов)

        public DataTable getChiefEmployees(bool mode, string chief, string chiefTable)
        {
            amount = 1;
            bufferTable = new DataTable();
            if (!mode)
            {
                string id = employeeID(chief, chiefTable);

                conn.Open();
                dataAdapter = new SQLiteDataAdapter($@"SELECT [fio] FROM [Managers] WHERE [chief] <> '{id}' AND [fio]<>'{chief}'", conn);
                dataAdapter.SelectCommand.ExecuteNonQuery();
                bufferTable.Clear();
                bufferTable.Columns.Add("Role");

                dataAdapter.Fill(bufferTable);
                bufferTable.Columns["Role"].SetOrdinal(1);
                roleAssign(1);

                dataAdapter.SelectCommand.CommandText = $@"SELECT [fio] FROM [Salesmen] WHERE [chief] <> '{id}' AND [fio]<>'{chief}'";
                conn.Close();
                dataAdapter.Fill(bufferTable);
                roleAssign(2);

                return bufferTable;
            }
            else
            {
                conn.Open();
                dataAdapter = new SQLiteDataAdapter($@"SELECT [fio] FROM [Managers]", conn);
                dataAdapter.SelectCommand.ExecuteNonQuery();
                bufferTable.Clear();
                bufferTable.Columns.Add("Role");

                dataAdapter.Fill(bufferTable);
                bufferTable.Columns["Role"].SetOrdinal(1);
                roleAssign(1);

                dataAdapter.SelectCommand.CommandText = $@"SELECT [fio] FROM [Salesmen]";
                conn.Close();
                dataAdapter.Fill(bufferTable);
                roleAssign(2);

                return bufferTable;
            }
            
        }
        //Создание логина и пароля при добавлении нового сотрудника, и запись в таблицу логинов/паролей
        public void addLogPass(string fio, string eic, string table)
        {
            string login = employeeID(fio, table);
            string pass = eic.Substring(6, eic.Length-6);

            conn.Open();
            command = new SQLiteCommand($"INSERT INTO [Login] ([ID],[Login],[Password]) VALUES (NULL,'{login}','{pass}')", conn);
            command.ExecuteNonQuery();
            conn.Close();
        }
        //Метод добавления столбца роли сотрудника в список сотрудников
        private void roleAssign(int step)
        {
            switch (step)
            {
                case 1:
                    {
                        for (int i = 0; i < bufferTable.Rows.Count; i++)
                        {
                            bufferTable.Rows[i]["role"] = "Менеджер";
                            amount += 1;
                        }
                        break;
                    }
                case 2:
                    {
                        for (int i = amount - 1; i < bufferTable.Rows.Count; i++)
                        {
                            bufferTable.Rows[i]["role"] = "Продавец";
                            amount += 1;
                        }
                        break;
                    }
                case 3:
                    {
                        for (int i = amount - 1; i < bufferTable.Rows.Count; i++)
                        {
                            bufferTable.Rows[i]["role"] = "Работник";
                        }
                        break;
                    }
            }
        }
        //Запрос обновления записи в БД
        public void updateRecord(string fio, string role, string chief, string chiefTable, string rate)
        {
            string table;
            string id;

            switch (role[0])
            {
                case 'Р': table = "Employees"; break;
                case 'М': table = "Managers"; break;
                case 'П': table = "Salesmen"; break;
                default: table = null; break;
            }
            if (chief != " ") id = employeeID(chief, chiefTable);
            else id = null;

            conn.Open();
            if (table == "Employees") command = new SQLiteCommand($"UPDATE [{table}]SET [chief]= '{id}',[rate]= '{rate}' WHERE [fio] = '{fio}'", conn);
            else command = new SQLiteCommand($"UPDATE [{table}]SET [chief]= '{id}',[rate]= '{rate}' WHERE [fio] = '{fio}'", conn);
            command.ExecuteNonQuery();
            conn.Close();
        }
        //Получение ФИО сотрудника 
        public string getFio(string id)
        {
            string table;
            bufferTable = new DataTable();

            if (id.Length != 0)
            {
                switch (id[0])
                {
                    case 'E': table = "Employees"; break;
                    case 'M': table = "Managers"; break;
                    case 'S': table = "Salesmen"; break;
                    default: return null;
                }

                conn.Open();
                dataAdapter = new SQLiteDataAdapter($"SELECT [fio] FROM [{table}] WHERE [id] = '{id.Substring(1)}'", conn);
                bufferTable.Clear();
                dataAdapter.Fill(bufferTable);
                conn.Close();

                return bufferTable.Rows[0][0].ToString();
            }
            else return " ";
        }
        //Составление ID сотрудника из названия таблицы и ID сотрудника
        public string employeeID(string fio, string table)
        {
            string id;
            bufferTable = new DataTable();

            conn.Open();
            dataAdapter = new SQLiteDataAdapter($@"SELECT [id] FROM [{table}] WHERE [fio] = '{fio}'", conn);
            conn.Close();

            bufferTable.Clear();
            dataAdapter.Fill(bufferTable);
            id = table[0] + bufferTable.Rows[0][0].ToString();

            return id;
        }
    }
}
