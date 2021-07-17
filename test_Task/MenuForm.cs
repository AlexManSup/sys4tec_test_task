using System;
using System.Windows.Forms;

namespace test_Task
{
    
    public partial class MenuForm : Form
    {
        bool mode;
        string name;
        string table;
        string l;
        public MenuForm(bool admin)
        {
            InitializeComponent();
            Program.menuForm = this;
            mode = admin;
            this.Text = "Режим администратора";
        }
        public MenuForm(bool admin, string username, string login)
        {
            InitializeComponent();
            mode = admin;
            name = username;
            this.Text = $"Пользователь {name}";
            l = login;
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            //Изменение интерфейса, при авторизации в роли администратора
            if (mode)
            {
                welcomeL.Text = "Добро пожаловать, \nАдминистратор!";
                firstB.Text = "Посмотреть сотрудников";
                secondB.Text = "Рассчитать ЗП всех сотрудников";
                secondB.Height = 40;
            }
            //Изменение интерфейса, при авторизации в роли администратора
            else
            {
                welcomeL.Text = $"Добро пожаловать, \n{name}!";
                firstB.Text = "Список подчиненных";
                secondB.Text = "Расчет ЗП";
                switch (l[0])
                {
                    case 'E': firstB.Enabled = false; break;
                    case 'M': table = "Managers"; break;
                    case 'S': table = "Salesmen"; break;
                    default: table = null; break;
                }
            }
        }

        private void MenuForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void exitB_Click(object sender, EventArgs e)
        {
            Program.auth = new Auth();
            Program.auth.Show();
            this.Hide();

        }

        private void firstB_Click(object sender, EventArgs e)
        {
            //Переход на форму со списком сотрудников, если пользователь администратор
            if (mode)
            {
                Program.mainForm = new MainForm();
                Program.mainForm.Show();
                this.Hide();
            }
            //Переход на форму со списком подчиненных, если пользователь сотрудник
            else
            {
                Program.subordinates = new Subordinates(false, name, table);
                Program.subordinates.Show();
                
            }
        }

        private void secondB_Click(object sender, EventArgs e)
        {
            //Переход на форму расчета зп для всех сотрудников, если пользователь администратор
            if (mode)
            {
                Program.incomeForm = new IncomeForm("admin");
                Program.incomeForm.Show();
                
            }
            //Переход на форму расчета зп для авторизованного сотрудника
            else
            {
                Program.incomeForm = new IncomeForm(l);
                Program.incomeForm.Show();
                
            }
        }
    }
}
