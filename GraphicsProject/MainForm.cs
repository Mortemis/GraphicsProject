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
        private ObservableCollection<Figure> _figures;

        private readonly IList<Figure> _selectedFigures;
        private bool _isDrawMode;


        public MainForm()
        {
            InitializeComponent();
            KeyPreview = true;
            CanvasWidth = CanvasBox.Width;
            CanvasHeight = CanvasBox.Height;

            cmbMirror.SelectedIndex = 0;
            angleRotate.Value = 45;

            _bitmap = new Bitmap(CanvasWidth, CanvasHeight);
            G = Graphics.FromImage(_bitmap);

            cmbColor.SelectedIndex = 0;

            _selectedFigures = new List<Figure>();
            _points = new List<PointF>();
            _figures = new ObservableCollection<Figure>();
            _figures.CollectionChanged += (sender, args) =>
            {
                if (args.NewItems?.Count != 0)
                {
                    _points = new List<PointF>();
                }
            };
        }

        #region Choose primitive

        private void ChoosePrimitive(object sender, EventArgs e)
        {
            _selectedFigures.Clear();
            RedrawAll();
            _isDrawMode = true;

            cmbMirror.Enabled = false;
            anglesCounter.Enabled = false;
            angleRotate.Enabled = false;

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
                    anglesCounter.Enabled = true;
                    return;
                case NamesUtils.Tgp:
                    _currentState = State.Tgp;
                    break;
            }
        }

        #endregion

        #region Choose operation

        private void ChooseOperation(object sender, EventArgs e)
        {
            _selectedFigures.Clear();
            RedrawAll();
            _isDrawMode = false;

            cmbMirror.Enabled = false;
            anglesCounter.Enabled = false;
            angleRotate.Enabled = false;

            var button = sender as Button;
            var text = button?.Text;
            switch (text)
            {
                case NamesUtils.Move:
                    _currentState = State.Move;
                    break;
                case NamesUtils.Rotate:
                    _currentState = State.Rotate;
                    angleRotate.Enabled = true;
                    break;
                case NamesUtils.Mirror:
                    _currentState = cmbMirror.SelectedIndex == 0 ? State.HorMirror : State.VertMirror;
                    cmbMirror.Enabled = true;
                    break;
                case NamesUtils.TmoUnion:
                    _currentState = State.TmoUnion;
                    break;
                case NamesUtils.TmoIntersection:
                    _currentState = State.TmoIntersection;
                    break;
                case NamesUtils.DeleteItem:
                    _currentState = State.DeleteItem;
                    break;
            }
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
                        RedrawAll();
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
                                _figures.Add(new ErLine(_points));
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
                }

                // задание центра для поворота,линии для отражения,перемещение,удаление - пкм
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
                            _selectedFigures.FirstOrDefault()?.Mirror(_lastLocation, _currentState);
                            RedrawAll();
                            break;
                        case State.TmoUnion:
                        case State.TmoIntersection:
                            if (_selectedFigures.Count == 2)
                            {
                                if (_selectedFigures.Any(figure => figure is ErLine || figure is Line)) return;

                                var tmo = new Tmo(_selectedFigures[0], _selectedFigures[1], _currentState);
                                _figures.Add(tmo);
                                tmo.Draw();

                                foreach (var selectedFigure in _selectedFigures)
                                    _figures.Remove(selectedFigure);

                                _selectedFigures.Clear();
                                _selectedFigures.Add(tmo);

                                RedrawAll();
                            }

                            break;
                        case State.DeleteItem:
                            _figures = new ObservableCollection<Figure>(_figures.Except(_selectedFigures));
                            _selectedFigures.Clear();
                            RedrawAll();
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
                    _lastLocation = e.Location;
                    break;

                case State.HorMirror:
                    RedrawAll();
                    if (_points.Count == 0)
                        G.DrawLine(DrawPenUtils.DrawPenRed, new Point(e.X, e.Y), new Point(CanvasWidth, e.Y));
                    break;

                case State.VertMirror:
                    RedrawAll();
                    if (_points.Count == 0)
                        G.DrawLine(DrawPenUtils.DrawPenRed, new Point(e.X, e.Y), new Point(e.X, CanvasHeight));
                    break;
            }
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


        private void cmbMirror_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbMirror.SelectedIndex)
            {
                case 0:
                    _currentState = State.HorMirror;
                    break;
                case 1:
                    _currentState = State.VertMirror;
                    break;
            }
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
                var borderPoints = figure.GetBorderPoints();
                DrawBorder(borderPoints);
            }
        }

        private void DrawBorder(IList<PointF> points)
        {
            for (int i = 0; i < points.Count - 1; i++)
            {
                G.DrawLine(DrawPenUtils.DrawPenGreen, points[i], points[i + 1]);
            }

            G.DrawLine(DrawPenUtils.DrawPenGreen, points.Last(), points.First());
        }

        private void DeleteSelectedItem()
        {
            _figures = new ObservableCollection<Figure>(_figures.Except(_selectedFigures));
            RedrawAll();
        }

        #endregion

        #region Pallet events

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbColor.SelectedIndex)
            {
                case 0:
                    Figure.DrawPenStatic = DrawPenUtils.DrawPenBlack;
                    break;
                case 1:
                    Figure.DrawPenStatic = DrawPenUtils.DrawPenPink;
                    break;
                case 2:
                    Figure.DrawPenStatic = DrawPenUtils.DrawPenOrange;
                    break;
                case 3:
                    Figure.DrawPenStatic = DrawPenUtils.DrawPenBlue;
                    break;
                case 4:
                    Figure.DrawPenStatic = DrawPenUtils.DrawPenYellow;
                    break;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            G.Clear(CanvasBox.BackColor);
            _figures.Clear();
            _points.Clear();
            CanvasBox.Image = _bitmap;
        }

        #endregion
    }
}