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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CanvasBox = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLine = new System.Windows.Forms.Button();
            this.btnTgp = new System.Windows.Forms.Button();
            this.btnCubicSpline = new System.Windows.Forms.Button();
            this.btnPgn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.anglesCounter = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnMove = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CanvasBox)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.anglesCounter)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // CanvasBox
            // 
            this.CanvasBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CanvasBox.BackColor = System.Drawing.Color.White;
            this.CanvasBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CanvasBox.Location = new System.Drawing.Point(259, 3);
            this.CanvasBox.Margin = new System.Windows.Forms.Padding(4);
            this.CanvasBox.Name = "CanvasBox";
            this.CanvasBox.Size = new System.Drawing.Size(923, 949);
            this.CanvasBox.TabIndex = 1;
            this.CanvasBox.TabStop = false;
            this.CanvasBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CanvasBox_MouseDown);
            this.CanvasBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CanvasBox_MouseMove);
            this.CanvasBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CanvasBox_MouseUp);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.btnLine);
            this.flowLayoutPanel1.Controls.Add(this.btnTgp);
            this.flowLayoutPanel1.Controls.Add(this.btnCubicSpline);
            this.flowLayoutPanel1.Controls.Add(this.btnPgn);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(257, 181);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Примитивы:";
            // 
            // btnLine
            // 
            this.btnLine.AutoSize = true;
            this.btnLine.BackColor = System.Drawing.SystemColors.Window;
            this.btnLine.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnLine.FlatAppearance.BorderSize = 0;
            this.btnLine.Location = new System.Drawing.Point(0, 26);
            this.btnLine.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(251, 29);
            this.btnLine.TabIndex = 1;
            this.btnLine.Text = "Линия";
            this.btnLine.UseVisualStyleBackColor = false;
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // btnTgp
            // 
            this.btnTgp.AutoSize = true;
            this.btnTgp.BackColor = System.Drawing.SystemColors.Window;
            this.btnTgp.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnTgp.FlatAppearance.BorderSize = 0;
            this.btnTgp.Location = new System.Drawing.Point(0, 56);
            this.btnTgp.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnTgp.Name = "btnTgp";
            this.btnTgp.Size = new System.Drawing.Size(251, 29);
            this.btnTgp.TabIndex = 2;
            this.btnTgp.Text = "Прямоугольный треугольник";
            this.btnTgp.UseVisualStyleBackColor = false;
            this.btnTgp.Click += new System.EventHandler(this.btnTgp_Click);
            // 
            // btnCubicSpline
            // 
            this.btnCubicSpline.AutoSize = true;
            this.btnCubicSpline.BackColor = System.Drawing.SystemColors.Window;
            this.btnCubicSpline.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnCubicSpline.Location = new System.Drawing.Point(0, 86);
            this.btnCubicSpline.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnCubicSpline.Name = "btnCubicSpline";
            this.btnCubicSpline.Size = new System.Drawing.Size(251, 29);
            this.btnCubicSpline.TabIndex = 3;
            this.btnCubicSpline.Text = "Кривая Эрмита";
            this.btnCubicSpline.UseVisualStyleBackColor = false;
            this.btnCubicSpline.Click += new System.EventHandler(this.btnCubicSpline_Click);
            // 
            // btnPgn
            // 
            this.btnPgn.AutoSize = true;
            this.btnPgn.BackColor = System.Drawing.SystemColors.Window;
            this.btnPgn.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnPgn.Location = new System.Drawing.Point(0, 116);
            this.btnPgn.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnPgn.Name = "btnPgn";
            this.btnPgn.Size = new System.Drawing.Size(251, 29);
            this.btnPgn.TabIndex = 4;
            this.btnPgn.Text = "Правильный n-угольник";
            this.btnPgn.UseVisualStyleBackColor = false;
            this.btnPgn.Click += new System.EventHandler(this.btnPgn_Click);
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.anglesCounter);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(3, 148);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(206, 29);
            this.panel2.TabIndex = 5;
            // 
            // anglesCounter
            // 
            this.anglesCounter.Location = new System.Drawing.Point(141, 4);
            this.anglesCounter.Name = "anglesCounter";
            this.anglesCounter.Size = new System.Drawing.Size(62, 22);
            this.anglesCounter.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Количество углов:";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.SystemColors.Window;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Location = new System.Drawing.Point(0, 181);
            this.button1.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(265, 29);
            this.button1.TabIndex = 6;
            this.button1.Text = "Линия";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel2.Controls.Add(this.label3);
            this.flowLayoutPanel2.Controls.Add(this.btnMove);
            this.flowLayoutPanel2.Controls.Add(this.button2);
            this.flowLayoutPanel2.Controls.Add(this.button3);
            this.flowLayoutPanel2.Controls.Add(this.panel3);
            this.flowLayoutPanel2.Controls.Add(this.panel1);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 190);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(257, 162);
            this.flowLayoutPanel2.TabIndex = 1;
            this.flowLayoutPanel2.WrapContents = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Преобразования:";
            // 
            // btnMove
            // 
            this.btnMove.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMove.AutoSize = true;
            this.btnMove.BackColor = System.Drawing.SystemColors.Window;
            this.btnMove.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnMove.FlatAppearance.BorderSize = 0;
            this.btnMove.Location = new System.Drawing.Point(0, 26);
            this.btnMove.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(251, 29);
            this.btnMove.TabIndex = 1;
            this.btnMove.Text = "Перемещение";
            this.btnMove.UseVisualStyleBackColor = false;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.BackColor = System.Drawing.SystemColors.Window;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Location = new System.Drawing.Point(0, 56);
            this.button2.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(251, 29);
            this.button2.TabIndex = 2;
            this.button2.Text = "Отражение относительно прямой";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.AutoSize = true;
            this.button3.BackColor = System.Drawing.SystemColors.Window;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.Location = new System.Drawing.Point(0, 86);
            this.button3.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(251, 29);
            this.button3.TabIndex = 7;
            this.button3.Text = "Поворот";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.Location = new System.Drawing.Point(3, 118);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(0, 0);
            this.panel3.TabIndex = 5;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.flowLayoutPanel1);
            this.flowLayoutPanel3.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(255, 953);
            this.flowLayoutPanel3.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(3, 124);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(206, 29);
            this.panel1.TabIndex = 8;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(141, 4);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(62, 22);
            this.numericUpDown1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Угол(град):";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 953);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.CanvasBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Course Project";
            ((System.ComponentModel.ISupportInitialize)(this.CanvasBox)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.anglesCounter)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.PictureBox CanvasBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.Button btnTgp;
        private System.Windows.Forms.Button btnCubicSpline;
        private System.Windows.Forms.Button btnPgn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown anglesCounter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label4;
    }
}

