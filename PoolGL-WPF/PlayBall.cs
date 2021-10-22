using OpenGL_Util.Model;

namespace PoolGL_WPF
{
    public class PlayBall : PoolBall
    {
        public PlayBall(Singularity transform) : base(transform, 255)
        {
            Collider!.ActiveCollider = true;
        }
    }
}