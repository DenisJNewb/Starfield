using System;
using System.Windows;
using System.Windows.Media;

namespace Starfield
{
    public class Star : DrawingVisual
    {
        private Point startPosition;
        private Point drawPoint;

        private double spaceWidth;

        public Star()
        {
            SetNewParams();

            _Tools.Canvas.AddVObject(this);
        }

        public void Update()
        {
            if (spaceWidth < Math.Abs(startPosition.X)
                || spaceWidth < Math.Abs(startPosition.Y))
            {
                SetNewParams();
            }
            else
            {
                var sx = (startPosition.X / spaceWidth).Map(0, 1, 0, _Tools.Canvas.Width / 2);
                var sy = (startPosition.Y / spaceWidth).Map(0, 1, 0, _Tools.Canvas.Height / 2);
                drawPoint = new Point(sx, sy);
                spaceWidth -= 1;
            }
        }

        public void Show()
        {
            using (var render = RenderOpen())
            {
                var translate = new TranslateTransform(_Tools.Canvas.Width / 2, _Tools.Canvas.Height / 2);
                render.PushTransform(translate);

                render.DrawLine(_Tools.Pen, startPosition, drawPoint);

                var starWidth = spaceWidth.Map(0, _Tools.Canvas.Width / 2, 5, 1);
                
                render.DrawEllipse(Brushes.White,
                    null,
                    drawPoint,
                    starWidth, starWidth);
            }
        }

        private void SetNewParams()
        {
            spaceWidth = _Tools.Random.Next((int)(_Tools.Canvas.Width / 4), (int)(_Tools.Canvas.Width / 2));

            startPosition = new Point(
                _Tools.Random.Next(-(int)_Tools.Canvas.Width / 2, (int)_Tools.Canvas.Width / 2),
                _Tools.Random.Next(-(int)_Tools.Canvas.Height / 2, (int)_Tools.Canvas.Height / 2));

            drawPoint = startPosition;
        }
    }
}