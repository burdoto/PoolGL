﻿using System.Diagnostics;
using System.Numerics;
using GameLib;
using GameLib.Game;
using GameLib.Model;
using GameLib.Physics;

namespace PoolGL_WPF
{
    public sealed class PoolGame : GameBase
    {
        public readonly PlayBall PlayBall;
        public readonly Player Player;
        public readonly PoolBall[] PoolBalls = new PoolBall[15];
        public readonly PoolTable Table;
        private readonly MousePoint Mouse;

        public PoolGame()
        {
            AddChild(Table = new PoolTable());
            AddChild(PlayBall = new PlayBall(new Singularity(Vector3.UnitX * -25)));
            AddChild(Player = new Player(PlayBall, new Singularity()));
            for (byte i = 1; i < 16; i++)
                AddChild(PoolBalls[i - 1] = new PoolBall(new Singularity(Vector3.UnitX * 20), i));

            AddChild(new PoolBall(new Singularity(Vector3.UnitX * 10), 17));

            ArrangeCluster();

            AddChild(Mouse = new MousePoint());
        }

        private class MousePoint : AbstractGameObject
        {
            public MousePoint()
            {
                RenderObjects.Add(new Circle(this));
            }
        }
        
        public override ITransform Camera { get; } = new Singularity(Vector3.UnitZ * 50);
        public Vector2 MousePosition { get; internal set; }

        public override void Tick()
        {
            Mouse.Transform.Position = MousePosition.To3Dim(1);
            base.Tick();
        }

        private void ArrangeCluster()
        {
            float rad = PlayBall.Scale.X * 2 + 0.03f;
            var off = Vector3.UnitX * rad;
            var angle = 120;
            var turn1 = Quaternion.CreateFromAxisAngle(Vector3.UnitZ, angle);
            var turn2 = Quaternion.CreateFromAxisAngle(Vector3.UnitZ, -angle);
            var off1 = Vector3.Transform(off, turn1);
            var off2 = Vector3.Transform(off, turn2);
            var pos = PoolBalls[0].Position;

            PoolBalls[1].Transform.Position = off1 * 1 + pos;
            PoolBalls[2].Transform.Position = off1 * 2 + pos;
            PoolBalls[3].Transform.Position = off1 * 3 + pos;
            PoolBalls[4].Transform.Position = off1 * 4 + pos;
            PoolBalls[5].Transform.Position = off2 * 1 + off1 * 0 + pos;
            PoolBalls[6].Transform.Position = off2 * 1 + off1 * 2 + pos;
            PoolBalls[7].Transform.Position = off1 + off2 + pos;
            PoolBalls[8].Transform.Position = off2 * 1 + off1 * 3 + pos;
            PoolBalls[9].Transform.Position = off2 * 2 + off1 * 0 + pos;
            PoolBalls[10].Transform.Position = off2 * 2 + off1 * 1 + pos;
            PoolBalls[11].Transform.Position = off2 * 2 + off1 * 2 + pos;
            PoolBalls[12].Transform.Position = off2 * 3 + off1 * 0 + pos;
            PoolBalls[13].Transform.Position = off2 * 3 + off1 * 1 + pos;
            PoolBalls[14].Transform.Position = off2 * 4 + pos;
        }

        public void Shoot(float strength)
        {
            var impact = Vector3.Normalize(PlayBall.Position - new Vector3(MousePosition, 0)) * strength;
            Debug.WriteLine("Impact force: " + impact);
            (PlayBall.PhysicsObject as PhysicsObject)!.Velocity = impact * new Vector3(-1, 1, 0);
        }
    }
}