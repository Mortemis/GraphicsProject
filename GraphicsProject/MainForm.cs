using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphicsProject.Figures;


/*
 * Var 37. 
 * Figures: Bezier +, parallelogram +, angle 2+
 * Straight line +
 * Transformations: rotate on custom angle, rotate 30 degrees, scale on center of figure
 * Also move
 * Operations: AND, SUBTRACT
 */






namespace GraphicsProject
{

    // State of UI
    enum State : int
    {
        WAIT, SELECTED, DRAW_LINE, DRAW_BEZIER, DRAW_PARA, DRAW_ANGLE, SCALE
    }

    public partial class MainForm : Form
    {

        public static Graphics g;
        public static Bitmap bmp;
        //TODO Width and height change on window resize.
        //HACK Fix me please, i am a mistake.
        public static int width;
        public static int height;
        public static Pen DrawPen = new Pen(Color.Black, 1);
        private State CurrentState;

        private Point FirstPoint;
        Bezier ActiveBezier;

        // Идея слоистости - есть лист абстрактного класса Figure, в котором есть метод Draw. 
        // Добавляем в него фигурки, наследующие его, и при любом апдейте просто вызываем метод Draw для всего листа.
        // Может быть, стоит повесить в юи список, чтобы выбирать фигуры можно было и через этот список. (Готово)
        // TODO Немного лагает, стоит сделать ограничение по количеству фигур или делать только частичную перерисовку и перерисовывать полностью только если это действительно нужно.
        List<Figure> Layers = new List<Figure>();
        int SelectedLayer = -1; //-1 - no select
        bool CodeSelect = false; // Protects from infinite cycle when selectedchange... event calls FullUpdate.
        public MainForm()
        {
            InitializeComponent();
            width = CanvasBox.Width;
            height = CanvasBox.Height;
            CurrentState = State.WAIT;
            bmp = new Bitmap(width, height);
            g = Graphics.FromImage(bmp);
        }

        /*
        // Update from index to end. Fix.
        private void UpdateCanvas(int index)
        {
            for (int i = index; i < Layers.Count; i++)
            {
                Layers[i].Draw();
                LayersList.Items.Add(Layers[i].ToString());
            }
        }

        private void FullUpdateCanvas()
        {
            g.Clear(Color.White);
            LayersList.Items.Clear();
            foreach (Figure figure in Layers)
            {
                figure.Draw();

                LayersList.Items.Add(figure.ToString());
            }
            CodeSelect = true;
            LayersList.SelectedIndex = SelectedLayer;
        }
        */

        private void UpdateCanvas(int index)
        {
            CanvasBox.Image = bmp;
        }

        private void FullUpdateCanvas()
        {
            CanvasBox.Image = bmp;
        }

        private void ManageStatus()
        {
            StatusLabel.Text = CurrentState.ToString();

            //TODO switchcase
        }

        private void ChangeState(State NewState)
        {
            if (CurrentState == State.SELECTED && NewState != State.SELECTED)
            {
                SelectedLayer = -1;
                RotateButton.Enabled = false;
                ScaleButton.Enabled = false;
                RemoveButton.Enabled = false;
                LayersList.ClearSelected();
            }

            if (NewState == State.SELECTED && LayersList.SelectedIndex != -1)
            {
                RotateButton.Enabled = true;
                ScaleButton.Enabled = true;
                RemoveButton.Enabled = true;

            }
            CurrentState = NewState;
            ManageStatus();

        }

        private void LineButton_Click(object sender, EventArgs e)
        {
            ChangeState(State.DRAW_LINE);
        }

        private void BezierButton_Click(object sender, EventArgs e)
        {
            ChangeState(State.DRAW_BEZIER);
            ActiveBezier = new Bezier();
        }

        private void ParaButton_Click(object sender, EventArgs e)
        {
            ChangeState(State.DRAW_PARA);
        }

        private void AngleButton_Click(object sender, EventArgs e)
        {
            ChangeState(State.DRAW_ANGLE);
        }

        private void RotateButton_Click(object sender, EventArgs e)
        {
            RotateButton.Enabled = false;
        }

        private void ScaleButton_Click(object sender, EventArgs e)
        {
            ScaleButton.Enabled = false;
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (CurrentState == State.SELECTED && LayersList.SelectedIndex != -1)
            {
                try
                {
                    Layers.RemoveAt(LayersList.SelectedIndex);
                    FullUpdateCanvas();
                    ChangeState(State.WAIT);
                }
                catch (IndexOutOfRangeException) { }
            }
            else
            {
                RemoveButton.Enabled = false;
            }
        }

        private void RedrawButton_Click(object sender, EventArgs e)
        {
            FullUpdateCanvas();
            LayersList.ClearSelected();
        }

        private void CanvasBox_MouseDown(object sender, MouseEventArgs e)
        {
            switch (CurrentState)
            {
                case State.WAIT:
                    {
                        //TODO Select
                        break;
                    }
                case State.SELECTED:
                    {
                        //TODO Move 
                        break;
                    }
                case State.DRAW_LINE:
                    {
                        FirstPoint = e.Location;
                        break;
                    }
                case State.DRAW_BEZIER:
                    {
                        ActiveBezier.AddPoint(e.Location);
                        if (e.Button == MouseButtons.Right)
                        {
                            ActiveBezier.Finish();
                            Layers.Add(ActiveBezier);
                            ActiveBezier = new Bezier();
                            UpdateCanvas(Layers.Count - 1);
                        }
                        break;
                    }
                case State.DRAW_PARA:
                    {
                        FirstPoint = e.Location;
                        break;
                    }
                case State.DRAW_ANGLE:
                    {
                        FirstPoint = e.Location;
                        break;
                    }
            }
        }

        private void CanvasBox_MouseUp(object sender, MouseEventArgs e)
        {
            switch (CurrentState)
            {
                case State.DRAW_LINE:
                    {
                        Layers.Add(new Line(FirstPoint, e.Location));
                        UpdateCanvas(Layers.Count - 1);
                        break;
                    }
                case State.DRAW_PARA:
                    {
                        Layers.Add(new Para(FirstPoint, e.Location));
                        UpdateCanvas(Layers.Count - 1);
                        break;
                    }
                case State.DRAW_ANGLE:
                    {
                        Layers.Add(new Angle(FirstPoint, e.Location));
                        UpdateCanvas(Layers.Count - 1);
                        break;
                    }
            }
        }



        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            Layers.Clear();
            LayersList.Items.Clear();
            FullUpdateCanvas();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }


        private void LayersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!CodeSelect)
            {
                SelectedLayer = LayersList.SelectedIndex;
                ChangeState(State.SELECTED);
                if (SelectedLayer < LayersList.Items.Count && SelectedLayer >= 0)
                {
                    FullUpdateCanvas();
                    Layers[SelectedLayer].DrawSelect();
                    CodeSelect = false;
                }
            }
            ChangeState(State.SELECTED);
            //DrawRectangle on selected Layer.
        }


    }
}
