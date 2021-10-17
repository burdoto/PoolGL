using System.Drawing;
using System.Numerics;
using OpenGL_Util;
using OpenGL_Util.Shape3;
using SharpGL;

namespace PoolGL_WPF
{
    public class Player : AbstractGameObject
    {
        public static readonly Vector3 PlayerCubeOffset = new Vector3(0f, -8f, 0f);
        public static readonly Vector3 PlayerCubeScale = new Vector3(0.09f, 15, 0.1f);
        
        public Player(ITransform transform, short metadata = 0) : base(transform, metadata)
        {
            RenderObject = new PlayerQueue(this);
        }

        public override Vector3 Position => base.Position + PlayerCubeOffset;
        public override Vector3 Scale => base.Scale * PlayerCubeScale;

        public override IRenderObject RenderObject { get; }
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