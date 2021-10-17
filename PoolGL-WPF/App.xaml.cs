using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
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
    }
}