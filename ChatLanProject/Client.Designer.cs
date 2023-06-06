namespace ChatLanProject
{
    partial class Client
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
            listView1 = new ListView();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Location = new Point(22, 37);
            listView1.Name = "listView1";
            listView1.Size = new Size(1332, 418);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.List;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(22, 497);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(527, 39);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(22, 576);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(952, 42);
            textBox2.TabIndex = 2;
            // 
            // button1
            // 
            button1.Font = new Font("Arial", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.LightSeaGreen;
            button1.Location = new Point(992, 569);
            button1.Name = "button1";
            button1.Size = new Size(179, 49);
            button1.TabIndex = 3;
            button1.Text = "Send";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Arial", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = Color.DarkGreen;
            button2.Location = new Point(992, 489);
            button2.Name = "button2";
            button2.Size = new Size(179, 47);
            button2.TabIndex = 4;
            button2.Text = "Connect";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Arial", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            button3.ForeColor = Color.Tomato;
            button3.Location = new Point(1177, 489);
            button3.Name = "button3";
            button3.Size = new Size(177, 47);
            button3.TabIndex = 5;
            button3.Text = "Disconnect";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Arial", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            button4.ForeColor = Color.Olive;
            button4.Location = new Point(1177, 569);
            button4.Name = "button4";
            button4.Size = new Size(177, 49);
            button4.TabIndex = 6;
            button4.Text = "Attach File";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(23, 473);
            label1.Name = "label1";
            label1.Size = new Size(88, 19);
            label1.TabIndex = 7;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(23, 553);
            label2.Name = "label2";
            label2.Size = new Size(88, 21);
            label2.TabIndex = 8;
            label2.Text = "Message";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(22, 15);
            label3.Name = "label3";
            label3.Size = new Size(97, 19);
            label3.TabIndex = 9;
            label3.Text = "Chat Room";
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1382, 639);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(listView1);
            Name = "Client";
            Text = "Client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}