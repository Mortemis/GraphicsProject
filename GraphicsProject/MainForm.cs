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
        public static Graphics G { get; set; }

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



        #region Line

        private List<Point> _points;

        #endregion


        public MainForm()
        {
            InitializeComponent();
            Width = CanvasBox.Width;
            Height = CanvasBox.Height;
            _currentState = State.Wait;
            G = CanvasBox.CreateGraphics();

            _points = new List<Point>();
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

        private void AddPoint(Point point)
        {
            _points.Add(point);
            Figure.PutPoint(point);
        }

        // Maybe replace with mouse click...
        private void CanvasBox_MouseDown(object sender, MouseEventArgs e)
        {
            var location = e.Location;
            switch (_currentState)
            {

                case State.DrawLine:
                    AddPoint(location);
                    if (_points.Count == 2)
                    {
                        _layers.Add(new Line(_points[0],_points[1]));
                        _points.Clear();
                    }
                    break;

                case State.Wait:

                    //TODO Select
                    break;

                case State.Selected:

                    //TODO Enable scale and rotate buttons
                    break;

               
                case State.DrawBezier:

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

        private void CanvasBox_MouseUp(object sender, MouseEventArgs e)
        {
            //switch (_currentState)
            //{
            //    case State.DrawLine:
            //        {
            //            _layers.Add(new Line(_firstPoint, e.Location));
            //            UpdateCanvas(_layers.Count - 1);
            //            break;
            //        }
            //}
        }

        private void RedrawButton_Click(object sender, EventArgs e)
        {
            G.Clear(Color.White);
            FullUpdateCanvas();
        }
    }
}
