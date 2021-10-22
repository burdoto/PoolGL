using Color = System.Drawing.Color;
using System.Numerics;
using OpenGL_Util;
using OpenGL_Util.Game;
using OpenGL_Util.Model;
using OpenGL_Util.Physics;
using OpenGL_Util.Shape2;

namespace PoolGL_WPF
{
    public sealed class PoolTable : AbstractGameObject
    {
        public static readonly Vector3 BaseAreaScale = new Vector3(2, 1, 0.1f);
        private readonly Text txt;

        public PoolTable() : base(new Singularity(-Vector3.UnitZ, (Vector3.UnitX + Vector3.UnitY) * 35))
        {
            RenderObjects.Add(new Rectangle(this, Color.DarkGreen));
            RenderObjects.Add(txt = new Text(this, new DeltaTransform(this){ PositionDelta = new Vector3(20, 60, 0) }));
            Collider = new InverseCollider(new RectCollider(this));
        }

        protected override void _Tick()
        {
            txt.Content = ((GameBase.Main as PoolGame)?.PlayBall.Position).ToString();
        }

        public override Vector3 Scale => base.Scale * BaseAreaScale;
    }
}