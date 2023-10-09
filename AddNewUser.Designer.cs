namespace NUMISMATICA
{
    partial class AddNewUser
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtNameUser = new System.Windows.Forms.TextBox();
            this.txtTypeUser = new System.Windows.Forms.TextBox();
            this.txtPassword1User = new System.Windows.Forms.TextBox();
            this.txtPassword2User = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(94, 298);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Додати";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(286, 297);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Вихід";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // txtNameUser
            // 
            this.txtNameUser.Location = new System.Drawing.Point(222, 46);
            this.txtNameUser.Name = "txtNameUser";
            this.txtNameUser.Size = new System.Drawing.Size(100, 22);
            this.txtNameUser.TabIndex = 2;
            this.txtNameUser.Leave += new System.EventHandler(this.txtNameUser_Leave);
            // 
            // txtTypeUser
            // 
            this.txtTypeUser.Location = new System.Drawing.Point(222, 97);
            this.txtTypeUser.Name = "txtTypeUser";
            this.txtTypeUser.Size = new System.Drawing.Size(100, 22);
            this.txtTypeUser.TabIndex = 3;
            this.txtTypeUser.Leave += new System.EventHandler(this.txtTypeUser_Leave);
            // 
            // txtPassword1User
            // 
            this.txtPassword1User.Location = new System.Drawing.Point(222, 148);
            this.txtPassword1User.Name = "txtPassword1User";
            this.txtPassword1User.Size = new System.Drawing.Size(100, 22);
            this.txtPassword1User.TabIndex = 4;
            // 
            // txtPassword2User
            // 
            this.txtPassword2User.Location = new System.Drawing.Point(222, 192);
            this.txtPassword2User.Name = "txtPassword2User";
            this.txtPassword2User.Size = new System.Drawing.Size(100, 22);
            this.txtPassword2User.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Користувач";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Тип доступу";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(97, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Пароль";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Підтвердження паролю";
            // 
            // AddNewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 374);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword2User);
            this.Controls.Add(this.txtPassword1User);
            this.Controls.Add(this.txtTypeUser);
            this.Controls.Add(this.txtNameUser);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "AddNewUser";
            this.Text = "AddNewUser";
            this.Load += new System.EventHandler(this.AddNewUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtNameUser;
        private System.Windows.Forms.TextBox txtTypeUser;
        private System.Windows.Forms.TextBox txtPassword1User;
        private System.Windows.Forms.TextBox txtPassword2User;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}