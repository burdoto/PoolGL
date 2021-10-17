using System;
using System.Numerics;
using System.Windows.Documents;
using System.Windows.Media;
using OpenGL_Util;
using OpenGL_Util.Shape2;
using SharpGL;
using SharpGL.Enumerations;
using static System.Windows.Media.Colors;

namespace PoolGL_WPF
{
    public class PoolBall : AbstractGameObject
    {
        public PoolBall(ITransform transform, byte fig) : base(transform, fig)
        {
            RenderObject = new PoolBallCircle(this);
        }

        public override IRenderObject RenderObject { get; }
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

        public override Vector3 Scale => base.Scale * 3;

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