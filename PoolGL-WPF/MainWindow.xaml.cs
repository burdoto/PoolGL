using System;
using System.Diagnostics;
using System.Numerics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using OGLU;
using OGLU.Game;
using SharpGL;
using SharpGL.Enumerations;
using SharpGL.SceneGraph;
using SharpGL.WPF;

namespace PoolGL_WPF
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Instance;
        public static PoolGame Game;
        public Vector2 Viewport;
        public float Aspect;

        public MainWindow()
        {
            DataContext = Instance = this;
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
                    string str = "Error in Game.Run():\n" + e;
                    Console.WriteLine(str);
                    Debug.WriteLine(str);
                    Application.Current.MainWindow?.Close();
                }
            });
        }

        public static OpenGL GL { get; private set; }

        private void Initialize(object sender, OpenGLRoutedEventArgs args)
        {
            GL = args.OpenGL;
        }

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
            Game.MousePosition = UnprojectMouse2D(GL, pos.Vector());
        }

        private void ClickHandler(object sender, MouseButtonEventArgs e)
        {
            Game.Shoot(10);
        }

        private Vector2 UnprojectMouse2D(OpenGL gl, Vector2 mouse)
        {
            int[] arr = new int[4];
            gl.GetInteger(OpenGL.GL_VIEWPORT, arr);
            Viewport = new Vector2(arr[2], arr[3]);
            Aspect = Viewport.X / Viewport.Y;
            const int glH = 40; // probably wrong on other machines lmao
            var glDim = new Vector2(glH * Aspect, glH);
            var vec = mouse / Viewport * glDim + Game.Camera.Position.Vector2();
            return vec;
        }
    }
}