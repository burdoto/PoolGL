using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace PoolGL_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
    }

    public static class Extensions
    {
        public static float[] Array(this Color c) => new float[] {c.ScR,c.ScG,c.ScB,c.ScA};

        public static Vector2 Vector(this Point a) => new Vector2((float)a.X, (float)a.Y);
    }
}