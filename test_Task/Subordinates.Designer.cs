
namespace test_Task
{
    partial class Subordinates
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
            this.subord = new System.Windows.Forms.DataGridView();
            this.acceptB = new System.Windows.Forms.Button();
            this.CancelB = new System.Windows.Forms.Button();
            this.removeB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.subord)).BeginInit();
            this.SuspendLayout();
            // 
            // subord
            // 
            this.subord.AllowUserToAddRows = false;
            this.subord.AllowUserToDeleteRows = false;
            this.subord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.subord.Location = new System.Drawing.Point(12, 12);
            this.subord.Name = "subord";
            this.subord.ReadOnly = true;
            this.subord.Size = new System.Drawing.Size(639, 187);
            this.subord.TabIndex = 0;
            // 
            // acceptB
            // 
            this.acceptB.Location = new System.Drawing.Point(93, 205);
            this.acceptB.Name = "acceptB";
            this.acceptB.Size = new System.Drawing.Size(123, 23);
            this.acceptB.TabIndex = 1;
            this.acceptB.Text = "Выбрать";
            this.acceptB.UseVisualStyleBackColor = true;
            this.acceptB.Click += new System.EventHandler(this.acceptB_Click);
            // 
            // CancelB
            // 
            this.CancelB.Location = new System.Drawing.Point(454, 205);
            this.CancelB.Name = "CancelB";
            this.CancelB.Size = new System.Drawing.Size(75, 23);
            this.CancelB.TabIndex = 2;
            this.CancelB.Text = "Отмена";
            this.CancelB.UseVisualStyleBackColor = true;
            this.CancelB.Click += new System.EventHandler(this.CancelB_Click);
            // 
            // removeB
            // 
            this.removeB.Location = new System.Drawing.Point(93, 235);
            this.removeB.Name = "removeB";
            this.removeB.Size = new System.Drawing.Size(123, 23);
            this.removeB.TabIndex = 3;
            this.removeB.Text = "Без начальника";
            this.removeB.UseVisualStyleBackColor = true;
            this.removeB.Click += new System.EventHandler(this.removeB_Click);
            // 
            // Subordinates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 285);
            this.Controls.Add(this.removeB);
            this.Controls.Add(this.CancelB);
            this.Controls.Add(this.acceptB);
            this.Controls.Add(this.subord);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Subordinates";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Subordinates_FormClosed);
            this.Load += new System.EventHandler(this.Subordinates_Load);
            ((System.ComponentModel.ISupportInitialize)(this.subord)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView subord;
        private System.Windows.Forms.Button acceptB;
        private System.Windows.Forms.Button CancelB;
        private System.Windows.Forms.Button removeB;
    }
}