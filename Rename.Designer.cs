namespace FTP
{
    partial class Rename
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOldName = new System.Windows.Forms.TextBox();
            this.txtNewName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnRename = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(31, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên cũ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label2.Location = new System.Drawing.Point(34, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên mới";
            // 
            // txtOldName
            // 
            this.txtOldName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.txtOldName.Location = new System.Drawing.Point(217, 33);
            this.txtOldName.Name = "txtOldName";
            this.txtOldName.ReadOnly = true;
            this.txtOldName.Size = new System.Drawing.Size(275, 38);
            this.txtOldName.TabIndex = 2;
            // 
            // txtNewName
            // 
            this.txtNewName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.txtNewName.Location = new System.Drawing.Point(217, 87);
            this.txtNewName.Name = "txtNewName";
            this.txtNewName.Size = new System.Drawing.Size(275, 38);
            this.txtNewName.TabIndex = 3;
            this.txtNewName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNewName_KeyDown);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.button1.Location = new System.Drawing.Point(37, 151);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 43);
            this.button1.TabIndex = 4;
            this.button1.Text = "Trở về";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnRename
            // 
            this.btnRename.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnRename.Location = new System.Drawing.Point(329, 151);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(163, 43);
            this.btnRename.TabIndex = 5;
            this.btnRename.Text = "Rename";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.button2_Click);
            // 
            // Rename
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 224);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtNewName);
            this.Controls.Add(this.txtOldName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Rename";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rename";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Rename_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOldName;
        private System.Windows.Forms.TextBox txtNewName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnRename;
    }
}