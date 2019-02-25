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
using GraphicsProject.Utils;


namespace GraphicsProject
{
    public partial class MainForm : Form
    {
        public static Graphics G;

        public static int CanvasWidth;
        public static int CanvasHeight;

        public static Pen DrawPen = DrawPenUtils.DrawPenBlack;
        private readonly Bitmap _bitmap;

        private State _currentState;

        private Point _lastLocation;

        private IList<PointF> _points;
        private readonly ObservableCollection<Figure> _figures;

        private IList<Figure> _selectedFigures;
        private bool _isDrawMode;
        private bool _isMultiSelectMode;

        private Figure _selectedFigure;
        private Figure _secondSelectedFigure;
        private bool _isFigureSelected;

        public MainForm()
        {
            InitializeComponent();
            CanvasWidth = CanvasBox.Width;
            CanvasHeight = CanvasBox.Height;            

            anglesCounter.Maximum = 20;
            anglesCounter.Minimum = 3;

            _bitmap = new Bitmap(CanvasWidth, CanvasHeight);
            G = Graphics.FromImage(_bitmap);

            _selectedFigures = new List<Figure>();
            _points = new List<PointF>();
            _figures = new ObservableCollection<Figure>();
            _figures.CollectionChanged += (sender, args) =>
            {
                if (args.NewItems?.Count != 0) _points = new List<PointF>();
            };
        }

        #region Choose primitive

        private void ChoosePrimitive(object sender, EventArgs e)
        {
            var button = sender as Button;
            var text = button?.Text;
            switch (text)
            {
                case NamesUtils.Line:
                    _currentState = State.DrawLine;
                    break;
                case NamesUtils.CubicSpline:
                    _currentState = State.CubicSpline;
                    break;
                case NamesUtils.Pgn:
                    _currentState = State.Pgn;
                    break;
                case NamesUtils.Tgp:
                    _currentState = State.Tgp;
                    break;
            }

            _isDrawMode = true;
        }

        #endregion

        #region Choose operation

        private void ChooseOperation(object sender, EventArgs e)
        {
            var button = sender as Button;
            var text = button?.Text;
            switch (text)
            {
                case NamesUtils.Move:
                    _currentState = State.Move;
                    break;
                case NamesUtils.Rotate:
                    _currentState = State.Rotate;
                    break;
                case NamesUtils.Mirror:
                    _currentState = State.HorMirror;
                    break;
                case NamesUtils.TmoUnion:                  
                case NamesUtils.TmoIntersection:
                    _currentState = State.TmoIntersection;
                    if (_selectedFigures?.Count > 1)
                    {
                        _figures.Add(new Tmo(_selectedFigures[0], _selectedFigures[1], _currentState));
                        foreach (var selectedFigure in _selectedFigures)
                        {
                            _figures.Remove(selectedFigure);
                        }
                        RedrawAll();
                    }
                    break;
            }

            _isDrawMode = false;
        }

        #endregion

        #region Canvas mouse click

        private void CanvasBox_MouseDown(object sender, MouseEventArgs e)
        {
            _lastLocation = e.Location;

            // рисуем фигуры
            if (_isDrawMode)
            {
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
                }
            }

            // преобразование
            if (!_isDrawMode)
            {
                // лкм - выделение одной фигуры
                if (e.Button == MouseButtons.Left)
                {
                    _selectedFigure =
                        _figures.FirstOrDefault(fig => fig.IsSelected(_lastLocation.X, _lastLocation.Y));
                    _isFigureSelected = _selectedFigure != null;
                }

                //ctrl + lcm = выделение двух фигур
                if (e.Button == MouseButtons.Left)
                {
                    _selectedFigures.Add(_figures.First(fig => fig.IsSelected(_lastLocation.X, _lastLocation.Y)));
                }

                // задание центра для поворота,линии для отражения,перемещение - пкм
                if (e.Button == MouseButtons.Right)
                {
                    switch (_currentState)
                    {
                        case State.Move:
                            _selectedFigure =
                                _figures.FirstOrDefault(fig => fig.IsSelected(_lastLocation.X, _lastLocation.Y));
                            _isFigureSelected = _selectedFigure != null;
                            break;

                        case State.Rotate:
                            _selectedFigure?.Rotate(_lastLocation, (int) angleRotate.Value);
                            break;

                        case State.HorMirror:
                            AddPoint(_lastLocation);
                            if (_points.Count == 2)
                            {
                                _selectedFigure?.Mirror(_points[0], _points[1]);
                                new Line(_points);
                                _points = new List<PointF>();
                            }

                            break;
                    }
                }
            }

            RedrawAll();
        }

        private void CanvasBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isFigureSelected) return;
            switch (_currentState)
            {
                case State.Move:
                    _selectedFigure?.Move(e.X - _lastLocation.X, e.Y - _lastLocation.Y);
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

        #region Private utils

        private void AddPoint(PointF point)
        {
            Figure.PutPoint(point);
            _points.Add(point);
        }

        private void ClearCanvas()
        {
            G.Clear(CanvasBox.BackColor);
            _figures.Clear();
            _points.Clear();
            CanvasBox.Image = _bitmap;
        }

        private void RedrawAll()
        {
            G.Clear(CanvasBox.BackColor);
            foreach (var figure in _figures)
            {
                figure.Draw();
            }

            CanvasBox.Image = _bitmap;
        }

        #endregion

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
                _isMultiSelectMode = true;
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control)
                _isMultiSelectMode = false;
        }
    }
}