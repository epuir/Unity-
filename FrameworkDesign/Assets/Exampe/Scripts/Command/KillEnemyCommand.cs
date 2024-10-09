using System;
using Exampe.Scripts.Event;
using Framework;
using Random = UnityEngine.Random;

namespace FrameworkDesign.Example.Command
{
        public class KillEnemyCommand : AbstractCommand
        {
                protected override void OnExecute()
                {
                        var gameModel = this.GetModel<IGameModel>();
                        
                        this.GetModel<IGameModel>().KillCount.Value++;
                        
                        this.SendEvent<OnEnemyKillEvent>();
                        
                        if(Random.Range(0,10)<3)
                        {
                                gameModel.Gold.Value += Random.Range(1, 3);
                        }

                        if (PointGame.Interface.GetModel<IGameModel>().KillCount.Value == 10)
                        {
                                this.SendEvent<GamePassEvent>();
                        }
                }
        }
        
        
    
}