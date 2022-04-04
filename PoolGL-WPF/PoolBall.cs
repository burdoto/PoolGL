using System;
using System.Numerics;
using System.Windows.Media;
using GameLib;
using GameLib.Model;
using GameLib.Physics;
using GameLib.Shape2;
using SharpGL;
using static System.Windows.Media.Colors;

namespace PoolGL_WPF
{
    public class PoolBall : AbstractGameObject
    {
        public PoolBall(Singularity transform, byte fig) : base(transform, fig)
        {
            RenderObjects.Add(new Circle(this)
            {
                PostBegin = gl => gl.Color(Color.Array())
            });
            if (Half)
                RenderObjects.Add(new Circle(this, new DeltaTransform(this){ScaleDelta = Vector3.One * 0.5f})
                {
                    PostBegin = gl => gl.Color(White.Array())
                });
            if (fig != 255)
                RenderObjects.Add(new Text(this)
                {
                    Content = fig.ToString(),
                    FontColor = System.Drawing.Color.Black
                });
            Collider = new CircleCollider(this){ActiveCollider = true};
            PhysicsObject = new PhysicsObject(this) { Inertia = 0.93f, Mass = 200 };
        }

        public bool Half => Metadata != 255 && Metadata / 8 % 2 > 0.98;

        public Color Color => Metadata == 255
            ? White
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
}