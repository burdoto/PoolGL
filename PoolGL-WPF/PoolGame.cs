using System.Drawing;
using System.Numerics;
using System.Windows.Input;
using OpenGL_Util;
using OpenGL_Util.Game;
using OpenGL_Util.Model;

namespace PoolGL_WPF
{
    public sealed class PoolGame : GameBase
    {
        public PoolTable Table;
        public PlayBall PlayBall;
        public Player Player;
        public PoolBall[] PoolBalls;
        public override ITransform Camera { get; } = new Singularity(Vector3.UnitZ * -50);

        public PoolGame()
        {
            AddChild(Table = new PoolTable());
            AddChild(PlayBall = new PlayBall(new Singularity(Vector3.UnitX*27)));
            AddChild(Player = new Player(PlayBall, new Singularity(Vector3.UnitX*35)));
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
    }
}