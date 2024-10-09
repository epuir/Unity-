using Exampe.Scripts.Event;
using Framework;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace FrameworkDesign.Example.System
{
    public interface IScoreSystem:ISystem
    {
        
    }
    
    public class ScoreSystem:AbstractSystem,IScoreSystem
    {
        protected override void OnInit()
        {
            var gamemodel = this.GetModel<IGameModel>();
            
            
            //注册事件
            this.RegisterEvent<GamePassEvent>(e =>
            {

                var countDownSytem = this.GetSystem<ICountDownSystem>();
                var timeScore = countDownSytem.CurrentRemainSeconds * 10;
                gamemodel.Score.Value += timeScore;
                
                if (gamemodel.Score.Value > gamemodel.BestScore.Value)
                {
                    gamemodel.BestScore.Value = gamemodel.Score.Value;
                    "新记录".EPrint();
                }
            });
            this.RegisterEvent<OnEnemyKillEvent>(e =>
            {
                gamemodel.Score.Value += 10;
                Debug.Log("+10后"+gamemodel.Score.Value+"为当期分数");
            });

            this.RegisterEvent<OnMissEvent>(e =>
            {
                gamemodel.Score.Value -= 5;
                Debug.Log("-5后"+gamemodel.Score.Value+"为当期分数");
            });
        }
    }
}