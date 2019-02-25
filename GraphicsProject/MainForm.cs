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

        private readonly IList<Figure> _selectedFigures;
        private bool _isDrawMode;


        public MainForm()
        {
            InitializeComponent();
            KeyPreview = true;
            CanvasWidth = CanvasBox.Width;
            CanvasHeight = CanvasBox.Height;

            angleRotate.Value = 45;

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

            _selectedFigures.Clear();
            RedrawAll();
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
                    _currentState = State.VertMirror;
                    break;
                case NamesUtils.TmoUnion:
                    _currentState = State.TmoUnion;
                    break;
                case NamesUtils.TmoIntersection:
                    _currentState = State.TmoIntersection;
                    break;
            }

            _selectedFigures.Clear();
            RedrawAll();
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
                        {
                            _figures.Add(new Pgn(_points, (int) anglesCounter.Value));
                            RedrawAll();
                        }

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
                                RedrawAll();
                                break;
                        }

                        break;
                }
            }

            // преобразование
            if (!_isDrawMode)
            {
                // лкм - выделение фигуры
                if (e.Button == MouseButtons.Left)
                {
                    var selectedFigure =
                        _figures.FirstOrDefault(fig => fig.IsSelected(_lastLocation.X, _lastLocation.Y));

                    if (selectedFigure != null)
                    {
                        if (_currentState == State.TmoUnion || _currentState == State.TmoIntersection)
                        {
                            _selectedFigures.Add(selectedFigure);
                        }
                        else
                        {
                            _selectedFigures.Clear();
                            _selectedFigures.Add(selectedFigure);
                        }
                    }
                    else _selectedFigures.Clear();

                    RedrawAll();
                    DrawBorders();
                }

                // задание центра для поворота,линии для отражения,перемещение - пкм
                if (e.Button == MouseButtons.Right)
                {
                    switch (_currentState)
                    {
                        case State.Rotate:
                            _selectedFigures.FirstOrDefault()?.Rotate(_lastLocation, (int) angleRotate.Value);
                            RedrawAll();
                            break;

                        case State.VertMirror:
                        case State.HorMirror:
                            AddPoint(_lastLocation);
                            if (_points.Count == 2)
                            {
                                _selectedFigures.FirstOrDefault()?.Mirror(_points[0], _points[1]);
                                new Line(_points);
                                _points = new List<PointF>();
                                RedrawAll();
                            }

                            break;
                        case State.TmoUnion:
                        case State.TmoIntersection:
                            if (_selectedFigures.Count == 2)
                            {
                                if (_selectedFigures.Any(figure => figure is CubicSpline || figure is Line)) return;

                                var tmo = new Tmo(_selectedFigures[0], _selectedFigures[1], _currentState);
                                _figures.Add(tmo);
                                tmo.Draw();

                                foreach (var selectedFigure in _selectedFigures)
                                    _figures.Remove(selectedFigure);

                                _selectedFigures.Clear();
                                _selectedFigures.Add(tmo);

                                DrawBorders();
                                RedrawAll();
                            }

                            break;
                    }
                }
            }

            CanvasBox.Image = _bitmap;
        }

        private void CanvasBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (_selectedFigures.Count == 0) return;
            switch (_currentState)
            {
                case State.Move:
                    _selectedFigures.FirstOrDefault()?.Move(e.X - _lastLocation.X, e.Y - _lastLocation.Y);
                    RedrawAll();
                    break;

                case State.HorMirror:
                    RedrawAll();
                    if (_points.Count == 0)
                        G.DrawLine(DrawPenUtils.DrawPenRed, new Point(e.X, e.Y), new Point(CanvasWidth, e.Y));

                    if (_points.Count == 1)
                        G.DrawLine(DrawPenUtils.DrawPenRed, _points[0],
                            new Point(e.X, (int) Math.Round(Convert.ToDouble(_points[0].Y))));
                    break;

                case State.VertMirror:
                    RedrawAll();
                    if (_points.Count == 0)
                        G.DrawLine(DrawPenUtils.DrawPenRed, new Point(e.X, e.Y), new Point(e.X, CanvasHeight));

                    if (_points.Count == 1)
                        G.DrawLine(DrawPenUtils.DrawPenRed, _points[0],
                            new Point((int) Math.Round(Convert.ToDouble(_points[0].X)), e.Y));
                    break;
            }

            _lastLocation = e.Location;
        }

        private void CanvasBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (_currentState == State.Move)
                _selectedFigures.Clear();
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

            DrawBorders();
            CanvasBox.Image = _bitmap;
        }

        private void DrawBorders()
        {
            foreach (var figure in _selectedFigures)
            {
                var points = figure.GetNewPoints();
                if (points == null) return;
                if (figure is Polygon || figure is CubicSpline)
                {
                    var leftX = points.Min(point => point.X) - 2;
                    var rightX = points.Max(point => point.X) + 2;
                    var upY = points.Min(point => point.Y) - 2;
                    var downY = points.Max(point => point.Y) + 2;

                    G.DrawLine(DrawPenUtils.DrawPenGreen, leftX, upY, rightX, upY);
                    G.DrawLine(DrawPenUtils.DrawPenGreen, leftX, downY, rightX, downY);

                    G.DrawLine(DrawPenUtils.DrawPenGreen, rightX, downY, rightX, upY);
                    G.DrawLine(DrawPenUtils.DrawPenGreen, leftX, downY, leftX, upY);
                }

                if (figure is Tmo tmo)
                {
                    var borderPoints = tmo.GetBorderPoints();

                    G.DrawLine(DrawPenUtils.DrawPenGreen, borderPoints[0], borderPoints[1]);
                    G.DrawLine(DrawPenUtils.DrawPenGreen, borderPoints[1], borderPoints[2]);
                    G.DrawLine(DrawPenUtils.DrawPenGreen, borderPoints[2], borderPoints[3]);
                    G.DrawLine(DrawPenUtils.DrawPenGreen, borderPoints[3], borderPoints[0]);
                }

                if (figure is Line line)
                {
                    var borderPoints = line.GetBorderPoints();

                    G.DrawLine(DrawPenUtils.DrawPenGreen, borderPoints[0], borderPoints[1]);
                    G.DrawLine(DrawPenUtils.DrawPenGreen, borderPoints[1], borderPoints[2]);
                    G.DrawLine(DrawPenUtils.DrawPenGreen, borderPoints[2], borderPoints[3]);
                    G.DrawLine(DrawPenUtils.DrawPenGreen, borderPoints[3], borderPoints[0]);
                }
            }
        }

        #endregion
    }
}