using System;
using System.Windows.Forms;

namespace test_Task
{
    public partial class Auth : Form
    {
        bool isAdm;
        string name;
        Queries q;
        public Auth()
        {
            InitializeComponent();
            Program.auth = this;
            q= new Queries();
        }
        //Изменения интерфейса по нажатию кнопок
        private void adminB_Click(object sender, EventArgs e)
        {
            isAdm = true;
            modeP.Visible = false;
            authP.Visible = true;
        }

        private void backB_Click(object sender, EventArgs e)
        {
            isAdm = false;
            modeP.Visible = true;
            authP.Visible = false;
        }

        private void userB_Click(object sender, EventArgs e)
        {
            isAdm = false;
            modeP.Visible = false;
            authP.Visible = true;
        }
        //Событие по нажатию кнопки "Забыли пароль?"
        private void forgotB_Click(object sender, EventArgs e)
        {
            if (isAdm) MessageBox.Show("Данные для авторизации администратора\nЛогин: admin\nПароль: admin", "Забыли пароль?", MessageBoxButtons.OK);
            else MessageBox.Show("Логин это первая буква названия таблицы в БД + ID работника в этой таблице\nПароль это год устройства на работу\nДля примера S1/1999", "Забыли пароль?", MessageBoxButtons.OK);
        }
        //Событие по нажатию кнопки "Войти"
        private void enterB_Click(object sender, EventArgs e)
        {
            if(loginTB.TextLength!=0 && passwordTB.TextLength != 0)
            {
                if (isAdm)
                {
                    if (loginTB.Text.Equals("admin") && passwordTB.Text.Equals("admin"))
                    {
                        Program.menuForm = new MenuForm(true);
                        Program.menuForm.Show();
                        this.Hide();
                    }
                    else MessageBox.Show("Введен неверный логин и/или пароль","Ошибка", MessageBoxButtons.OK);
                }
                else 
                {
                    if (q.auth(loginTB.Text, passwordTB.Text)) //Авторизация 
                    {
                        name = q.getFio(loginTB.Text);
                        Program.menuForm = new MenuForm(false, name, loginTB.Text);
                        Program.menuForm.Show();
                        this.Hide();
                    }
                    else MessageBox.Show("Введен неверный логин и/или пароль", "Ошибка", MessageBoxButtons.OK);
                }
            }
            else MessageBox.Show("Одно из полей авторизации не заполнено", "Ошибка", MessageBoxButtons.OK);
        }

        private void Auth_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
