using System;
using System.Windows.Forms;

namespace test_Task
{

    public partial class AddWorker : Form
    {
        Queries q;
        AppContext context;
        bool emp;
        public string chiefTable;
        public AddWorker(bool empty)
        {
            InitializeComponent();
            q = new Queries();
            context = new AppContext();
            emp = empty;
        }

        private void AddWorker_Load(object sender, EventArgs e)
        {
            Worker.AllowUserToAddRows = false;
            //Добавление пустой строки, в случае если будет производится добавление новго сотрудника
            if (emp) 
            {
                Worker.Rows.Add();
                Worker.Columns["id"].Visible = false;
                Worker.Columns["fio"].Width = 190;
                Worker.Columns["chief"].Width = 190;
                Worker.Rows[0].Cells["eic"].Value = DateTime.Today;
                Worker.Rows[0].Cells["chief"].Value = "Посмотреть";
                this.Text = "Добавить сотрудника";
            }
            //Перенос информации о выбранном сотруднике, если будет производится изменение данных о существующем работнике
            else
            {
                Worker.Rows.Add(Program.mainForm.getRow().ItemArray);
                Worker.Columns["id"].Visible = false;
                Worker.Columns["fio"].Width = 190;
                Worker.Columns["chief"].Width = 190;
                Worker.Columns["fio"].ReadOnly = true; 
                Worker.Columns["role"].ReadOnly = true;
                if (Worker.Rows[0].Cells["chief"].Value.ToString() == "") Worker.Rows[0].Cells["chief"].Value = "Посмотреть";
                Worker.Columns["eic"].ReadOnly = true;
                this.Text = "Изменение информации о сотруднике";
            } 
        }

        private void CancelB_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void ConfirmB_Click(object sender, EventArgs e)
        {
            //Добавление записи о сотрудники
            if (emp)
            {
                if (allOk())
                {
                    //Сбор информации с полей dataGridView
                    string fio = Worker.Rows[0].Cells["fio"].Value.ToString();
                    string eic;
                    // Получение даты и проверка допустимых значений
                    if (DateTime.Parse(Worker.Rows[0].Cells["eic"].Value.ToString()) >= new DateTime(1995, 1, 1) &&
                        DateTime.Parse(Worker.Rows[0].Cells["eic"].Value.ToString()) <= DateTime.Today) 
                        eic = DateTime.Parse(Worker.Rows[0].Cells["eic"].Value.ToString()).ToString("d");
                    else
                    {
                        MessageBox.Show($"Введите дату позже 01.01.1995 и не позднее {DateTime.Today.ToString("d")}", "Некорректная дата", MessageBoxButtons.OK);
                        return;
                    }

                    string chief = Worker.Rows[0].Cells["chief"].Value == null ? " " : Worker.Rows[0].Cells["chief"].Value.ToString();
                    string rate = Worker.Rows[0].Cells["rate"].Value.ToString().Replace('_', ' ').Trim();
                    //Определение в какую таблицу БД добавлять запись
                    switch (Worker.Rows[0].Cells["role"].Value.ToString())
                    {
                        case "Работник":
                            {
                                context.Employees.Add(new Employee(fio, eic, chief, Convert.ToInt32(rate)));
                                context.SaveChanges();
                                q.addLogPass(fio, eic, "Employees");
                                break;
                            }
                        case "Менеджер":
                            {
                                context.Managers.Add(new Manager(fio, eic, chief, Convert.ToInt32(rate)));
                                context.SaveChanges();
                                q.addLogPass(fio, eic, "Managers");
                                break;
                            }
                        case "Продавец":
                            {
                                context.Salesmen.Add(new Salesman(fio, eic, chief, Convert.ToInt32(rate)));
                                context.SaveChanges();
                                q.addLogPass(fio, eic, "Salesmen");
                                break;
                            }
                    }

                    Program.mainForm.UpdateTable();
                    Close();
                }
            }
            //Обновление записи 
            else
            {
                string fio = Worker.Rows[0].Cells["fio"].Value.ToString();
                string role = Worker.Rows[0].Cells["role"].Value.ToString();
                string chief = Worker.Rows[0].Cells["chief"].Value == null ? " " : Worker.Rows[0].Cells["chief"].Value.ToString();
                string rate = Worker.Rows[0].Cells["rate"].Value.ToString().Replace('_', ' ').Trim();
                q.updateRecord(fio, role, chief, chiefTable, rate);
                Program.mainForm.UpdateTable();
                Close();
            }
        }
        //Проверка заполненности обязательных полей
        private bool allOk()
        {
            if (Worker.Rows[0].Cells["fio"].Value != null &&
                Worker.Rows[0].Cells["role"].Value != null &&
                Worker.Rows[0].Cells["eic"].Value != null &&
                Worker.Rows[0].Cells["rate"].Value != null) return true;
            else
            {
                MessageBox.Show("Одно из полей, обязательных к заполнению пустое");
                return false;
            }
        }
        //Переход на форму выбора начальника
        private void Worker_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                string person;
                string table;
                //Проверка заполненности полей ФИО и Роль для передачи их на форму выбора начальника
                if (Worker.CurrentRow.Cells["fio"].Value != null && Worker.CurrentRow.Cells["role"].Value != null)
                {
                    person = Worker.CurrentRow.Cells["fio"].Value.ToString();
                    table = Worker.CurrentRow.Cells["role"].Value.ToString();
                    if (e.ColumnIndex == 4)
                    {
                        Subordinates newf = new Subordinates(true, emp, person, table);
                        newf.Show();
                    }
                }
                else MessageBox.Show("Сначала заполните поля ФИО и Роль!");
            }
            
        }

        private void Worker_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
        }
    }
}
