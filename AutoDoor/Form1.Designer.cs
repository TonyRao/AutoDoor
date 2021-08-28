
namespace AutoDoor
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.StartBtn = new System.Windows.Forms.Button();
            this.TestBtn = new System.Windows.Forms.Button();
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LogRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ManualRadioBtn = new System.Windows.Forms.RadioButton();
            this.AutoRadioBtn = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(87, 185);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(159, 108);
            this.StartBtn.TabIndex = 1;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // TestBtn
            // 
            this.TestBtn.Enabled = false;
            this.TestBtn.Location = new System.Drawing.Point(268, 185);
            this.TestBtn.Name = "TestBtn";
            this.TestBtn.Size = new System.Drawing.Size(159, 108);
            this.TestBtn.TabIndex = 2;
            this.TestBtn.Text = "Test";
            this.TestBtn.UseVisualStyleBackColor = true;
            this.TestBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.Location = new System.Drawing.Point(451, 185);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(159, 108);
            this.UpdateBtn.TabIndex = 3;
            this.UpdateBtn.Text = "Update";
            this.UpdateBtn.UseVisualStyleBackColor = true;
            this.UpdateBtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(161, 351);
            this.textBox2.MaxLength = 2;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(69, 51);
            this.textBox2.TabIndex = 4;
            this.textBox2.WordWrap = false;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(160, 456);
            this.textBox3.MaxLength = 2;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(69, 51);
            this.textBox3.TabIndex = 5;
            this.textBox3.WordWrap = false;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(479, 347);
            this.textBox4.MaxLength = 5;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 51);
            this.textBox4.TabIndex = 6;
            this.textBox4.Text = "1000";
            this.textBox4.WordWrap = false;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(80, 296);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 42);
            this.label1.TabIndex = 7;
            this.label1.Text = "Scanner";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(103, 411);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 42);
            this.label2.TabIndex = 8;
            this.label2.Text = "Door";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(479, 456);
            this.textBox5.MaxLength = 5;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 51);
            this.textBox5.TabIndex = 9;
            this.textBox5.Text = "0";
            this.textBox5.WordWrap = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(472, 296);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 42);
            this.label3.TabIndex = 10;
            this.label3.Text = "Delay";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(448, 411);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 42);
            this.label4.TabIndex = 11;
            this.label4.Text = "Timeout";
            // 
            // LogRichTextBox
            // 
            this.LogRichTextBox.Font = new System.Drawing.Font("Rockwell", 10F);
            this.LogRichTextBox.Location = new System.Drawing.Point(713, 12);
            this.LogRichTextBox.Name = "LogRichTextBox";
            this.LogRichTextBox.ReadOnly = true;
            this.LogRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedHorizontal;
            this.LogRichTextBox.Size = new System.Drawing.Size(387, 686);
            this.LogRichTextBox.TabIndex = 12;
            this.LogRichTextBox.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.DarkGray;
            this.label5.Location = new System.Drawing.Point(46, 459);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 42);
            this.label5.TabIndex = 13;
            this.label5.Text = "COM";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.DarkGray;
            this.label6.Location = new System.Drawing.Point(47, 354);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 42);
            this.label6.TabIndex = 14;
            this.label6.Text = "COM";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(139, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(298, 42);
            this.label7.TabIndex = 15;
            this.label7.Text = "AutoDoor V0.9.5";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Rockwell", 12F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(8, 682);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(421, 19);
            this.label8.TabIndex = 17;
            this.label8.Text = "Application was created by (Chantler?) Xavier, and Julio";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.DarkGray;
            this.label9.Location = new System.Drawing.Point(585, 351);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 42);
            this.label9.TabIndex = 18;
            this.label9.Text = "ms";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.DarkGray;
            this.label10.Location = new System.Drawing.Point(585, 459);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 42);
            this.label10.TabIndex = 19;
            this.label10.Text = "ms";
            // 
            // ManualRadioBtn
            // 
            this.ManualRadioBtn.AutoSize = true;
            this.ManualRadioBtn.ForeColor = System.Drawing.Color.White;
            this.ManualRadioBtn.Location = new System.Drawing.Point(403, 108);
            this.ManualRadioBtn.Name = "ManualRadioBtn";
            this.ManualRadioBtn.Size = new System.Drawing.Size(161, 46);
            this.ManualRadioBtn.TabIndex = 20;
            this.ManualRadioBtn.TabStop = true;
            this.ManualRadioBtn.Text = "Manual";
            this.ManualRadioBtn.UseVisualStyleBackColor = true;
            this.ManualRadioBtn.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // AutoRadioBtn
            // 
            this.AutoRadioBtn.AutoSize = true;
            this.AutoRadioBtn.Checked = true;
            this.AutoRadioBtn.ForeColor = System.Drawing.Color.White;
            this.AutoRadioBtn.Location = new System.Drawing.Point(167, 108);
            this.AutoRadioBtn.Name = "AutoRadioBtn";
            this.AutoRadioBtn.Size = new System.Drawing.Size(115, 46);
            this.AutoRadioBtn.TabIndex = 21;
            this.AutoRadioBtn.TabStop = true;
            this.AutoRadioBtn.Text = "Auto";
            this.AutoRadioBtn.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(56, 543);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(240, 42);
            this.label11.TabIndex = 22;
            this.label11.Text = "School Hours";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 606);
            this.textBox1.MaxLength = 5;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(149, 51);
            this.textBox1.TabIndex = 23;
            this.textBox1.Text = "7:05am";
            this.textBox1.WordWrap = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(186, 606);
            this.textBox6.MaxLength = 5;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(146, 51);
            this.textBox6.TabIndex = 24;
            this.textBox6.Text = "2:00pm";
            this.textBox6.WordWrap = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(460, 543);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(119, 42);
            this.label12.TabIndex = 25;
            this.label12.Text = "Lunch";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(374, 606);
            this.textBox7.MaxLength = 5;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(154, 51);
            this.textBox7.TabIndex = 26;
            this.textBox7.Text = "10:10am";
            this.textBox7.WordWrap = false;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(534, 606);
            this.textBox8.MaxLength = 5;
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(155, 51);
            this.textBox8.TabIndex = 27;
            this.textBox8.Text = "10:50am";
            this.textBox8.WordWrap = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(22F, 42F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1112, 710);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.AutoRadioBtn);
            this.Controls.Add(this.ManualRadioBtn);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LogRichTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.UpdateBtn);
            this.Controls.Add(this.TestBtn);
            this.Controls.Add(this.StartBtn);
            this.Font = new System.Drawing.Font("Rockwell", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.Name = "Form1";
            this.Text = "AutoDoor";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Button TestBtn;
        private System.Windows.Forms.Button UpdateBtn;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox LogRichTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton ManualRadioBtn;
        private System.Windows.Forms.RadioButton AutoRadioBtn;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
    }
}

