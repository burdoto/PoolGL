using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
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
using SharpGL.SceneGraph.Raytracing;
using SharpGL.WPF;

namespace PoolGL_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static PoolGame Game;
        
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
        
        public static OpenGL GL { get; private set; }

        private void Initialize(object sender, OpenGLRoutedEventArgs args) => GL = args.OpenGL;

        private void Draw(object sender, OpenGLRoutedEventArgs args)
        {
            var gl = args.OpenGL;

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();
            Game.Draw(gl, Game.Camera);

            gl.Flush();
        }

        private void MouseHandler(object sender, MouseEventArgs e)
        {
            var pos = Mouse.GetPosition(null);
            var proj = GL.UnProject(pos.X, pos.Y, 1);
            Game.MousePosition = new Vector2((float)proj[0], (float)proj[1]);
        }

        private void ClickHandler(object sender, MouseButtonEventArgs e)
        {
            Game.Shoot(10);
        }
    }
}