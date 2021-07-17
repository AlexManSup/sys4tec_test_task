
namespace test_Task
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AddB = new System.Windows.Forms.Button();
            this.ModifyB = new System.Windows.Forms.Button();
            this.DeleteB = new System.Windows.Forms.Button();
            this.EmployeesList = new System.Windows.Forms.DataGridView();
            this.checkSubordB = new System.Windows.Forms.Button();
            this.incomeB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeesList)).BeginInit();
            this.SuspendLayout();
            // 
            // AddB
            // 
            this.AddB.Location = new System.Drawing.Point(13, 289);
            this.AddB.Name = "AddB";
            this.AddB.Size = new System.Drawing.Size(135, 23);
            this.AddB.TabIndex = 0;
            this.AddB.Text = "Добавить сотрудника";
            this.AddB.UseVisualStyleBackColor = true;
            this.AddB.Click += new System.EventHandler(this.AddB_Click);
            // 
            // ModifyB
            // 
            this.ModifyB.Location = new System.Drawing.Point(154, 289);
            this.ModifyB.Name = "ModifyB";
            this.ModifyB.Size = new System.Drawing.Size(135, 23);
            this.ModifyB.TabIndex = 1;
            this.ModifyB.Text = "Изменить данные";
            this.ModifyB.UseVisualStyleBackColor = true;
            this.ModifyB.Click += new System.EventHandler(this.ModifyB_Click);
            // 
            // DeleteB
            // 
            this.DeleteB.Location = new System.Drawing.Point(295, 289);
            this.DeleteB.Name = "DeleteB";
            this.DeleteB.Size = new System.Drawing.Size(135, 23);
            this.DeleteB.TabIndex = 2;
            this.DeleteB.Text = "Удалить сотрудника";
            this.DeleteB.UseVisualStyleBackColor = true;
            this.DeleteB.Click += new System.EventHandler(this.DeleteB_Click);
            // 
            // EmployeesList
            // 
            this.EmployeesList.AllowUserToAddRows = false;
            this.EmployeesList.AllowUserToDeleteRows = false;
            this.EmployeesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EmployeesList.Location = new System.Drawing.Point(13, 13);
            this.EmployeesList.MultiSelect = false;
            this.EmployeesList.Name = "EmployeesList";
            this.EmployeesList.ReadOnly = true;
            this.EmployeesList.Size = new System.Drawing.Size(726, 270);
            this.EmployeesList.TabIndex = 3;
            // 
            // checkSubordB
            // 
            this.checkSubordB.Location = new System.Drawing.Point(436, 289);
            this.checkSubordB.Name = "checkSubordB";
            this.checkSubordB.Size = new System.Drawing.Size(149, 23);
            this.checkSubordB.TabIndex = 4;
            this.checkSubordB.Text = "Посмотреть подчиненных";
            this.checkSubordB.UseVisualStyleBackColor = true;
            this.checkSubordB.Click += new System.EventHandler(this.checkSubordB_Click);
            // 
            // incomeB
            // 
            this.incomeB.Location = new System.Drawing.Point(591, 289);
            this.incomeB.Name = "incomeB";
            this.incomeB.Size = new System.Drawing.Size(149, 23);
            this.incomeB.TabIndex = 5;
            this.incomeB.Text = "Расчет ЗП";
            this.incomeB.UseVisualStyleBackColor = true;
            this.incomeB.Click += new System.EventHandler(this.incomeB_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 450);
            this.Controls.Add(this.incomeB);
            this.Controls.Add(this.checkSubordB);
            this.Controls.Add(this.EmployeesList);
            this.Controls.Add(this.DeleteB);
            this.Controls.Add(this.ModifyB);
            this.Controls.Add(this.AddB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Список сотрудников";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EmployeesList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddB;
        private System.Windows.Forms.Button ModifyB;
        private System.Windows.Forms.Button DeleteB;
        private System.Windows.Forms.DataGridView EmployeesList;
        private System.Windows.Forms.Button checkSubordB;
        private System.Windows.Forms.Button incomeB;
    }
}