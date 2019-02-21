using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/*
 * Var 37. 
 * Figures: Bezier, parallelogram, angle 2
 * Also straight line
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
        //Не очень хочу передавать это как параметр в метод PutPoint класса Figure через каждый метод Draw, поэтому делаю статическим.
        //Надеюсь, это не страшно, но если вдруг страшно, то 
        //TODO Исправь, если страшно или убери этот кусок комментов, если не очень страшно.
        public static Graphics g;

        //TODO Width and height change on window resize.
        //HACK Fix me please, i am a mistake.
        public static int width;
        public static int height;
        public static Pen DrawPen = new Pen(Color.Black, 1);
        private State CurrentState;

        private Point FirstPoint;
        Bezier ActiveBezier;

        // TODO layers
        // Идея слоистости - есть лист абстрактного класса Figure, в котором есть метод Draw. 
        // Добавляем в него фигурки, наследующие его, и при любом апдейте просто вызываем метод Draw для всего листа.
        // Может быть, стоит повесить в юи список, чтобы выбирать фигуры можно было и через этот список. 
        // TODO Немного лагает, стоит сделать ограничение по количеству фигур или делать только частичную перерисовку и перерисовывать полностью только если это действительно нужно.
        List<Figure> Layers = new List<Figure>();


        public MainForm()
        {
            InitializeComponent();
            Bezier.InitFactorials(); //Init an array with i! 
            width = CanvasBox.Width;
            height = CanvasBox.Height;
            CurrentState = State.WAIT;
            g = CanvasBox.CreateGraphics();
        }

        // Update from index to end. Fix.
        private void UpdateCanvas(int index)
        {
            for (int i = index; i < Layers.Count; i++)
            {
                Layers[i].Draw();
            }
        }

        private void FullUpdateCanvas()
        {
            foreach (Figure figure in Layers)
            {
                figure.Draw();
            }
        }

        private void LineButton_Click(object sender, EventArgs e)
        {
            CurrentState = State.DRAW_LINE;
        }

        private void BezierButton_Click(object sender, EventArgs e)
        {
            CurrentState = State.DRAW_BEZIER;
            ActiveBezier = new Bezier();
        }


        // Maybe replace with mouse click...
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
                        //TODO Enable scale and rotate buttons
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
            }
        }

        private void RedrawButton_Click(object sender, EventArgs e)
        {
            FullUpdateCanvas();
            g.Clear(Color.White);
        }
    }
}
