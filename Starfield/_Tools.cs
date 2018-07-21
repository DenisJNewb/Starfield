using System;
using System.Windows.Media;

namespace Starfield
{
    public static class _Tools
    {
        public static CustomCanvas Canvas { get; set; }
        public static Random Random { get; } = new Random();
        public static Pen Pen { get; } = new Pen(Brushes.LightGray, 0.5);
    }
}
