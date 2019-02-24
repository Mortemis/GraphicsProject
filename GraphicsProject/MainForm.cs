using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Expander;
using GraphicsProject.Figures;


namespace GraphicsProject
{
    public partial class MainForm : Form
    {
        public static Graphics G;

        public static int CanvasWidth;
        public static int CanvasHeight;

        public static Pen DrawPen = new Pen(Color.Black, 1);
        private readonly Bitmap _bitmap;

        private State _currentState;

        private Point _lastLocation;        

        private List<PointF> _points;
        private readonly ObservableCollection<Figure> _figures;
        private Figure _selectedFigure;
        private Figure _secondSelectedFigure;
        private bool _isFigureSelected;

        public MainForm()
        {
            InitializeComponent();
            CanvasWidth = CanvasBox.Width;
            CanvasHeight = CanvasBox.Height;
            _currentState = State.Wait;

            anglesCounter.Maximum = 20;
            anglesCounter.Minimum = 3;

            _bitmap = new Bitmap(CanvasWidth, CanvasHeight);
            G = Graphics.FromImage(_bitmap);

            _points = new List<PointF>();
            _figures = new ObservableCollection<Figure>();
            _figures.CollectionChanged += (sender, args) =>
            {
                if (args.NewItems.Count != 0) _points = new List<PointF>();
            };
        }

        #region Choose primitive

        private void btnLine_Click(object sender, EventArgs e)
        {
            _currentState = State.DrawLine;
        }

        private void btnTgp_Click(object sender, EventArgs e)
        {
            _currentState = State.Tgp;
        }

        private void btnCubicSpline_Click(object sender, EventArgs e)
        {
            _currentState = State.CubicSpline;
        }

        private void btnPgn_Click(object sender, EventArgs e)
        {
            _currentState = State.Pgn;
        }

        #endregion

        #region Choose operation

        private void btnMove_Click(object sender, EventArgs e)
        {
            _currentState = State.Move;
        }

        private void btnRotate_Click(object sender, EventArgs e)
        {
            _currentState = State.Rotate;
        }

        private void btnMirror_Click(object sender, EventArgs e)
        {
            _currentState = State.HorMirror;
        }



        #endregion

        #region Canvas mouse click

        private void CanvasBox_MouseDown(object sender, MouseEventArgs e)
        {
            _lastLocation = e.Location;

            switch (_currentState)
            {
                case State.DrawLine:
                    AddPoint(_lastLocation);
                    if (_points.Count == 2)
                        _figures.Add(new Line(_points));
                    break;

                case State.Tgp:
                    _figures.Add(new Tgp(_lastLocation));
                    break;

                case State.Pgn:
                    AddPoint(_lastLocation);
                    if (_points.Count == 2)
                        _figures.Add(new Pgn(_points, (int) anglesCounter.Value));
                    break;

                case State.CubicSpline:
                    AddPoint(_lastLocation);
                    switch (_points.Count)
                    {
                        case 2:
                            G.DrawLine(DrawPen, _points[0], _points[1]);
                            break;
                        case 4:
                            G.DrawLine(DrawPen, _points[2], _points[3]);
                            _figures.Add(new CubicSpline(_points));
                            break;
                    }

                    break;

                case State.Move:
                    _selectedFigure = _figures.SingleOrDefault(fig => fig.IsSelected(_lastLocation.X, _lastLocation.Y));
                    _isFigureSelected = _selectedFigure != null;
                    break;

                case State.Rotate:
                     _selectedFigure = _figures.SingleOrDefault(fig => fig.IsSelected(_lastLocation.X, _lastLocation.Y));
                    _isFigureSelected = _selectedFigure != null;
                     if ((e.Button & MouseButtons.Right) != 0)
                     {
                         _selectedFigure?.Rotate(_lastLocation, (int) angleRotate.Value);
                         G.Clear(CanvasBox.BackColor);
                         foreach (var figure in _figures)
                             figure?.Draw();
                     }

                     break;

                case State.HorMirror:
                    if ((e.Button & MouseButtons.Left) != 0)
                    {
                        _selectedFigure =
                            _figures.SingleOrDefault(fig => fig.IsSelected(_lastLocation.X, _lastLocation.Y));
                        _isFigureSelected = _selectedFigure != null;

                    }

                    if ((e.Button & MouseButtons.Right) != 0)
                    {
                        AddPoint(_lastLocation);
                        if (_points.Count == 2)
                        {
                            _selectedFigure?.Mirror(_points[0],_points[1]);
                            new Line(_points);
                            _points = new List<PointF>();
                        }

                        G.Clear(CanvasBox.BackColor);
                        foreach (var figure in _figures)
                            figure?.Draw();
                    }
                   
                    break;

                case State.TmoUnion:
                case State.TmoIntersection:
                    _figures.Add(new Tmo(_selectedFigure,_secondSelectedFigure,_currentState));
                    G.Clear(CanvasBox.BackColor);
                    _figures[2].Draw();
                    break;
            }

            CanvasBox.Image = _bitmap;
        }

        private void CanvasBox_MouseMove(object sender, MouseEventArgs e)
        {
            if(!_isFigureSelected) return;
            switch (_currentState)
            {
                case State.Move:
                    _selectedFigure?.Move(e.X - _lastLocation.X,e.Y - _lastLocation.Y);
                    G.Clear(CanvasBox.BackColor);
                    foreach (var figure in _figures)                    
                       figure.Draw();
                    

                    
                    break;
            }

            _lastLocation = e.Location;
            CanvasBox.Image = _bitmap;
        }


        private void CanvasBox_MouseUp(object sender, MouseEventArgs e)
        {
            _isFigureSelected = false;
        }

        #endregion

        #region Private utils(ne dlya udobvstva)

        private void AddPoint(PointF point)
        {
            Figure.PutPoint(point);
            _points.Add(point);
        }





        #endregion

        private void btnTmoUnion_Click(object sender, EventArgs e)
        {
            _currentState = State.TmoUnion;
            _selectedFigure = _figures[0];
            _secondSelectedFigure = _figures[1];
        }

        private void btnTmoIntersection_Click(object sender, EventArgs e)
        {
            _currentState = State.TmoIntersection;
        }
    }
}