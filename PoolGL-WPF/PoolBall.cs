using System;
using System.Numerics;
using System.Windows.Documents;
using System.Windows.Media;
using OpenGL_Util;
using OpenGL_Util.Model;
using OpenGL_Util.Physics;
using OpenGL_Util.Shape2;
using SharpGL;
using SharpGL.Enumerations;
using static System.Windows.Media.Colors;

namespace PoolGL_WPF
{
    public class PoolBall : AbstractGameObject
    {
        public PoolBall(Singularity transform, byte fig) : base(transform, fig)
        {
            RenderObjects.Add(new PoolBallCircle(this));
            /*
            if (Half)
                RenderObjects.Add(new Circle(this, new DeltaTransform(this){ScaleDelta = Vector3.One * 0.5f})
                {
                    PostBegin = gl => gl.Color(200, 200, 200)
                });
                */
            if (fig != 255)
                RenderObjects.Add(new Text(this)
                {
                    Content = fig.ToString(),
                    FontColor = System.Drawing.Color.Black
                });
            Collider = new CircleCollider(this);
            PhysicsObject = new PhysicsObject(this){Inertia = 0.93f};
        }

        public bool Half => Metadata != 255 && Metadata / 8 % 2 > 0.98;

        public Color Color => Metadata == 255 ? White 
            : (Metadata % 8) switch
            {
                0 => Black,
                1 => Yellow,
                2 => CornflowerBlue,
                3 => Red,
                4 => Purple,
                5 => Orange,
                6 => SeaGreen,
                7 => Brown,
                _ => throw new ArgumentOutOfRangeException()
            };
    }

    public class PoolBallCircle : AbstractRenderObject
    {
        private readonly Circle _base;
        
        public PoolBallCircle(IGameObject gameObject) : base(gameObject)
        {
            
            _base = new Circle(gameObject);
            _base.PostBegin = gl => gl.Color(Color.Array());
        }

        public bool Half => GameObject.Metadata != 255 && GameObject.Metadata / 8 % 2 > 0.98;

        public Color Color => GameObject.Metadata == 255 ? White 
            : (GameObject.Metadata % 8) switch
            {
                0 => Black,
                1 => Yellow,
                2 => CornflowerBlue,
                3 => Red,
                4 => Purple,
                5 => Orange,
                6 => SeaGreen,
                7 => Brown,
                _ => throw new ArgumentOutOfRangeException()
            };

        public override void Draw(OpenGL gl, ITransform camera) => _base.Draw(gl, camera);
    }
}