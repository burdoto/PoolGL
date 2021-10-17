using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SharpGL;
using SharpGL.WPF;

namespace PoolGL_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public PoolGame Game;
        
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
            Game = new PoolGame();

            Task.Run(() =>
            {
                try
                {
                    Game.Run();
                }
                catch (Exception e)
                {
                    var str = "Error in Game.Run():\n" + e;
                    Console.WriteLine(str);
                    Debug.WriteLine(str);
                    Application.Current.MainWindow?.Close();
                }
            });
        }

        private void Draw(object sender, OpenGLRoutedEventArgs args)
        {
            var gl = args.OpenGL;

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();

            Game.Draw(gl, Game.Camera);
        }

        private void MouseHandler(object sender, MouseEventArgs e)
        {
        }
    }
}