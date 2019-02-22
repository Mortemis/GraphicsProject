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
 * Figures: Bezier +, parallelogram, angle 2
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
        Wait, Selected, DrawLine, DrawBezier, DrawPara, DrawAngle, Scale
    }

    public partial class MainForm : Form
    {
        //Не очень хочу передавать это как параметр в метод PutPoint класса Figure через каждый метод Draw, поэтому делаю статическим.
        //Надеюсь, это не страшно, но если вдруг страшно, то 
        //TODO Исправь, если страшно или убери этот кусок комментов, если не очень страшно.
        public static Graphics G;

        //TODO Width and height change on window resize.
        //HACK Fix me please, i am a mistake.
        public static int Width;
        public static int Height;
        public static Pen DrawPen = new Pen(Color.Black, 1);
        private State _currentState;

        private Point _firstPoint;
        Bezier _activeBezier;

        // TODO layers
        // Идея слоистости - есть лист абстрактного класса Figure, в котором есть метод Draw. 
        // Добавляем в него фигурки, наследующие его, и при любом апдейте просто вызываем метод Draw для всего листа.
        // Может быть, стоит повесить в юи список, чтобы выбирать фигуры можно было и через этот список. 
        // TODO Немного лагает, стоит сделать ограничение по количеству фигур или делать только частичную перерисовку и перерисовывать полностью только если это действительно нужно.
        List<Figure> _layers = new List<Figure>();


        public MainForm()
        {
            InitializeComponent();
            Width = CanvasBox.Width;
            Height = CanvasBox.Height;
            _currentState = State.Wait;
            G = CanvasBox.CreateGraphics();
        }

        // Update from index to end. Fix.
        private void UpdateCanvas(int index)
        {
            for (int i = index; i < _layers.Count; i++)
            {
                _layers[i].Draw();
            }
        }

        private void FullUpdateCanvas()
        {
            foreach (Figure figure in _layers)
            {
                figure.Draw();
            }
        }

        private void LineButton_Click(object sender, EventArgs e)
        {
            _currentState = State.DrawLine;
        }

        private void BezierButton_Click(object sender, EventArgs e)
        {
            _currentState = State.DrawBezier;
            _activeBezier = new Bezier();
        }


        // Maybe replace with mouse click...
        private void CanvasBox_MouseDown(object sender, MouseEventArgs e)
        {
            switch (_currentState)
            {
                case State.Wait:
                    {
                        //TODO Select
                        break;
                    }
                case State.Selected:
                    {
                        //TODO Enable scale and rotate buttons
                        break;
                    }
                case State.DrawLine:
                    {
                        _firstPoint = e.Location;
                        break;
                    }
                case State.DrawBezier:
                    {
                        _activeBezier.AddPoint(e.Location);
                        if (e.Button == MouseButtons.Right)
                        {
                            _activeBezier.Finish();
                            _layers.Add(_activeBezier);
                            _activeBezier = new Bezier();
                            UpdateCanvas(_layers.Count - 1);
                        }
                        break;
                    }
            }
        }

        private void CanvasBox_MouseUp(object sender, MouseEventArgs e)
        {
            switch (_currentState)
            {
                case State.DrawLine:
                    {
                        _layers.Add(new Line(_firstPoint, e.Location));
                        UpdateCanvas(_layers.Count - 1);
                        break;
                    }
            }
        }

        private void RedrawButton_Click(object sender, EventArgs e)
        {
            G.Clear(Color.White);
            FullUpdateCanvas();
        }
    }
}
