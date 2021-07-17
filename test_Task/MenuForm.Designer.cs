
namespace test_Task
{
    partial class MenuForm
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
            this.exitB = new System.Windows.Forms.Button();
            this.welcomeL = new System.Windows.Forms.Label();
            this.firstB = new System.Windows.Forms.Button();
            this.secondB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // exitB
            // 
            this.exitB.Location = new System.Drawing.Point(12, 12);
            this.exitB.Name = "exitB";
            this.exitB.Size = new System.Drawing.Size(36, 23);
            this.exitB.TabIndex = 0;
            this.exitB.Text = "←";
            this.exitB.UseVisualStyleBackColor = true;
            this.exitB.Click += new System.EventHandler(this.exitB_Click);
            // 
            // welcomeL
            // 
            this.welcomeL.AutoSize = true;
            this.welcomeL.Location = new System.Drawing.Point(143, 17);
            this.welcomeL.Name = "welcomeL";
            this.welcomeL.Size = new System.Drawing.Size(0, 13);
            this.welcomeL.TabIndex = 1;
            // 
            // firstB
            // 
            this.firstB.Location = new System.Drawing.Point(122, 109);
            this.firstB.Name = "firstB";
            this.firstB.Size = new System.Drawing.Size(170, 25);
            this.firstB.TabIndex = 2;
            this.firstB.UseVisualStyleBackColor = true;
            this.firstB.Click += new System.EventHandler(this.firstB_Click);
            // 
            // secondB
            // 
            this.secondB.Location = new System.Drawing.Point(122, 173);
            this.secondB.Name = "secondB";
            this.secondB.Size = new System.Drawing.Size(170, 25);
            this.secondB.TabIndex = 3;
            this.secondB.UseVisualStyleBackColor = true;
            this.secondB.Click += new System.EventHandler(this.secondB_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 320);
            this.Controls.Add(this.secondB);
            this.Controls.Add(this.firstB);
            this.Controls.Add(this.welcomeL);
            this.Controls.Add(this.exitB);
            this.Name = "MenuForm";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MenuForm_FormClosed);
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button exitB;
        private System.Windows.Forms.Label welcomeL;
        private System.Windows.Forms.Button firstB;
        private System.Windows.Forms.Button secondB;
    }
}