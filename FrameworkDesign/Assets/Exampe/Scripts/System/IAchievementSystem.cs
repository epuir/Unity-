using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exampe.Scripts.Event;
using Framework;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace FrameworkDesign.Example
{
    public interface IAchievementSystem:ISystem
    {
        
    }

    public class AchievementItem
    {
        public string Name { get; set; }
        public Func<bool> CheckComplete { get; set; }
        public bool Unlocked { get; set; }

    }
    public class AchievementSystem:AbstractSystem,IAchievementSystem
    {
        private List<AchievementItem> mItems = new List<AchievementItem>();
        private bool mMissed = false;
        protected override void OnInit()
        {
            this.RegisterEvent<OnMissEvent>(e =>
            {
                mMissed = true;
            });

            this.RegisterEvent<GameStartEven>(e =>
            {
                mMissed = false;
            });
            
            mItems.Add(new AchievementItem()
            {
                Name = "百分比成就",
                CheckComplete = ()=>this.GetModel<IGameModel>().BestScore.Value>100
            });
            
            mItems.Add(new AchievementItem()
            {
                Name = "手残",
                CheckComplete = ()=>this.GetModel<IGameModel>().Score.Value<0
            });
            
            mItems.Add(new AchievementItem()
            {
                Name = "零失误",
                CheckComplete = ()=>!mMissed
            });
            
            mItems.Add(new AchievementItem()
            {
                Name = "手残",
                CheckComplete = ()=>this.GetModel<IGameModel>().Score.Value<0
            });
            
            mItems.Add(new AchievementItem()
            {
                Name = "零失误成就",
                CheckComplete = () =>mItems.Count(item => item.Unlocked)>3
            });

            this.RegisterEvent<GamePassEvent>(async e =>
            {
                Task.Delay(TimeSpan.FromSeconds(0.1f));
                foreach (var item in mItems)
                {
                    if (!item.Unlocked && item.CheckComplete())
                    {
                        item.Unlocked = true;
                        Debug.Log("解锁成就"+ item.Name);
                    }
                }
            });
        }
    }
}