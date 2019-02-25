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
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnMove = new System.Windows.Forms.Button();
            this.btnMirror = new System.Windows.Forms.Button();
            this.btnRotate = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.angleRotate = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.btnTmoUnion = new System.Windows.Forms.Button();
            this.btnTmoIntersection = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.CanvasBox)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.anglesCounter)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.angleRotate)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
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
            this.CanvasBox.Location = new System.Drawing.Point(259, 2);
            this.CanvasBox.Margin = new System.Windows.Forms.Padding(4);
            this.CanvasBox.Name = "CanvasBox";
            this.CanvasBox.Size = new System.Drawing.Size(923, 948);
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
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 2);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(257, 199);
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
            this.btnLine.Size = new System.Drawing.Size(251, 33);
            this.btnLine.TabIndex = 1;
            this.btnLine.Text = "Линия";
            this.btnLine.UseVisualStyleBackColor = false;
            this.btnLine.Click += new System.EventHandler(this.ChoosePrimitive);
            // 
            // btnTgp
            // 
            this.btnTgp.AutoSize = true;
            this.btnTgp.BackColor = System.Drawing.SystemColors.Window;
            this.btnTgp.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnTgp.FlatAppearance.BorderSize = 0;
            this.btnTgp.Location = new System.Drawing.Point(0, 60);
            this.btnTgp.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnTgp.Name = "btnTgp";
            this.btnTgp.Size = new System.Drawing.Size(251, 33);
            this.btnTgp.TabIndex = 2;
            this.btnTgp.Text = "Прямоугольный треугольник";
            this.btnTgp.UseVisualStyleBackColor = false;
            this.btnTgp.Click += new System.EventHandler(this.ChoosePrimitive);
            // 
            // btnCubicSpline
            // 
            this.btnCubicSpline.AutoSize = true;
            this.btnCubicSpline.BackColor = System.Drawing.SystemColors.Window;
            this.btnCubicSpline.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnCubicSpline.Location = new System.Drawing.Point(0, 94);
            this.btnCubicSpline.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnCubicSpline.Name = "btnCubicSpline";
            this.btnCubicSpline.Size = new System.Drawing.Size(251, 33);
            this.btnCubicSpline.TabIndex = 3;
            this.btnCubicSpline.Text = "Кривая Эрмита";
            this.btnCubicSpline.UseVisualStyleBackColor = false;
            this.btnCubicSpline.Click += new System.EventHandler(this.ChoosePrimitive);
            // 
            // btnPgn
            // 
            this.btnPgn.AutoSize = true;
            this.btnPgn.BackColor = System.Drawing.SystemColors.Window;
            this.btnPgn.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnPgn.Location = new System.Drawing.Point(0, 128);
            this.btnPgn.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnPgn.Name = "btnPgn";
            this.btnPgn.Size = new System.Drawing.Size(251, 33);
            this.btnPgn.TabIndex = 4;
            this.btnPgn.Text = "Правильный n-угольник";
            this.btnPgn.UseVisualStyleBackColor = false;
            this.btnPgn.Click += new System.EventHandler(this.ChoosePrimitive);
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.anglesCounter);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(3, 163);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(195, 28);
            this.panel2.TabIndex = 5;
            // 
            // anglesCounter
            // 
            this.anglesCounter.Location = new System.Drawing.Point(131, 4);
            this.anglesCounter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.anglesCounter.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.anglesCounter.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.anglesCounter.Name = "anglesCounter";
            this.anglesCounter.Size = new System.Drawing.Size(61, 22);
            this.anglesCounter.TabIndex = 1;
            this.anglesCounter.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Количество углов:";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel2.Controls.Add(this.label3);
            this.flowLayoutPanel2.Controls.Add(this.btnMove);
            this.flowLayoutPanel2.Controls.Add(this.btnMirror);
            this.flowLayoutPanel2.Controls.Add(this.btnRotate);
            this.flowLayoutPanel2.Controls.Add(this.panel3);
            this.flowLayoutPanel2.Controls.Add(this.panel1);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 205);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(257, 171);
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
            this.btnMove.AutoSize = true;
            this.btnMove.BackColor = System.Drawing.SystemColors.Window;
            this.btnMove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMove.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnMove.FlatAppearance.BorderSize = 0;
            this.btnMove.Location = new System.Drawing.Point(0, 26);
            this.btnMove.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(251, 33);
            this.btnMove.TabIndex = 1;
            this.btnMove.Text = "Перемещение";
            this.btnMove.UseVisualStyleBackColor = false;
            this.btnMove.Click += new System.EventHandler(this.ChooseOperation);
            // 
            // btnMirror
            // 
            this.btnMirror.AutoSize = true;
            this.btnMirror.BackColor = System.Drawing.SystemColors.Window;
            this.btnMirror.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnMirror.FlatAppearance.BorderSize = 0;
            this.btnMirror.Location = new System.Drawing.Point(0, 60);
            this.btnMirror.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnMirror.Name = "btnMirror";
            this.btnMirror.Size = new System.Drawing.Size(251, 33);
            this.btnMirror.TabIndex = 2;
            this.btnMirror.Text = "Отражение относительно прямой";
            this.btnMirror.UseVisualStyleBackColor = false;
            this.btnMirror.Click += new System.EventHandler(this.ChooseOperation);
            // 
            // btnRotate
            // 
            this.btnRotate.AutoSize = true;
            this.btnRotate.BackColor = System.Drawing.SystemColors.Window;
            this.btnRotate.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnRotate.FlatAppearance.BorderSize = 0;
            this.btnRotate.Location = new System.Drawing.Point(0, 94);
            this.btnRotate.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnRotate.Name = "btnRotate";
            this.btnRotate.Size = new System.Drawing.Size(251, 33);
            this.btnRotate.TabIndex = 7;
            this.btnRotate.Text = "Поворот";
            this.btnRotate.UseVisualStyleBackColor = false;
            this.btnRotate.Click += new System.EventHandler(this.ChooseOperation);
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.Location = new System.Drawing.Point(3, 129);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(0, 0);
            this.panel3.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.angleRotate);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(3, 133);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(147, 30);
            this.panel1.TabIndex = 8;
            // 
            // angleRotate
            // 
            this.angleRotate.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.angleRotate.Location = new System.Drawing.Point(83, 6);
            this.angleRotate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.angleRotate.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.angleRotate.Name = "angleRotate";
            this.angleRotate.Size = new System.Drawing.Size(61, 22);
            this.angleRotate.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Угол(град):";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.flowLayoutPanel1);
            this.flowLayoutPanel3.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel3.Controls.Add(this.flowLayoutPanel5);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(255, 846);
            this.flowLayoutPanel3.TabIndex = 2;
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel5.Controls.Add(this.label7);
            this.flowLayoutPanel5.Controls.Add(this.btnTmoUnion);
            this.flowLayoutPanel5.Controls.Add(this.btnTmoIntersection);
            this.flowLayoutPanel5.Controls.Add(this.panel6);
            this.flowLayoutPanel5.Controls.Add(this.panel7);
            this.flowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel5.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(3, 380);
            this.flowLayoutPanel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(257, 97);
            this.flowLayoutPanel5.TabIndex = 2;
            this.flowLayoutPanel5.WrapContents = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 25);
            this.label7.TabIndex = 0;
            this.label7.Text = "Тмо:";
            // 
            // btnTmoUnion
            // 
            this.btnTmoUnion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTmoUnion.AutoSize = true;
            this.btnTmoUnion.BackColor = System.Drawing.SystemColors.Window;
            this.btnTmoUnion.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnTmoUnion.FlatAppearance.BorderSize = 0;
            this.btnTmoUnion.Location = new System.Drawing.Point(0, 26);
            this.btnTmoUnion.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnTmoUnion.Name = "btnTmoUnion";
            this.btnTmoUnion.Size = new System.Drawing.Size(251, 33);
            this.btnTmoUnion.TabIndex = 1;
            this.btnTmoUnion.Text = "Объединение";
            this.btnTmoUnion.UseVisualStyleBackColor = false;
            this.btnTmoUnion.Click += new System.EventHandler(this.ChooseOperation);
            // 
            // btnTmoIntersection
            // 
            this.btnTmoIntersection.AutoSize = true;
            this.btnTmoIntersection.BackColor = System.Drawing.SystemColors.Window;
            this.btnTmoIntersection.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnTmoIntersection.FlatAppearance.BorderSize = 0;
            this.btnTmoIntersection.Location = new System.Drawing.Point(0, 60);
            this.btnTmoIntersection.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.btnTmoIntersection.Name = "btnTmoIntersection";
            this.btnTmoIntersection.Size = new System.Drawing.Size(251, 33);
            this.btnTmoIntersection.TabIndex = 2;
            this.btnTmoIntersection.Text = "Пересечение";
            this.btnTmoIntersection.UseVisualStyleBackColor = false;
            this.btnTmoIntersection.Click += new System.EventHandler(this.ChooseOperation);
            // 
            // panel6
            // 
            this.panel6.AutoSize = true;
            this.panel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel6.Location = new System.Drawing.Point(3, 95);
            this.panel6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(0, 0);
            this.panel6.TabIndex = 5;
            // 
            // panel7
            // 
            this.panel7.AutoSize = true;
            this.panel7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel7.Location = new System.Drawing.Point(3, 99);
            this.panel7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(0, 0);
            this.panel7.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 846);
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.angleRotate)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
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
        private System.Windows.Forms.Button btnMirror;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button btnRotate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown angleRotate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnTmoUnion;
        private System.Windows.Forms.Button btnTmoIntersection;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
    }
}

