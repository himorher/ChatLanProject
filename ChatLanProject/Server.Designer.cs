namespace ChatLanProject
{
    partial class Server
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
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Location = new Point(12, 65);
            listView1.Name = "listView1";
            listView1.Size = new Size(1013, 457);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.List;
            // 
            // button1
            // 
            button1.Font = new Font("Arial", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.DarkTurquoise;
            button1.Location = new Point(577, 12);
            button1.Name = "button1";
            button1.Size = new Size(221, 47);
            button1.TabIndex = 1;
            button1.Text = "START";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Arial", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = Color.BlueViolet;
            button2.Location = new Point(804, 12);
            button2.Name = "button2";
            button2.Size = new Size(221, 47);
            button2.TabIndex = 2;
            button2.Text = "CLOSE";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1037, 543);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(listView1);
            Name = "Server";
            Text = "Server";
            ResumeLayout(false);
        }

        #endregion

        private ListView listView1;
        private Button button1;
        private Button button2;
    }
}