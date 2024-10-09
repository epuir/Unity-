using System.Runtime.InteropServices;
using Framework;
using UnityEngine;

namespace CounterApp
{
    public class AchievementSystem : AbstractSystem
    {
        protected override void OnInit()
        {
            Debug.Log("注册成就系统");
            var counterModel = this.GetModel<ICounterModel>();

            var previousCount = counterModel.Count.Value;

            bool count10unlock = false;
            counterModel.Count.RegisterOnValueChange(newCount =>
            {
                //Debug.Log("改变");
                if (previousCount < 10 && newCount >= 10 && !count10unlock)
                {
                    Debug.Log("解锁成就10成就");
                    count10unlock = true;
                }
            });
        }

        public IArchitecture GetAchitecture()
        {
            return CounterApp.Interface;
        }

        
    }
}