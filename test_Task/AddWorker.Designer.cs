
namespace test_Task
{
    partial class AddWorker
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
            this.Worker = new System.Windows.Forms.DataGridView();
            this.ConfirmB = new System.Windows.Forms.Button();
            this.CancelB = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.role = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.eic = new GenericDataGridView.GenericDataGridView.CalendarColumn();
            this.chief = new System.Windows.Forms.DataGridViewButtonColumn();
            this.rate = new JThomas.Controls.DataGridViewMaskedTextColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Worker)).BeginInit();
            this.SuspendLayout();
            // 
            // Worker
            // 
            this.Worker.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Worker.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.fio,
            this.role,
            this.eic,
            this.chief,
            this.rate});
            this.Worker.Location = new System.Drawing.Point(12, 12);
            this.Worker.Name = "Worker";
            this.Worker.Size = new System.Drawing.Size(726, 103);
            this.Worker.TabIndex = 0;
            this.Worker.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Worker_CellContentClick);
            this.Worker.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.Worker_DataError);
            // 
            // ConfirmB
            // 
            this.ConfirmB.Location = new System.Drawing.Point(131, 130);
            this.ConfirmB.Name = "ConfirmB";
            this.ConfirmB.Size = new System.Drawing.Size(86, 23);
            this.ConfirmB.TabIndex = 1;
            this.ConfirmB.Text = "Подтвердить";
            this.ConfirmB.UseVisualStyleBackColor = true;
            this.ConfirmB.Click += new System.EventHandler(this.ConfirmB_Click);
            // 
            // CancelB
            // 
            this.CancelB.Location = new System.Drawing.Point(449, 130);
            this.CancelB.Name = "CancelB";
            this.CancelB.Size = new System.Drawing.Size(86, 23);
            this.CancelB.TabIndex = 2;
            this.CancelB.Text = "Отмена";
            this.CancelB.UseVisualStyleBackColor = true;
            this.CancelB.Click += new System.EventHandler(this.CancelB_Click);
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            // 
            // fio
            // 
            this.fio.HeaderText = "ФИО";
            this.fio.Name = "fio";
            this.fio.Width = 190;
            // 
            // role
            // 
            this.role.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.role.HeaderText = "Роль";
            this.role.Items.AddRange(new object[] {
            "Работник",
            "Продавец",
            "Менеджер"});
            this.role.Name = "role";
            // 
            // eic
            // 
            this.eic.HeaderText = "Дата устройства";
            this.eic.Name = "eic";
            this.eic.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // chief
            // 
            this.chief.HeaderText = "Начальник";
            this.chief.Name = "chief";
            this.chief.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chief.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.chief.Width = 190;
            // 
            // rate
            // 
            this.rate.HeaderText = "Ставка";
            this.rate.Mask = "999999";
            this.rate.Name = "rate";
            this.rate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // AddWorker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 177);
            this.Controls.Add(this.CancelB);
            this.Controls.Add(this.ConfirmB);
            this.Controls.Add(this.Worker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddWorker";
            this.Text = "AddWorker";
            this.Load += new System.EventHandler(this.AddWorker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Worker)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView Worker;
        private System.Windows.Forms.Button ConfirmB;
        private System.Windows.Forms.Button CancelB;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn fio;
        private System.Windows.Forms.DataGridViewComboBoxColumn role;
        private GenericDataGridView.GenericDataGridView.CalendarColumn eic;
        private System.Windows.Forms.DataGridViewButtonColumn chief;
        private JThomas.Controls.DataGridViewMaskedTextColumn rate;
    }
}