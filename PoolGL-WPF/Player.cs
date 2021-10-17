using System.Drawing;
using System.Numerics;
using OpenGL_Util;
using OpenGL_Util.Model;
using OpenGL_Util.Shape3;
using SharpGL;

namespace PoolGL_WPF
{
    public class Player : AbstractGameObject
    {
        public PlayBall PlayBall { get; }
        public static readonly Vector3 PlayerCubeOffset = new Vector3(0f, -9f, 0f);
        public static readonly Vector3 PlayerCubeScale = new Vector3(0.09f, 15, 0.1f);
        
        public Player(PlayBall playBall, Singularity transform, short metadata = 0) : base(transform, metadata)
        {
            PlayBall = playBall;
            RenderObject = new PlayerQueue(this);
        }

        public override Vector3 Position => base.Position + PlayerCubeOffset;
        public override Vector3 Scale => base.Scale * PlayerCubeScale;

        public override IRenderObject RenderObject { get; }

        protected override bool _Load()
        {
            return base._Load();
        }

        protected override bool _Enable()
        {
            return base._Enable();
        }

        protected override void _Tick()
        {
            Transform.Position = PlayBall.Position;
        }
    }

    public sealed class PlayerQueue : AbstractRenderObject
    {
        private readonly Cuboid _base;
        
        public PlayerQueue(IGameObject gameObject) : base(gameObject)
        {
            _base = new Cuboid(gameObject, Color.Chocolate);
        }

        public override void Draw(OpenGL gl, ITransform camera) => _base.Draw(gl, camera);
    }
}