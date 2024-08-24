using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Threading;
using System;
using System.Collections.Generic;

namespace Firmware.Views
{
    public partial class MatrixCodeView : UserControl
    {
        private readonly Random _random = new();
        private readonly List<MatrixColumn> _columns = new();
        private DispatcherTimer _animationTimer;

        public MatrixCodeView()
        {
            InitializeComponent();
            this.Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            InitializeMatrixColumns();

            _animationTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(50)
            };
            _animationTimer.Tick += OnAnimationFrame;
            _animationTimer.Start();
        }

        private void InitializeMatrixColumns()
        {
            int columnCount = (int)(MatrixCanvas.Bounds.Width / 20); // Spaltenbreite 20px

            for (int i = 0; i < columnCount; i++)
            {
                var column = new MatrixColumn(_random, i * 20, (int)MatrixCanvas.Bounds.Height);
                _columns.Add(column);
                MatrixCanvas.Children.Add(column.TextBlock);
            }
        }

        private void OnAnimationFrame(object? sender, EventArgs e)
        {
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                foreach (var column in _columns)
                {
                    column.Update();
                }
            });
        }
    }

    public class MatrixColumn
    {
        private readonly Random _random;
        private readonly int _canvasHeight;
        private int _currentPosition;
        private string _characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public TextBlock TextBlock { get; }

        public MatrixColumn(Random random, int xPosition, int canvasHeight)
        {
            _random = random;
            _canvasHeight = canvasHeight;
            _currentPosition = -_random.Next(0, canvasHeight);

            TextBlock = new TextBlock
            {
                FontSize = 16,
                FontFamily = new FontFamily("Consolas"),
                Foreground = Brushes.LightGreen,
                Text = GenerateRandomCharacter().ToString(),
                RenderTransform = new TranslateTransform(xPosition, _currentPosition)
            };
        }

        public void Update()
        {
            _currentPosition += 16;

            if (_currentPosition > _canvasHeight)
            {
                _currentPosition = -16; // Zurücksetzen auf den Anfang
            }

            TextBlock.Text = GenerateRandomCharacter().ToString();
            ((TranslateTransform)TextBlock.RenderTransform).Y = _currentPosition;
        }

        private char GenerateRandomCharacter()
        {
            int index = _random.Next(_characters.Length);
            return _characters[index];
        }
    }
}
