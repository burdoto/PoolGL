using System.Numerics;
using OGLU;
using OGLU.Model;
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
            RenderObjects.Add(new CookieRender(this));
        }

        public override Vector3 Scale => base.Scale * 5;

        public override bool Load(OpenGL gl)
        {
            Texture.Create(gl, "Assets/cookie.png");
            return base.Load(gl);
        }
    }

    public class CookieRender : AbstractRenderObject
    {
        private readonly Cookie _cookie;

        public CookieRender(Cookie cookie) : base(cookie)
        {
            _cookie = cookie;
        }

        public override void Draw(OpenGL gl, ITransform camera)
        {
            gl.Begin(BeginMode.Quads);
            _cookie.Texture.Bind(gl);
            
            var mainPos = GameObject.Transform.Position;
            var vec = Position - mainPos;
            var scale = Scale;
            vec.X -= scale.X / 2;
            vec.Y -= scale.Y / 2;
            gl.TexCoord(0,0);
            gl.Vertex((Vector3.Transform(vec, Rotation) + mainPos).Vertex());
            vec.X += scale.X;
            gl.TexCoord(1,0);
            gl.Vertex((Vector3.Transform(vec, Rotation) + mainPos).Vertex());
            vec.Y += scale.Y;
            gl.TexCoord(1,1);
            gl.Vertex((Vector3.Transform(vec, Rotation) + mainPos).Vertex());
            vec.X -= scale.X;
            gl.TexCoord(0,1);
            gl.Vertex((Vector3.Transform(vec, Rotation) + mainPos).Vertex());
            gl.End();
        }
    }
}