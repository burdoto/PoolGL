using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using GameLib;
using GameLib.Game;
using GameLib.Model;
using GameLib.Physics;
using GameLib.Shape2;
using GameLib.Shape3;
using Rectangle = GameLib.Shape2.Rectangle;

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

        protected override bool _Enable()
        {
            //LoadGrid();
            return base._Enable();
        }

        [Conditional("DEBUG")]
        private void LoadGrid()
        {
            var pos1 = new Vector3(0, 50, 2);
            var pos2 = new Vector3(50, 0, 2);
            var vert = new Vector3(0.1f, 100f, 2);
            var horz = new Vector3(100f, 0.1f, 2);
            for (int i = 0; i < 100; i++)
            {
                RenderObjects.Add(new Rectangle(this, new Singularity(pos1, horz), Color.Bisque));
                RenderObjects.Add(new Rectangle(this, new Singularity(pos2, vert), Color.Beige));
                
                pos2.X -= 10;
                pos1.Y -= 10;
            }

        }

        public override Vector3 Scale => base.Scale * BaseAreaScale;

        protected override void _Tick()
        {
            txt.Content = ((GameBase.Main as PoolGame)?.PlayBall.Position).ToString();
        }
    }
}