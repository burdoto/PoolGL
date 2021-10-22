using System.Drawing;
using System.Numerics;
using OGLU;
using OGLU.Game;
using OGLU.Model;
using OGLU.Physics;
using OGLU.Shape2;
using Rectangle = OGLU.Shape2.Rectangle;

namespace PoolGL_WPF
{
    public sealed class PoolTable : AbstractGameObject
    {
        public static readonly Vector3 BaseAreaScale = new Vector3(2, 1, 0.1f);
        private readonly Text txt;

        public PoolTable() : base(new Singularity(-Vector3.UnitZ, (Vector3.UnitX + Vector3.UnitY) * 35))
        {
            RenderObjects.Add(new Rectangle(this, Color.DarkGreen));
            RenderObjects.Add(txt = new Text(this,
                new DeltaTransform(this) { PositionDelta = new Vector3(20, 60, 0) }));
            Collider = new InverseCollider(new RectCollider(this));
        }

        public override Vector3 Scale => base.Scale * BaseAreaScale;

        protected override void _Tick()
        {
            txt.Content = ((GameBase.Main as PoolGame)?.PlayBall.Position).ToString();
        }
    }
}