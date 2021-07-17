using System;
using System.Windows.Forms;

namespace test_Task
{
    public partial class Subordinates : Form
    {
        string p;//ФИО сотрудника
        bool m; //Переменная определяющая режим работы (просмотр списка возможных начальников или просмотр подчиненных сотрудника)
        string t;//Таблица сотрудника
        bool em;//Переменнная определяющая вывод списка начальников (все сотрудники в случае добавления нового сотрудника или только допустимые начальники в случае изменения записи)
        Queries q;
        public Subordinates(bool mode, string person, string table)
        {
            InitializeComponent();
            q = new Queries();
            m = mode;
            p = person;
            t = table;
        }
        public Subordinates(bool mode, bool emp, string person, string table)
        {
            InitializeComponent();
            q = new Queries();
            m = mode;
            p = person;
            t = table;
            em = emp;
        }

        private void Subordinates_Load(object sender, EventArgs e)
        {
            //Вывод списка возможных начальников
            if (m)
            {
                switch (t)
                {
                    case "Работник": t = "Employees"; break;
                    case "Менеджер": t = "Managers"; break;
                    case "Продавец": t = "Salesmen"; break;
                    default: t = null; break;
                }
                subord.DataSource = q.getChiefEmployees(em,p, t); //Получение списка возможных начальников
                this.Text = "Выберите начальника";
                if(!em)subord.Columns["id"].Visible = false;
                //Форматирование формы и столбцов таблицы
                subord.Columns["fio"].HeaderText = "ФИО";
                subord.Columns["role"].HeaderText = "Роль";
            }
            //Вывод списка подчиненных выбранного сотрудника
            else 
            {
                subord.DataSource = q.getSubords(p,t);//Получение списка подчиненных сотрудника
                //Форматирование формы и столбцов таблицы
                this.Text = $"Подчиненные сотрудника {p}";
                subord.Columns["fio"].HeaderText = "ФИО";
                subord.Columns["eic"].HeaderText = "Дата устройства";
                subord.Columns["role"].HeaderText = "Роль";
                subord.Columns["chief"].Visible = false;
                subord.Columns["rate"].HeaderText = "Ставка";
                removeB.Visible = false;
                subord.ReadOnly = true;
                acceptB.Enabled = false;
            }
            subord.Columns["fio"].Width = 190;
        }

        private void acceptB_Click(object sender, EventArgs e)
        {
            string chiefFio = subord.CurrentRow.Cells["fio"].Value.ToString();
            Program.addWorker.Worker.Rows[0].Cells["chief"].Value = chiefFio;
            Program.addWorker.chiefTable = chiefTable();
            Close();
        }
        //Преобразование названия таблицы сотрудника
        private string chiefTable()
        {
            switch (subord.CurrentRow.Cells["role"].Value.ToString())
            {
                case "Работник": return "Employees";
                case "Менеджер": return "Managers";
                case "Продавец": return "Salesmen";
                default: return null;
            }
        }

        private void CancelB_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Subordinates_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }
        //Возврат на предыдущую форму, без определения начальника (для удаления информации о начальнике сотрудника)
        private void removeB_Click(object sender, EventArgs e)
        {
            Program.addWorker.Worker.Rows[0].Cells["chief"].Value = " ";
            Close();
        }
    }
}
