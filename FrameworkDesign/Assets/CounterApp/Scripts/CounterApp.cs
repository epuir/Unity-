using Framework;
using UnityEngine;

namespace CounterApp
{
    public class CounterApp:Architecture<CounterApp>
    {
        protected override void Init()
        {
            RegisterModel<ICounterModel>(new CounterModel());
            RegisterUtillity<IStorage>(new PlayerPrefsStorage());
            RegisterSystem<ISystem>(new AchievementSystem());
            //Debug.Log("CountM的注册");
        }
    }
}