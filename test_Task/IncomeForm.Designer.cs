
namespace test_Task
{
    partial class IncomeForm
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
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.incomeToday = new System.Windows.Forms.Button();
            this.incomeDate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // datePicker
            // 
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePicker.Location = new System.Drawing.Point(91, 88);
            this.datePicker.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.datePicker.MinDate = new System.DateTime(1995, 1, 1, 0, 0, 0, 0);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(200, 20);
            this.datePicker.TabIndex = 0;
            // 
            // incomeToday
            // 
            this.incomeToday.Location = new System.Drawing.Point(91, 12);
            this.incomeToday.Name = "incomeToday";
            this.incomeToday.Size = new System.Drawing.Size(200, 23);
            this.incomeToday.TabIndex = 1;
            this.incomeToday.Text = "Рассчитать ЗП на данный месяц";
            this.incomeToday.UseVisualStyleBackColor = true;
            this.incomeToday.Click += new System.EventHandler(this.incomeToday_Click);
            // 
            // incomeDate
            // 
            this.incomeDate.Location = new System.Drawing.Point(91, 114);
            this.incomeDate.Name = "incomeDate";
            this.incomeDate.Size = new System.Drawing.Size(200, 23);
            this.incomeDate.TabIndex = 2;
            this.incomeDate.Text = "Рассчитать ЗП на выбранную дату";
            this.incomeDate.UseVisualStyleBackColor = true;
            this.incomeDate.Click += new System.EventHandler(this.incomeDate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(146, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Выберите дату";
            // 
            // IncomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 322);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.incomeDate);
            this.Controls.Add(this.incomeToday);
            this.Controls.Add(this.datePicker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "IncomeForm";
            this.Text = "IncomeForm";
            this.Load += new System.EventHandler(this.IncomeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Button incomeToday;
        private System.Windows.Forms.Button incomeDate;
        private System.Windows.Forms.Label label1;
    }
}