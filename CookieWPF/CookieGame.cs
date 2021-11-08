using System;
using System.Numerics;
using Newtonsoft.Json;
using OGLU;
using OGLU.Game;
using OGLU.Model;

namespace CookieWPF
{
    [JsonObject]
    public class CookieStats
    { 
        public int Cookies;
        public int AutoClickers;
        public int ClickBoosters;
    }

    public class CookieGame : GameBase
    {
        private readonly MainWindow _mainWindow;

        public CookieGame(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }

        public override ITransform Camera { get; } = new Singularity(Vector3.UnitZ * 50);
        public CookieStats Stats;
        public Cookie Cookie = new Cookie(Singularity.Default);

        protected override bool _Load()
        {
            AddChild(Cookie);
            return base._Load();
        }

        public void BuyAutoClicker() => Stats.Cookies -= (int) Math.Pow(3, Stats.AutoClickers++);

        public void BuyClickBooster() => Stats.Cookies -= (int) Math.Pow(8, Stats.ClickBoosters++);
    }
}