using CounterApp;
using Framework;
using FrameworkDesign.Example.System;


namespace FrameworkDesign.Example
{
    public class PointGame:Architecture<PointGame>
    {
        protected override void Init()
        {
            RegisterSystem<IScoreSystem>(new ScoreSystem());
            RegisterModel<IGameModel>(new GameModel());
            RegisterUtillity<IStorage>(new PlayerPrefsStroage());
            
            RegisterSystem<ICountDownSystem>(new CountDownSystem());
            RegisterSystem<IAchievementSystem>(new AchievementSystem());
        }
    }
}