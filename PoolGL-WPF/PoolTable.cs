using System.Drawing;
using System.Numerics;
using OpenGL_Util;
using OpenGL_Util.Game;
using OpenGL_Util.Model;
using OpenGL_Util.Physics;
using OpenGL_Util.Shape3;
using SharpGL;

namespace PoolGL_WPF
{
    public sealed class PoolTable : AbstractGameObject
    {
        public static readonly Vector3 BaseAreaScale = new Vector3(2, 1, 0.1f);
        public PoolTable() : base(new Singularity(-Vector3.UnitZ, (Vector3.UnitX + Vector3.UnitY) * 35))
        {
            RenderObjects.Add(new Cuboid(this, Color.DarkGreen));
            Collider = new InverseCollider(new RectCollider(this));
        }

        public override Vector3 Scale => base.Scale * BaseAreaScale;
    }
}