using System;
using Exampe.Scripts.Event;
using Framework;
using NotImplementedException = System.NotImplementedException;

namespace FrameworkDesign.Example.System
{
    public interface ICountDownSystem:ISystem
    {
        int CurrentRemainSeconds { get; }
        void Update();
    }

    public class CountDownSystem : AbstractSystem, ICountDownSystem
    {
        protected override void OnInit()
        {
            this.RegisterEvent<GameStartEven>((e) =>
            {
                mStarted = true;
                mGameStartTime = DateTime.Now;
            });

            this.RegisterEvent<GamePassEvent>(e =>
            {
                mStarted = false;
            });

        }

        private DateTime mGameStartTime { get; set; }
        private bool mStarted = false;

        public int CurrentRemainSeconds => 10 - (int)(DateTime.Now - mGameStartTime).TotalSeconds;
        public void Update()
        {
            if (mStarted)
            {
                if(DateTime.Now - mGameStartTime > TimeSpan.FromSeconds(10))
                {
                    this.SendEvent<OnCountDownEndEvent>();
                    mStarted = false;
                }
            }
        }
    }
}