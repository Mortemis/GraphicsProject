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
        WAIT, SELECTED, DRAW_LINE, DRAW_BEZIER, DRAW_PARA, DRAW_ANGLE, MOVE, ROTATE
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

        public MainForm()
        {
            InitializeComponent();
            width = CanvasBox.Width;
            height = CanvasBox.Height;
            CurrentState = State.WAIT;
            bmp = new Bitmap(width, height);
            g = Graphics.FromImage(bmp);
        }


        private void UpdateCanvas(int index)
        {
            /*
            for (int i = index; i < Layers.Count; i++)
            {
                Layers[i].Draw();
                LayersList.Items.Add(Layers[i].ToString());
            }
            CanvasBox.Image = bmp;
            */
            FullUpdateCanvas();
        }


        private void FullUpdateCanvas()
        {
            g.Clear(Color.White);
            foreach (Figure figure in Layers)
            {
                figure.Draw();
            }
            CanvasBox.Image = bmp;
        }

        /*
         * Manages status bar.
         */
        private void ManageStatus()
        {
            StatusLabel.Text = CurrentState.ToString();

            //TODO switchcase
        }

        /*
         * Changes current state and manages gui according to state.
         */
        private void ChangeState(State NewState)
        {
            /*
            if (CurrentState == State.SELECTED && NewState != State.SELECTED)
            {
                //SelectedLayer = -1;
                RotateButton.Enabled = false;
                ScaleButton.Enabled = false;
                RemoveButton.Enabled = false;
                //LayersList.ClearSelected();
            }*/


            if (NewState == State.SELECTED && LayersList.SelectedIndex != -1)
            {
                RotateButton.Enabled = true;
                RemoveButton.Enabled = true;

            }
            else
            {
                RotateButton.Enabled = false;
                RemoveButton.Enabled = false;
            }
            CurrentState = NewState;
            ManageStatus();
        }


        private void AddFigure(Figure Figure)
        {
            Layers.Add(Figure);
            LayersList.Items.Add(Figure.ToString());
            FullUpdateCanvas();
        }

        private void SelectFigure()
        {
            if (SelectedLayer < LayersList.Items.Count && SelectedLayer >= 0)
            {
                Layers[SelectedLayer].IsSelected = false;
            }
            SelectedLayer = LayersList.SelectedIndex;
            ChangeState(State.SELECTED);
            if (SelectedLayer < LayersList.Items.Count && SelectedLayer >= 0)
            {
                Layers[SelectedLayer].IsSelected = true;
                FullUpdateCanvas();
                //Layers[SelectedLayer].DrawSelect();
            }
        }


        #region Button events
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
            ChangeState(State.ROTATE);
        }


        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (CurrentState == State.SELECTED && LayersList.SelectedIndex != -1)
            {
                try
                {
                    Layers.RemoveAt(LayersList.SelectedIndex);
                    LayersList.Items.RemoveAt(LayersList.SelectedIndex);
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
        #endregion

        #region Canvas events
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
                        FirstPoint = e.Location;
                        ChangeState(State.MOVE);
                        break;
                    }

                case State.ROTATE:
                    {
                        Layers[SelectedLayer].Rotate(e.Location, (int)RotateNumerical.Value);
                        FullUpdateCanvas();
                        ChangeState(State.SELECTED);
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
                            AddFigure(ActiveBezier);
                            ActiveBezier = new Bezier();
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
                        AddFigure(new Line(FirstPoint, e.Location));
                        break;
                    }
                case State.DRAW_PARA:
                    {
                        AddFigure(new Para(FirstPoint, e.Location));
                        break;
                    }
                case State.DRAW_ANGLE:
                    {
                        AddFigure(new Angle(FirstPoint, e.Location));
                        break;
                    }
                case State.MOVE:
                    {
                        FullUpdateCanvas();
                        ChangeState(State.SELECTED);
                        break;
                    }
            }
        }

        private void CanvasBox_MouseMove(object sender, MouseEventArgs e)
        {
            switch (CurrentState)
            {
                case State.MOVE:
                    {
                        int DeltaX = e.X - FirstPoint.X;
                        int DeltaY = e.Y - FirstPoint.Y;
                        Layers[SelectedLayer].Move(DeltaX, DeltaY);
                        FirstPoint = e.Location;
                        FullUpdateCanvas();
                        break;
                    }
            }
        }
        #endregion

        #region Menu events
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
        #endregion

        #region Other events
        private void LayersList_SelectedIndexChanged(object sender, EventArgs e)
        {

            SelectFigure();
            if (LayersList.SelectedIndex == -1 && CurrentState == State.SELECTED)
            {
                ChangeState(State.WAIT);
            }


            //DrawRectangle on selected Layer.
        }

        private void LayersList_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void RotateNumerical_ValueChanged(object sender, EventArgs e)
        {
            // TODO remove
        }

        #endregion

        private void ScaleNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (CurrentState == State.SELECTED)
            {
                Layers[SelectedLayer].Scale((int)ScaleNumeric.Value);
                FullUpdateCanvas();
            }
        }
    }
}
