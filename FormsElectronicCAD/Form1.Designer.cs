namespace FormsElectronicCAD
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.CreateBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.openElementBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openConnectDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.DD8btn = new System.Windows.Forms.Button();
            this.DD14Btn = new System.Windows.Forms.Button();
            this.DD16Btn = new System.Windows.Forms.Button();
            this.RBtn = new System.Windows.Forms.Button();
            this.TrBtn = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.Yinput = new System.Windows.Forms.NumericUpDown();
            this.Xinput = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Yinput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Xinput)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(104, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(781, 517);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateBtn,
            this.toolStripDropDownButton2,
            this.toolStripDropDownButton1,
            this.toolStripButton2,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(981, 27);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // CreateBtn
            // 
            this.CreateBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CreateBtn.Image = ((System.Drawing.Image)(resources.GetObject("CreateBtn.Image")));
            this.CreateBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CreateBtn.Name = "CreateBtn";
            this.CreateBtn.Size = new System.Drawing.Size(56, 24);
            this.CreateBtn.Text = "Create";
            this.CreateBtn.Click += new System.EventHandler(this.CreateBtn_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(54, 28);
            this.toolStripDropDownButton2.Text = "Save";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(173, 26);
            this.toolStripMenuItem4.Text = "Save Project";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openElementBaseToolStripMenuItem,
            this.openConnectDataToolStripMenuItem,
            this.toolStripMenuItem1});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(59, 28);
            this.toolStripDropDownButton1.Text = "Open";
            // 
            // openElementBaseToolStripMenuItem
            // 
            this.openElementBaseToolStripMenuItem.Name = "openElementBaseToolStripMenuItem";
            this.openElementBaseToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.openElementBaseToolStripMenuItem.Text = "Open Element Base";
            this.openElementBaseToolStripMenuItem.Click += new System.EventHandler(this.openElementBaseToolStripMenuItem_Click);
            // 
            // openConnectDataToolStripMenuItem
            // 
            this.openConnectDataToolStripMenuItem.Name = "openConnectDataToolStripMenuItem";
            this.openConnectDataToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.openConnectDataToolStripMenuItem.Text = "Open Connect Data";
            this.openConnectDataToolStripMenuItem.Click += new System.EventHandler(this.openConnectDataToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(222, 26);
            this.toolStripMenuItem1.Text = "Open Project";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(69, 24);
            this.toolStripButton1.Text = "Compile";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(13, 31);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(85, 516);
            this.listBox1.TabIndex = 5;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.DD8btn);
            this.flowLayoutPanel1.Controls.Add(this.DD14Btn);
            this.flowLayoutPanel1.Controls.Add(this.DD16Btn);
            this.flowLayoutPanel1.Controls.Add(this.RBtn);
            this.flowLayoutPanel1.Controls.Add(this.TrBtn);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(891, 31);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(84, 407);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // DD8btn
            // 
            this.DD8btn.Location = new System.Drawing.Point(3, 3);
            this.DD8btn.Name = "DD8btn";
            this.DD8btn.Size = new System.Drawing.Size(75, 23);
            this.DD8btn.TabIndex = 4;
            this.DD8btn.Text = "DD8";
            this.DD8btn.UseVisualStyleBackColor = true;
            this.DD8btn.Click += new System.EventHandler(this.DD8Btn_Click);
            // 
            // DD14Btn
            // 
            this.DD14Btn.Location = new System.Drawing.Point(3, 32);
            this.DD14Btn.Name = "DD14Btn";
            this.DD14Btn.Size = new System.Drawing.Size(75, 23);
            this.DD14Btn.TabIndex = 0;
            this.DD14Btn.Text = "DD14";
            this.DD14Btn.UseVisualStyleBackColor = true;
            this.DD14Btn.Click += new System.EventHandler(this.DD14Btn_Click);
            // 
            // DD16Btn
            // 
            this.DD16Btn.Location = new System.Drawing.Point(3, 61);
            this.DD16Btn.Name = "DD16Btn";
            this.DD16Btn.Size = new System.Drawing.Size(75, 23);
            this.DD16Btn.TabIndex = 1;
            this.DD16Btn.Text = "DD16";
            this.DD16Btn.UseVisualStyleBackColor = true;
            this.DD16Btn.Click += new System.EventHandler(this.DD16Btn_Click);
            // 
            // RBtn
            // 
            this.RBtn.Location = new System.Drawing.Point(3, 90);
            this.RBtn.Name = "RBtn";
            this.RBtn.Size = new System.Drawing.Size(75, 23);
            this.RBtn.TabIndex = 2;
            this.RBtn.Text = "R";
            this.RBtn.UseVisualStyleBackColor = true;
            this.RBtn.Click += new System.EventHandler(this.RBtn_Click);
            // 
            // TrBtn
            // 
            this.TrBtn.Location = new System.Drawing.Point(3, 119);
            this.TrBtn.Name = "TrBtn";
            this.TrBtn.Size = new System.Drawing.Size(75, 23);
            this.TrBtn.TabIndex = 3;
            this.TrBtn.Text = "Tr";
            this.TrBtn.UseVisualStyleBackColor = true;
            this.TrBtn.Click += new System.EventHandler(this.TrBtn_Click);
            // 
            // Yinput
            // 
            this.Yinput.Location = new System.Drawing.Point(920, 5);
            this.Yinput.Name = "Yinput";
            this.Yinput.Size = new System.Drawing.Size(49, 22);
            this.Yinput.TabIndex = 7;
            this.Yinput.ValueChanged += new System.EventHandler(this.Yinput_ValueChanged);
            // 
            // Xinput
            // 
            this.Xinput.Location = new System.Drawing.Point(844, 5);
            this.Xinput.Name = "Xinput";
            this.Xinput.Size = new System.Drawing.Size(49, 22);
            this.Xinput.TabIndex = 8;
            this.Xinput.ValueChanged += new System.EventHandler(this.Xinput_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(823, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(899, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Y";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(74, 24);
            this.toolStripButton2.Text = "Optimize";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 552);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Xinput);
            this.Controls.Add(this.Yinput);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Circuit CAD Windows Forms";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Yinput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Xinput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem openConnectDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openElementBaseToolStripMenuItem;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button DD14Btn;
        private System.Windows.Forms.Button DD16Btn;
        private System.Windows.Forms.Button RBtn;
        private System.Windows.Forms.ToolStripButton CreateBtn;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.NumericUpDown Yinput;
        private System.Windows.Forms.NumericUpDown Xinput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button DD8btn;
        private System.Windows.Forms.Button TrBtn;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
    }
}

