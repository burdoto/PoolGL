using System;
using System.Drawing;
using System.Numerics;
using OpenGL_Util;
using OpenGL_Util.Model;
using OpenGL_Util.Shape3;
using SharpGL;
using Rectangle = OpenGL_Util.Shape2.Rectangle;

namespace PoolGL_WPF
{
    public class Player : AbstractGameObject
    {
        public PlayBall PlayBall { get; }
        public static readonly Vector3 PlayerOffset = new Vector3(0f, -17f, 0f);
        public static readonly Vector3 PlayerScale = new Vector3(0.13f, 15, 0.1f);
        
        public Player(PlayBall playBall, Singularity transform, short metadata = 0) : base(transform, metadata)
        {
            PlayBall = playBall;
            RenderObject = new PlayerQueue(this);
        }

        public override Vector3 Position => base.Position + PlayerOffset;
        public override Vector3 Scale => base.Scale * PlayerScale;

        public override IRenderObject RenderObject { get; }

        protected override void _Tick()
        {
            Transform.Position = PlayBall.Position;

            var p1 = PlayBall.Position;
            var p2 = p1 + Vector3.UnitY;
            var p3 = MainWindow.Game.MousePosition;
            var a = new Vector2(p1.X - p2.X, p1.Y - p2.Y);
            var b = new Vector2(p1.X - p3.X, p1.Y - p3.Y);
            var u1 = a * b / (Vector2.Abs(a) * Vector2.Abs(b));
            var angle = MathF.Acos(u1.Magnitude());
            Transform.Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitZ, angle);
        }
    }

    public sealed class PlayerQueue : AbstractRenderObject
    {
        private readonly Rectangle _base;
        
        public PlayerQueue(IGameObject gameObject) : base(gameObject)
        {
            _base = new Rectangle(gameObject, Color.Chocolate);
        }

        public override void Draw(OpenGL gl, ITransform camera) => _base.Draw(gl, camera);
    }
}