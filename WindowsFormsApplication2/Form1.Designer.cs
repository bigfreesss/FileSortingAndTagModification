namespace WindowsFormsApplication2
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_jsonPath = new System.Windows.Forms.TextBox();
            this.textBox_frontLabel = new System.Windows.Forms.TextBox();
            this.comboBox_fileType = new System.Windows.Forms.ComboBox();
            this.textBox_afterLabel = new System.Windows.Forms.TextBox();
            this.button_jsonRevise = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar_jsonRevise = new System.Windows.Forms.ProgressBar();
            this.label_log = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label_FileSorting = new System.Windows.Forms.Label();
            this.progressBar_FileSorting = new System.Windows.Forms.ProgressBar();
            this.button_FileSorting_AllSubdirectories = new System.Windows.Forms.Button();
            this.textBox_FileSorting = new System.Windows.Forms.TextBox();
            this.button_FileSorting = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button_browseJson = new System.Windows.Forms.Button();
            this.button_browseFileSorting = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_jsonPath
            // 
            this.textBox_jsonPath.Location = new System.Drawing.Point(89, 46);
            this.textBox_jsonPath.Name = "textBox_jsonPath";
            this.textBox_jsonPath.Size = new System.Drawing.Size(326, 21);
            this.textBox_jsonPath.TabIndex = 1;
            // 
            // button_browseJson
            // 
            this.button_browseJson.Location = new System.Drawing.Point(421, 44);
            this.button_browseJson.Name = "button_browseJson";
            this.button_browseJson.Size = new System.Drawing.Size(69, 23);
            this.button_browseJson.TabIndex = 1;
            this.button_browseJson.Text = "浏览...";
            this.button_browseJson.UseVisualStyleBackColor = true;
            this.button_browseJson.Click += new System.EventHandler(this.button_browseJson_Click);
            // 
            // textBox_frontLabel
            // 
            this.textBox_frontLabel.Location = new System.Drawing.Point(151, 73);
            this.textBox_frontLabel.Name = "textBox_frontLabel";
            this.textBox_frontLabel.Size = new System.Drawing.Size(100, 21);
            this.textBox_frontLabel.TabIndex = 2;
            this.textBox_frontLabel.Text = "foam box";
            // 
            // comboBox_fileType
            // 
            this.comboBox_fileType.FormattingEnabled = true;
            this.comboBox_fileType.Items.AddRange(new object[] {
            ".txt",
            ".json",
            ".json"});
            this.comboBox_fileType.Location = new System.Drawing.Point(8, 20);
            this.comboBox_fileType.Name = "comboBox_fileType";
            this.comboBox_fileType.Size = new System.Drawing.Size(121, 20);
            this.comboBox_fileType.TabIndex = 3;
            this.comboBox_fileType.Text = ".json";
            // 
            // textBox_afterLabel
            // 
            this.textBox_afterLabel.Location = new System.Drawing.Point(390, 73);
            this.textBox_afterLabel.Name = "textBox_afterLabel";
            this.textBox_afterLabel.Size = new System.Drawing.Size(100, 21);
            this.textBox_afterLabel.TabIndex = 4;
            this.textBox_afterLabel.Text = "foam_box";
            // 
            // button_jsonRevise
            // 
            this.button_jsonRevise.Location = new System.Drawing.Point(8, 100);
            this.button_jsonRevise.Name = "button_jsonRevise";
            this.button_jsonRevise.Size = new System.Drawing.Size(75, 23);
            this.button_jsonRevise.TabIndex = 5;
            this.button_jsonRevise.Text = "开始修改";
            this.button_jsonRevise.UseVisualStyleBackColor = true;
            this.button_jsonRevise.Click += new System.EventHandler(this.button_jsonRevise_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "修改前标签（空为全修改）";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(257, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "修改后标签（空为提纯）";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "输入json路径";
            // 
            // progressBar_jsonRevise
            // 
            this.progressBar_jsonRevise.Location = new System.Drawing.Point(8, 129);
            this.progressBar_jsonRevise.Name = "progressBar_jsonRevise";
            this.progressBar_jsonRevise.Size = new System.Drawing.Size(482, 23);
            this.progressBar_jsonRevise.TabIndex = 10;
            // 
            // label_log
            // 
            this.label_log.AutoSize = true;
            this.label_log.Location = new System.Drawing.Point(6, 155);
            this.label_log.Name = "label_log";
            this.label_log.Size = new System.Drawing.Size(41, 12);
            this.label_log.TabIndex = 11;
            this.label_log.Text = "label4";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.label_FileSorting);
            this.groupBox1.Controls.Add(this.progressBar_FileSorting);
            this.groupBox1.Controls.Add(this.button_FileSorting_AllSubdirectories);
            this.groupBox1.Controls.Add(this.textBox_FileSorting);
            this.groupBox1.Controls.Add(this.button_FileSorting);
            this.groupBox1.Controls.Add(this.button_browseFileSorting);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(503, 176);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "文件排序";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(229, 96);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(47, 16);
            this.radioButton2.TabIndex = 13;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "复制";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(176, 96);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(47, 16);
            this.radioButton1.TabIndex = 12;
            this.radioButton1.Text = "移动";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label_FileSorting
            // 
            this.label_FileSorting.AutoSize = true;
            this.label_FileSorting.Location = new System.Drawing.Point(6, 78);
            this.label_FileSorting.Name = "label_FileSorting";
            this.label_FileSorting.Size = new System.Drawing.Size(41, 12);
            this.label_FileSorting.TabIndex = 11;
            this.label_FileSorting.Text = "label4";
            // 
            // progressBar_FileSorting
            // 
            this.progressBar_FileSorting.Location = new System.Drawing.Point(6, 48);
            this.progressBar_FileSorting.Name = "progressBar_FileSorting";
            this.progressBar_FileSorting.Size = new System.Drawing.Size(484, 23);
            this.progressBar_FileSorting.TabIndex = 10;
            // 
            // button_FileSorting_AllSubdirectories
            // 
            this.button_FileSorting_AllSubdirectories.Location = new System.Drawing.Point(87, 93);
            this.button_FileSorting_AllSubdirectories.Name = "button_FileSorting_AllSubdirectories";
            this.button_FileSorting_AllSubdirectories.Size = new System.Drawing.Size(75, 23);
            this.button_FileSorting_AllSubdirectories.TabIndex = 9;
            this.button_FileSorting_AllSubdirectories.Text = "所有子目录";
            this.button_FileSorting_AllSubdirectories.UseVisualStyleBackColor = true;
            this.button_FileSorting_AllSubdirectories.Click += new System.EventHandler(this.button_FileSorting_AllSubdirectories_Click);
            // 
            // textBox_FileSorting
            // 
            this.textBox_FileSorting.Location = new System.Drawing.Point(6, 20);
            this.textBox_FileSorting.Name = "textBox_FileSorting";
            this.textBox_FileSorting.Size = new System.Drawing.Size(410, 21);
            this.textBox_FileSorting.TabIndex = 8;
            // 
            // button_browseFileSorting
            // 
            this.button_browseFileSorting.Location = new System.Drawing.Point(422, 18);
            this.button_browseFileSorting.Name = "button_browseFileSorting";
            this.button_browseFileSorting.Size = new System.Drawing.Size(68, 23);
            this.button_browseFileSorting.TabIndex = 14;
            this.button_browseFileSorting.Text = "浏览...";
            this.button_browseFileSorting.UseVisualStyleBackColor = true;
            this.button_browseFileSorting.Click += new System.EventHandler(this.button_browseFileSorting_Click);
            // 
            // button_FileSorting
            // 
            this.button_FileSorting.Location = new System.Drawing.Point(6, 93);
            this.button_FileSorting.Name = "button_FileSorting";
            this.button_FileSorting.Size = new System.Drawing.Size(75, 23);
            this.button_FileSorting.TabIndex = 7;
            this.button_FileSorting.Text = "当前目录";
            this.button_FileSorting.UseVisualStyleBackColor = true;
            this.button_FileSorting.Click += new System.EventHandler(this.button_FileSorting_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox_fileType);
            this.groupBox2.Controls.Add(this.textBox_jsonPath);
            this.groupBox2.Controls.Add(this.label_log);
            this.groupBox2.Controls.Add(this.textBox_frontLabel);
            this.groupBox2.Controls.Add(this.progressBar_jsonRevise);
            this.groupBox2.Controls.Add(this.textBox_afterLabel);
            this.groupBox2.Controls.Add(this.button_jsonRevise);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.button_browseJson);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(503, 176);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "json修改标签";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(517, 208);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(509, 182);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "文件排序";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(509, 182);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "json修改标签";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 208);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "深度学习标定文件修改（需要是子文件夹形式） - 新界面";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBox_jsonPath;
        private System.Windows.Forms.TextBox textBox_frontLabel;
        private System.Windows.Forms.ComboBox comboBox_fileType;
        private System.Windows.Forms.TextBox textBox_afterLabel;
        private System.Windows.Forms.Button button_jsonRevise;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBar_jsonRevise;
        private System.Windows.Forms.Label label_log;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label_FileSorting;
        private System.Windows.Forms.ProgressBar progressBar_FileSorting;
        private System.Windows.Forms.Button button_FileSorting_AllSubdirectories;
        private System.Windows.Forms.TextBox textBox_FileSorting;
        private System.Windows.Forms.Button button_FileSorting;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button_browseJson;
        private System.Windows.Forms.Button button_browseFileSorting;
    }
}

