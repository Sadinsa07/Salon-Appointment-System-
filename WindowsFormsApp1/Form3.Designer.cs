namespace WindowsFormsApp1
{
    partial class Form3
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1Name = new System.Windows.Forms.TextBox();
            this.textBox2NIC = new System.Windows.Forms.TextBox();
            this.textBox3Tele = new System.Windows.Forms.TextBox();
            this.textBox4Mail = new System.Windows.Forms.TextBox();
            this.button1Register = new System.Windows.Forms.Button();
            this.button2Me = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(263, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer Register";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(208, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(208, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "NIC";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(208, 277);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 26);
            this.label4.TabIndex = 3;
            this.label4.Text = "Telephone";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(208, 334);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 26);
            this.label5.TabIndex = 4;
            this.label5.Text = "Email";
            // 
            // textBox1Name
            // 
            this.textBox1Name.Location = new System.Drawing.Point(388, 168);
            this.textBox1Name.Name = "textBox1Name";
            this.textBox1Name.Size = new System.Drawing.Size(138, 22);
            this.textBox1Name.TabIndex = 5;
            // 
            // textBox2NIC
            // 
            this.textBox2NIC.Location = new System.Drawing.Point(388, 220);
            this.textBox2NIC.Name = "textBox2NIC";
            this.textBox2NIC.Size = new System.Drawing.Size(138, 22);
            this.textBox2NIC.TabIndex = 6;
            // 
            // textBox3Tele
            // 
            this.textBox3Tele.Location = new System.Drawing.Point(387, 281);
            this.textBox3Tele.Name = "textBox3Tele";
            this.textBox3Tele.Size = new System.Drawing.Size(138, 22);
            this.textBox3Tele.TabIndex = 7;
            // 
            // textBox4Mail
            // 
            this.textBox4Mail.Location = new System.Drawing.Point(387, 334);
            this.textBox4Mail.Multiline = true;
            this.textBox4Mail.Name = "textBox4Mail";
            this.textBox4Mail.Size = new System.Drawing.Size(138, 22);
            this.textBox4Mail.TabIndex = 8;
            // 
            // button1Register
            // 
            this.button1Register.BackColor = System.Drawing.Color.IndianRed;
            this.button1Register.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1Register.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1Register.Location = new System.Drawing.Point(258, 420);
            this.button1Register.Name = "button1Register";
            this.button1Register.Size = new System.Drawing.Size(94, 43);
            this.button1Register.TabIndex = 9;
            this.button1Register.Text = "ADD";
            this.button1Register.UseVisualStyleBackColor = false;
            this.button1Register.Click += new System.EventHandler(this.button1Register_Click);
            // 
            // button2Me
            // 
            this.button2Me.BackColor = System.Drawing.Color.Brown;
            this.button2Me.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2Me.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2Me.Location = new System.Drawing.Point(396, 420);
            this.button2Me.Name = "button2Me";
            this.button2Me.Size = new System.Drawing.Size(94, 43);
            this.button2Me.TabIndex = 10;
            this.button2Me.Text = "Menu";
            this.button2Me.UseVisualStyleBackColor = false;
            this.button2Me.Click += new System.EventHandler(this.button2Me_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(208, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 26);
            this.label6.TabIndex = 11;
            this.label6.Text = "Customer ID";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(387, 126);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(138, 22);
            this.textBox1.TabIndex = 12;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(772, 513);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button2Me);
            this.Controls.Add(this.button1Register);
            this.Controls.Add(this.textBox4Mail);
            this.Controls.Add(this.textBox3Tele);
            this.Controls.Add(this.textBox2NIC);
            this.Controls.Add(this.textBox1Name);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.Text = "Customer Register Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1Name;
        private System.Windows.Forms.TextBox textBox2NIC;
        private System.Windows.Forms.TextBox textBox3Tele;
        private System.Windows.Forms.TextBox textBox4Mail;
        private System.Windows.Forms.Button button1Register;
        private System.Windows.Forms.Button button2Me;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
    }
}