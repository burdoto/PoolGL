using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using System.Windows.Input;
using OpenGL_Util;
using OpenGL_Util.Game;
using OpenGL_Util.Model;
using OpenGL_Util.Physics;
using Point = System.Windows.Point;

namespace PoolGL_WPF
{
    public sealed class PoolGame : GameBase
    {
        public PoolTable Table;
        public PlayBall PlayBall;
        public Player Player;
        public PoolBall[] PoolBalls;
        public override ITransform Camera { get; } = new Singularity(Vector3.UnitZ * 50);
        public Vector2 MousePosition { get; internal set; }

        public PoolGame()
        {
            AddChild(Table = new PoolTable());
            AddChild(PlayBall = new PlayBall(new Singularity(Vector3.UnitX*-27)));
            AddChild(new PoolBall(new Singularity(Vector3.UnitX*-13), 1));
            AddChild(new PoolBall(new Singularity(Vector3.UnitY*6), 2));
            AddChild(Player = new Player(PlayBall, new Singularity()));
        }

        protected override bool _Load()
        {
            BaseTickTime = 2000;
            return base._Load();
        }

        protected override bool _Enable()
        {
            return base._Enable();
        }

        protected override void _Disable()
        {
            base._Disable();
        }

        public void Shoot(float strength)
        {
            var impact = Vector3.Normalize(PlayBall.Position - new Vector3(MousePosition, 0)) * strength;
            Debug.WriteLine("Impact force: " + impact);
            (PlayBall.PhysicsObject as PhysicsObject)!.Velocity = impact * new Vector3(1,-1,0);
        }
    }
}