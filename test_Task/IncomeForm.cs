using System;
using System.Data;
using System.Windows.Forms;

namespace test_Task
{
    public partial class IncomeForm : Form
    {
        string id;
        string[] ids;
        Queries q;
        DataTable allWorkers;
        AppContext context;
        Employee emp;
        Manager man;
        Salesman sal;
        public IncomeForm(string login)
        {
            InitializeComponent();
            id = login;
            context = new AppContext();
        }

        private void IncomeForm_Load(object sender, EventArgs e)
        {
            if(id == "admin")
            {
                this.Text = "Расчет зарплаты для всех сотдрудников";
                q = new Queries();
                allWorkers = q.getEmployees();
                ids = new string[allWorkers.Rows.Count];
                for (int i = 0; i < ids.Length; i++)
                {
                    //Заполнение массива ID всех сотрудников
                    switch (allWorkers.Rows[i]["role"].ToString()[0])
                    {
                        case 'Р': ids[i] = "E" + allWorkers.Rows[i]["id"]; break;
                        case 'М': ids[i] = "M" + allWorkers.Rows[i]["id"]; break;
                        case 'П': ids[i] = "S" + allWorkers.Rows[i]["id"]; break;
                        default: ids[i] = null; break;
                    }
                }
            }
            else
            {
                switch (id[0])//Первый символ ID определяет в какой таблице искать сотрудника
                {
                    case 'E':
                        {
                            emp = context.Employees.Find(Convert.ToInt32(id.Substring(1)));//Поиск сотрудника в определенной таблице с указанным id
                            datePicker.MinDate = DateTime.Parse(emp.Eic);//Установка минимальной даты для календаря в соответствии с датой поступления на работу
                            this.Text = $"Расчет зарплаты для {emp.Fio}";
                            break;
                        }
                    case 'M':
                        {
                            man = context.Managers.Find(Convert.ToInt32(id.Substring(1)));
                            datePicker.MinDate = DateTime.Parse(man.Eic);
                            this.Text = $"Расчет зарплаты для {man.Fio}";
                            break;
                        }
                    case 'S':
                        {
                            sal = context.Salesmen.Find(Convert.ToInt32(id.Substring(1)));
                            datePicker.MinDate = DateTime.Parse(sal.Eic);
                            this.Text = $"Расчет зарплаты для {sal.Fio}";
                            break;
                        }
                }
            }
        }

        private void IncomeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
        //Расчет ЗП на актульную дату
        private void incomeToday_Click(object sender, EventArgs e)
        {
            //Расчет ЗП для всех сотрудников
            if (id == "admin")
            {
                double income = 0;
                for (int i = 0; i < ids.Length; i++)
                {
                    switch (ids[i][0])//Первый символ ID определяет в какой таблице искать сотрудника и по какому методу производить расчет
                    {
                        case 'E':
                            {
                                emp = context.Employees.Find(Convert.ToInt32(ids[i].Substring(1)));
                                income += emp.incomeOnDate(DateTime.Today);
                                break;
                            }
                        case 'M':
                            {
                                man = context.Managers.Find(Convert.ToInt32(ids[i].Substring(1)));
                                income += man.incomeOnDate(DateTime.Today);
                                break;
                            }
                        case 'S':
                            {
                                sal = context.Salesmen.Find(Convert.ToInt32(ids[i].Substring(1)));
                                income += sal.incomeOnDate(DateTime.Today);
                                break;
                            }
                    }
                }
                MessageBox.Show($"Зарплата всех сотрудников на {DateTime.Today.ToString("d")} составляет {income.ToString("F")} рублей", $"Зарплата всех сотрудников", MessageBoxButtons.OK);
            }
            //Расчет для определенного сотрудника
            else
            {
                switch (id[0])//Первый символ ID определяет для какого типа сотрудников производить расчет
                {
                    case 'E':
                        {
                            string inc = emp.incomeOnDate(DateTime.Today).ToString("F");
                            MessageBox.Show($"Зарплата на {DateTime.Today.ToString("d")} составляет {inc} рублей", $"Зарплата сотрудника {emp.Fio}", MessageBoxButtons.OK);
                            break;
                        }
                    case 'M':
                        {
                            string inc = man.incomeOnDate(DateTime.Today).ToString("F");
                            MessageBox.Show($"Зарплата на {DateTime.Today.ToString("d")} составляет {inc} рублей", $"Зарплата для сотрудника {man.Fio}", MessageBoxButtons.OK);
                            break;
                        }
                    case 'S':
                        {
                            string inc = sal.incomeOnDate(DateTime.Today).ToString("F");
                            MessageBox.Show($"Зарплата на {DateTime.Today.ToString("d")} составляет {inc} рублей", $"Зарплата для сотрудника {sal.Fio}", MessageBoxButtons.OK);
                            break;
                        }
                }
            }
        }
        //Расчет ЗП на произвольную дату
        private void incomeDate_Click(object sender, EventArgs e)
        {
            //Расчет ЗП для всех сотрудников
            if (id == "admin")
            {
                double income = 0;
                for (int i = 0; i < ids.Length; i++)
                {
                    switch (ids[i][0])//Первый символ ID определяет в какой таблице искать сотрудника и по какому методу производить расчет
                    {
                        case 'E':
                            {
                                emp = context.Employees.Find(Convert.ToInt32(ids[i].Substring(1)));
                                income += emp.incomeOnDate(datePicker.Value);
                                break;
                            }
                        case 'M':
                            {
                                man = context.Managers.Find(Convert.ToInt32(ids[i].Substring(1)));
                                income += man.incomeOnDate(datePicker.Value);
                                break;
                            }
                        case 'S':
                            {
                                sal = context.Salesmen.Find(Convert.ToInt32(ids[i].Substring(1)));
                                income += sal.incomeOnDate(datePicker.Value);
                                break;
                            }
                    }
                }
                MessageBox.Show($"Зарплата всех сотрудников на {datePicker.Value.ToString("d")} составляет {income.ToString("F")} рублей", $"Зарплата всех сотрудников", MessageBoxButtons.OK);
            }
            //Расчет для определенного сотрудника
            else
            {
                switch (id[0]) //Первый символ ID определяет в какой таблице искать сотрудника
                {
                    case 'E':
                        {
                            string inc = emp.incomeOnDate(datePicker.Value).ToString("F");
                            MessageBox.Show($"Зарплата на {datePicker.Value.ToString("d")} составляет {inc} рублей", $"Зарплата сотрудника {emp.Fio}", MessageBoxButtons.OK);
                            break;
                        }
                    case 'M':
                        {
                            string inc = man.incomeOnDate(datePicker.Value).ToString("F");
                            MessageBox.Show($"Зарплата на {datePicker.Value.ToString("d")} составляет {inc} рублей", $"Зарплата для сотрудника {man.Fio}", MessageBoxButtons.OK);
                            break;
                        }
                    case 'S':
                        {
                            string inc = sal.incomeOnDate(datePicker.Value).ToString("F");
                            MessageBox.Show($"Зарплата на {datePicker.Value.ToString("d")} составляет {inc} рублей", $"Зарплата для сотрудника {sal.Fio}", MessageBoxButtons.OK);
                            break;
                        }
                }
            }
        }
    }
}
