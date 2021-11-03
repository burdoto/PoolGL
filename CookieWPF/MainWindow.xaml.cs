using System;
using System.Collections.Generic;
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

namespace CookieWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow instance;
        public static CookieGame Game;
        
        public MainWindow()
        {
            DataContext = instance = this;
            InitializeComponent();
        }

        private void Initialize(object sender, OpenGLRoutedEventArgs args)
        {
            Game = new CookieGame(this);
            Game.Stats = new CookieStats();
        }

        private void Draw(object sender, OpenGLRoutedEventArgs args)
        {
            var gl = args.OpenGL;

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();
            Game.Draw(gl, Game.Camera);

            gl.Flush();
        }

        private void ClickHandler(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BuyAutoClick(object sender, RoutedEventArgs e) => Game.BuyAutoClicker();

        private void BuyClickBoost(object sender, RoutedEventArgs e) => Game.BuyClickBooster();
    }
}