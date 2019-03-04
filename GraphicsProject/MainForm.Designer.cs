namespace GraphicsProject
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.CanvasBox = new System.Windows.Forms.PictureBox();
            this.LineButton = new System.Windows.Forms.Button();
            this.BezierButton = new System.Windows.Forms.Button();
            this.ParaButton = new System.Windows.Forms.Button();
            this.AngleButton = new System.Windows.Forms.Button();
            this.LayersList = new System.Windows.Forms.ListBox();
            this.RotateButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.RotateNumerical = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ScaleNumeric = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ScaleOutButton = new System.Windows.Forms.Button();
            this.ScaleInButton = new System.Windows.Forms.Button();
            this.IntersectButton = new System.Windows.Forms.Button();
            this.DifferenceButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ColorBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CanvasBox)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RotateNumerical)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScaleNumeric)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(825, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // NewToolStripMenuItem
            // 
            this.NewToolStripMenuItem.Name = "NewToolStripMenuItem";
            this.NewToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.NewToolStripMenuItem.Text = "New";
            this.NewToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.ExitToolStripMenuItem.Text = "Exit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(99, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.HelpToolStripMenuItem1_Click);
            // 
            // CanvasBox
            // 
            this.CanvasBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CanvasBox.BackColor = System.Drawing.Color.White;
            this.CanvasBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CanvasBox.Location = new System.Drawing.Point(102, 27);
            this.CanvasBox.Name = "CanvasBox";
            this.CanvasBox.Size = new System.Drawing.Size(621, 439);
            this.CanvasBox.TabIndex = 1;
            this.CanvasBox.TabStop = false;
            this.CanvasBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CanvasBox_MouseDown);
            this.CanvasBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CanvasBox_MouseMove);
            this.CanvasBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CanvasBox_MouseUp);
            // 
            // LineButton
            // 
            this.LineButton.Location = new System.Drawing.Point(3, 3);
            this.LineButton.Name = "LineButton";
            this.LineButton.Size = new System.Drawing.Size(78, 23);
            this.LineButton.TabIndex = 2;
            this.LineButton.Text = "Line";
            this.LineButton.UseVisualStyleBackColor = true;
            this.LineButton.Click += new System.EventHandler(this.LineButton_Click);
            // 
            // BezierButton
            // 
            this.BezierButton.Location = new System.Drawing.Point(3, 32);
            this.BezierButton.Name = "BezierButton";
            this.BezierButton.Size = new System.Drawing.Size(78, 23);
            this.BezierButton.TabIndex = 4;
            this.BezierButton.Text = "Bezier";
            this.BezierButton.UseVisualStyleBackColor = true;
            this.BezierButton.Click += new System.EventHandler(this.BezierButton_Click);
            // 
            // ParaButton
            // 
            this.ParaButton.Location = new System.Drawing.Point(3, 61);
            this.ParaButton.Name = "ParaButton";
            this.ParaButton.Size = new System.Drawing.Size(78, 23);
            this.ParaButton.TabIndex = 6;
            this.ParaButton.Text = "Parallelogram";
            this.ParaButton.UseVisualStyleBackColor = true;
            this.ParaButton.Click += new System.EventHandler(this.ParaButton_Click);
            // 
            // AngleButton
            // 
            this.AngleButton.Location = new System.Drawing.Point(3, 90);
            this.AngleButton.Name = "AngleButton";
            this.AngleButton.Size = new System.Drawing.Size(78, 23);
            this.AngleButton.TabIndex = 7;
            this.AngleButton.Text = "Angle";
            this.AngleButton.UseVisualStyleBackColor = true;
            this.AngleButton.Click += new System.EventHandler(this.AngleButton_Click);
            // 
            // LayersList
            // 
            this.LayersList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LayersList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LayersList.FormattingEnabled = true;
            this.LayersList.IntegralHeight = false;
            this.LayersList.Location = new System.Drawing.Point(729, 27);
            this.LayersList.Name = "LayersList";
            this.LayersList.Size = new System.Drawing.Size(86, 218);
            this.LayersList.TabIndex = 8;
            this.LayersList.SelectedIndexChanged += new System.EventHandler(this.LayersList_SelectedIndexChanged);
            this.LayersList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LayersList_MouseDown);
            // 
            // RotateButton
            // 
            this.RotateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RotateButton.Enabled = false;
            this.RotateButton.Location = new System.Drawing.Point(4, 5);
            this.RotateButton.Name = "RotateButton";
            this.RotateButton.Size = new System.Drawing.Size(77, 23);
            this.RotateButton.TabIndex = 9;
            this.RotateButton.Text = "Rotate";
            this.RotateButton.UseVisualStyleBackColor = true;
            this.RotateButton.Click += new System.EventHandler(this.RotateButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveButton.Enabled = false;
            this.RemoveButton.Location = new System.Drawing.Point(729, 443);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(86, 23);
            this.RemoveButton.TabIndex = 11;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 475);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(825, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(31, 17);
            this.StatusLabel.Text = "Wait";
            // 
            // RotateNumerical
            // 
            this.RotateNumerical.Location = new System.Drawing.Point(3, 45);
            this.RotateNumerical.Name = "RotateNumerical";
            this.RotateNumerical.Size = new System.Drawing.Size(77, 20);
            this.RotateNumerical.TabIndex = 13;
            this.RotateNumerical.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.RotateNumerical.ValueChanged += new System.EventHandler(this.RotateNumerical_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Angle:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.RotateButton);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.RotateNumerical);
            this.panel1.Location = new System.Drawing.Point(729, 251);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(86, 79);
            this.panel1.TabIndex = 15;
            // 
            // ScaleNumeric
            // 
            this.ScaleNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ScaleNumeric.Location = new System.Drawing.Point(1, 76);
            this.ScaleNumeric.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ScaleNumeric.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.ScaleNumeric.Name = "ScaleNumeric";
            this.ScaleNumeric.Size = new System.Drawing.Size(78, 20);
            this.ScaleNumeric.TabIndex = 15;
            this.ScaleNumeric.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.ScaleNumeric.ValueChanged += new System.EventHandler(this.ScaleNumeric_ValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Scale:";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.ScaleOutButton);
            this.panel2.Controls.Add(this.ScaleInButton);
            this.panel2.Controls.Add(this.ScaleNumeric);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(729, 336);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(86, 101);
            this.panel2.TabIndex = 17;
            // 
            // ScaleOutButton
            // 
            this.ScaleOutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ScaleOutButton.Enabled = false;
            this.ScaleOutButton.Location = new System.Drawing.Point(3, 30);
            this.ScaleOutButton.Name = "ScaleOutButton";
            this.ScaleOutButton.Size = new System.Drawing.Size(77, 23);
            this.ScaleOutButton.TabIndex = 17;
            this.ScaleOutButton.Text = "Scale Out";
            this.ScaleOutButton.UseVisualStyleBackColor = true;
            this.ScaleOutButton.Click += new System.EventHandler(this.ScaleOutButton_Click);
            // 
            // ScaleInButton
            // 
            this.ScaleInButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ScaleInButton.Enabled = false;
            this.ScaleInButton.Location = new System.Drawing.Point(3, 1);
            this.ScaleInButton.Name = "ScaleInButton";
            this.ScaleInButton.Size = new System.Drawing.Size(77, 23);
            this.ScaleInButton.TabIndex = 15;
            this.ScaleInButton.Text = "Scale In";
            this.ScaleInButton.UseVisualStyleBackColor = true;
            this.ScaleInButton.Click += new System.EventHandler(this.ScaleInButton_Click);
            // 
            // IntersectButton
            // 
            this.IntersectButton.Location = new System.Drawing.Point(3, 3);
            this.IntersectButton.Name = "IntersectButton";
            this.IntersectButton.Size = new System.Drawing.Size(78, 23);
            this.IntersectButton.TabIndex = 18;
            this.IntersectButton.Text = "Intersection";
            this.IntersectButton.UseVisualStyleBackColor = true;
            this.IntersectButton.Click += new System.EventHandler(this.IntersectButton_Click);
            // 
            // DifferenceButton
            // 
            this.DifferenceButton.Location = new System.Drawing.Point(3, 32);
            this.DifferenceButton.Name = "DifferenceButton";
            this.DifferenceButton.Size = new System.Drawing.Size(78, 23);
            this.DifferenceButton.TabIndex = 19;
            this.DifferenceButton.Text = "Difference";
            this.DifferenceButton.UseVisualStyleBackColor = true;
            this.DifferenceButton.Click += new System.EventHandler(this.DifferenceButton_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.LineButton);
            this.panel3.Controls.Add(this.BezierButton);
            this.panel3.Controls.Add(this.ParaButton);
            this.panel3.Controls.Add(this.AngleButton);
            this.panel3.Location = new System.Drawing.Point(12, 27);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(84, 119);
            this.panel3.TabIndex = 20;
            this.panel3.Tag = "";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.IntersectButton);
            this.panel4.Controls.Add(this.DifferenceButton);
            this.panel4.Location = new System.Drawing.Point(12, 152);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(84, 62);
            this.panel4.TabIndex = 21;
            // 
            // ColorBox
            // 
            this.ColorBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ColorBox.FormattingEnabled = true;
            this.ColorBox.Items.AddRange(new object[] {
            "Black",
            "Red",
            "Green",
            "Blue"});
            this.ColorBox.Location = new System.Drawing.Point(12, 443);
            this.ColorBox.Name = "ColorBox";
            this.ColorBox.Size = new System.Drawing.Size(82, 21);
            this.ColorBox.TabIndex = 22;
            this.ColorBox.Text = "Black";
            this.ColorBox.SelectedIndexChanged += new System.EventHandler(this.ColorBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 427);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Color:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 497);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ColorBox);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.LayersList);
            this.Controls.Add(this.CanvasBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Course Project";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CanvasBox)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RotateNumerical)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScaleNumeric)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.PictureBox CanvasBox;
        private System.Windows.Forms.Button LineButton;
        private System.Windows.Forms.Button BezierButton;
        private System.Windows.Forms.Button ParaButton;
        private System.Windows.Forms.Button AngleButton;
        private System.Windows.Forms.ListBox LayersList;
        private System.Windows.Forms.Button RotateButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.NumericUpDown RotateNumerical;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown ScaleNumeric;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button ScaleOutButton;
        private System.Windows.Forms.Button ScaleInButton;
        private System.Windows.Forms.Button IntersectButton;
        private System.Windows.Forms.Button DifferenceButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox ColorBox;
        private System.Windows.Forms.Label label1;
    }
}

