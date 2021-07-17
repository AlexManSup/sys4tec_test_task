
namespace test_Task
{
    partial class Auth
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.adminB = new System.Windows.Forms.Button();
            this.userB = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.modeP = new System.Windows.Forms.Panel();
            this.authP = new System.Windows.Forms.Panel();
            this.backB = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.passwordTB = new System.Windows.Forms.TextBox();
            this.loginTB = new System.Windows.Forms.TextBox();
            this.forgotB = new System.Windows.Forms.Button();
            this.enterB = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.modeP.SuspendLayout();
            this.authP.SuspendLayout();
            this.SuspendLayout();
            // 
            // adminB
            // 
            this.adminB.Location = new System.Drawing.Point(147, 55);
            this.adminB.Name = "adminB";
            this.adminB.Size = new System.Drawing.Size(102, 55);
            this.adminB.TabIndex = 0;
            this.adminB.Text = "Режим\r\nадминистратора";
            this.adminB.UseVisualStyleBackColor = true;
            this.adminB.Click += new System.EventHandler(this.adminB_Click);
            // 
            // userB
            // 
            this.userB.Location = new System.Drawing.Point(147, 129);
            this.userB.Name = "userB";
            this.userB.Size = new System.Drawing.Size(102, 55);
            this.userB.TabIndex = 1;
            this.userB.Text = "Режим\r\nпользователя";
            this.userB.UseVisualStyleBackColor = true;
            this.userB.Click += new System.EventHandler(this.userB_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(276, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Тестовое задание Лаунерт А. ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(80, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(278, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Выберите режим работы с приложением";
            // 
            // modeP
            // 
            this.modeP.Controls.Add(this.userB);
            this.modeP.Controls.Add(this.label1);
            this.modeP.Controls.Add(this.label2);
            this.modeP.Controls.Add(this.adminB);
            this.modeP.Location = new System.Drawing.Point(15, 12);
            this.modeP.Name = "modeP";
            this.modeP.Size = new System.Drawing.Size(437, 253);
            this.modeP.TabIndex = 4;
            // 
            // authP
            // 
            this.authP.Controls.Add(this.backB);
            this.authP.Controls.Add(this.label5);
            this.authP.Controls.Add(this.label4);
            this.authP.Controls.Add(this.passwordTB);
            this.authP.Controls.Add(this.loginTB);
            this.authP.Controls.Add(this.forgotB);
            this.authP.Controls.Add(this.enterB);
            this.authP.Controls.Add(this.label3);
            this.authP.Location = new System.Drawing.Point(1, 2);
            this.authP.Name = "authP";
            this.authP.Size = new System.Drawing.Size(451, 263);
            this.authP.TabIndex = 4;
            this.authP.Visible = false;
            // 
            // backB
            // 
            this.backB.Location = new System.Drawing.Point(3, 11);
            this.backB.Name = "backB";
            this.backB.Size = new System.Drawing.Size(33, 28);
            this.backB.TabIndex = 7;
            this.backB.Text = "←\r\n";
            this.backB.UseVisualStyleBackColor = true;
            this.backB.Click += new System.EventHandler(this.backB_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(158, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Пароль:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(158, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Логин:";
            // 
            // passwordTB
            // 
            this.passwordTB.Location = new System.Drawing.Point(161, 117);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.PasswordChar = '*';
            this.passwordTB.Size = new System.Drawing.Size(100, 20);
            this.passwordTB.TabIndex = 4;
            // 
            // loginTB
            // 
            this.loginTB.Location = new System.Drawing.Point(161, 78);
            this.loginTB.Name = "loginTB";
            this.loginTB.Size = new System.Drawing.Size(100, 20);
            this.loginTB.TabIndex = 3;
            // 
            // forgotB
            // 
            this.forgotB.Location = new System.Drawing.Point(161, 181);
            this.forgotB.Name = "forgotB";
            this.forgotB.Size = new System.Drawing.Size(100, 23);
            this.forgotB.TabIndex = 2;
            this.forgotB.Text = "Забыли пароль?";
            this.forgotB.UseVisualStyleBackColor = true;
            this.forgotB.Click += new System.EventHandler(this.forgotB_Click);
            // 
            // enterB
            // 
            this.enterB.Location = new System.Drawing.Point(161, 152);
            this.enterB.Name = "enterB";
            this.enterB.Size = new System.Drawing.Size(100, 23);
            this.enterB.TabIndex = 1;
            this.enterB.Text = "Войти";
            this.enterB.UseVisualStyleBackColor = true;
            this.enterB.Click += new System.EventHandler(this.enterB_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(140, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Введите логин и пароль";
            // 
            // Auth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 277);
            this.Controls.Add(this.authP);
            this.Controls.Add(this.modeP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Auth";
            this.Text = "Система расчета заработной платы";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Auth_FormClosed);
            this.modeP.ResumeLayout(false);
            this.modeP.PerformLayout();
            this.authP.ResumeLayout(false);
            this.authP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button adminB;
        private System.Windows.Forms.Button userB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel modeP;
        private System.Windows.Forms.Panel authP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox passwordTB;
        private System.Windows.Forms.TextBox loginTB;
        private System.Windows.Forms.Button forgotB;
        private System.Windows.Forms.Button enterB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button backB;
    }
}

