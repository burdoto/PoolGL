using System.Numerics;
using System.Windows;
using System.Windows.Media;

namespace PoolGL_WPF
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
    }

    public static class Extensions
    {
        public static float[] Array(this Color c)
        {
            return new[] { c.ScR, c.ScG, c.ScB, c.ScA };
        }

        public static Vector2 Vector(this Point a)
        {
            return new Vector2((float)a.X, (float)a.Y);
        }
    }
}