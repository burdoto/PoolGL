using System.Drawing;
using System.Numerics;
using OpenGL_Util;
using OpenGL_Util.Model;
using OpenGL_Util.Shape3;
using SharpGL;

namespace PoolGL_WPF
{
    public sealed class PoolTable : AbstractGameObject
    {
        public PoolTable() : base(new Singularity(Vector3.UnitZ, (Vector3.UnitX + Vector3.UnitY) * 35))
        {
            RenderObject = new PoolTableRenderObject(this);
        }

        public override IRenderObject RenderObject { get; }
    }

    public sealed class PoolTableRenderObject : AbstractRenderObject
    {
        public static readonly Vector3 BaseAreaScale = new Vector3(2, 1, 0.1f);
        private readonly Cuboid _bg;

        public PoolTableRenderObject(IGameObject gameObject) : base(gameObject)
        {
            _bg = new Cuboid(this, Color.Green);
        }

        public override Vector3 Scale => base.Scale * BaseAreaScale;
        public override void Draw(OpenGL gl, ITransform camera) => _bg.Draw(gl, camera);
    }
}