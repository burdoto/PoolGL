using System.IO;
using System.Numerics;
using OGLU;
using OGLU.Model;
using OGLU.Physics;
using OGLU.Shape2;
using SharpGL;
using SharpGL.Enumerations;
using SharpGL.SceneGraph.Assets;

namespace CookieWPF
{
    public class Cookie : AbstractGameObject
    {
        internal readonly Texture Texture = new Texture();
        
        public Cookie(Singularity transform, short metadata = 0) : base(transform, metadata)
        {
            RenderObjects.Add(new Texture2(this, Texture));
            Collider = new CircleCollider(this);
        }

        public override Vector3 Scale => base.Scale * 5;

        public override bool Load(OpenGL gl)
        {
            Texture.Create(gl, Path.Combine(Directory.GetCurrentDirectory(), "Assets", "cookie.png"));
            return base.Load(gl);
        }
    }
}