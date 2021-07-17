using System;
using System.Data;
using System.Windows.Forms;


namespace test_Task
{
    public partial class MainForm : Form
    {
        public DataTable curRow;
        Queries q;
        public MainForm()
        {
            InitializeComponent();
            Program.mainForm = this;
            q = new Queries();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            curRow = q.getEmployees(); //заполнение dataGridView
            EmployeesList.DataSource = curRow;
            //форматирование столбцов
            EmployeesList.Columns["id"].Visible = false;
            EmployeesList.Columns["fio"].HeaderText = "ФИО";
            EmployeesList.Columns["fio"].Width = 190;
            EmployeesList.Columns["chief"].Width = 190;
            EmployeesList.Columns["chief"].HeaderText = "Начальник";
            EmployeesList.Columns["eic"].HeaderText = "Дата устройства";
            EmployeesList.Columns["role"].HeaderText = "Роль";
            EmployeesList.Columns["rate"].HeaderText = "Ставка";

            EmployeesList.CurrentCellChanged += new EventHandler(this.EmployeesList_CurrentCellChanged);
            chiefTrans();
        }
        //Метод, преобразующий ID начальника в ФИО начальника
        private void chiefTrans()
        {
            for (int i = 0; i < EmployeesList.Rows.Count; i++)
            {
                if (EmployeesList.Rows[i].Cells["chief"].Value.ToString().Length != 0)
                    EmployeesList.Rows[i].Cells["chief"].Value = q.getFio(EmployeesList.Rows[i].Cells["chief"].Value.ToString());
            }
        }
        //Переход на форму добавления записи
        private void AddB_Click(object sender, EventArgs e)
        {
            Program.addWorker = new AddWorker(true);
            Program.addWorker.Show();
        }
        //Метод получения выделенного ряда из таблицы, для переноса в форму изменения информации о записи
        public DataRow getRow()
        {
            DataTable transDT = curRow.Copy();
            return transDT.Select($"fio = '{EmployeesList.CurrentRow.Cells["fio"].Value}'")[0];
        }
        //Переход на форму изменения информации о выбранной записи
        private void ModifyB_Click(object sender, EventArgs e)
        {
            Program.addWorker = new AddWorker(false);
            Program.addWorker.Show();
        }
        //Обновление содержимого таблицы, после добавления/изменения/удаления записи
        public void UpdateTable()
        {
            curRow = q.getEmployees();
            EmployeesList.DataSource = curRow;
            chiefTrans();
        }
        //Удаление записи
        private void DeleteB_Click(object sender, EventArgs e)
        {
            string fio = EmployeesList.CurrentRow.Cells["fio"].Value.ToString();
            DialogResult dr = MessageBox.Show("Вы уверены что хотите удалить сотрудника?\nЭто действие необратимо","Удаление сотрудника",MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                switch (EmployeesList.Rows[EmployeesList.CurrentCell.RowIndex].Cells["Role"].Value.ToString())
                {
                    case "Работник":
                        {
                            q.deleteWorker("Employees", fio);
                            break;
                        }
                    case "Менеджер":
                        {
                            q.deleteWorker("Managers", fio);
                            break;
                        }
                    case "Продавец":
                        {
                            q.deleteWorker("Salesmen", fio);
                            break;
                        }
                }
                Program.mainForm.UpdateTable();
            }
        }
        //Вызов формы просмотра подчиненных выбранного сотрудника
        private void checkSubordB_Click(object sender, EventArgs e)
        {
            string table;
            switch (EmployeesList.CurrentRow.Cells["role"].Value.ToString())
            {
                case "Работник": table = "Employees"; break;
                case "Менеджер": table = "Managers"; break;
                case "Продавец": table = "Salesmen"; break;
                default: table = null; break;
            }

            Subordinates newf = new Subordinates(false, EmployeesList.CurrentRow.Cells["fio"].Value.ToString(), table);
            newf.Show();
        }
        //Проверка роли выбранного сотрудника, если это "Работник", то кнопка просмотра починенных становиться недоступной
        private void EmployeesList_CurrentCellChanged(object sender, EventArgs e)
        {
            if (EmployeesList.Rows.Count != 0 && EmployeesList.CurrentRow != null)
            {
                if (EmployeesList.CurrentRow.Cells["role"].Value.Equals("Работник")) checkSubordB.Enabled = false;
                else checkSubordB.Enabled = true;
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        //Переход на форму расчета ЗП для выбранного сотрудника
        private void incomeB_Click(object sender, EventArgs e)
        {
            string id;
            switch (EmployeesList.CurrentRow.Cells["role"].Value.ToString())
            {
                case "Работник": id = $"E{EmployeesList.CurrentRow.Cells["id"].Value}"; break;
                case "Менеджер": id = $"M{EmployeesList.CurrentRow.Cells["id"].Value}"; break;
                case "Продавец": id = $"S{EmployeesList.CurrentRow.Cells["id"].Value}"; break;
                default: id = null; break;
            }
            Program.incomeForm = new IncomeForm(id);
            Program.incomeForm.Show();
        }
    }
}
