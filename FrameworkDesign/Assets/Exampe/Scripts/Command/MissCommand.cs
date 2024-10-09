using Exampe.Scripts.Event;
using Framework;
using FrameworkDesign.Example;

namespace Exampe.Scripts.Command
{
    public class MissCommand:AbstractCommand
    {
        protected override void OnExecute()
        {
            var gameModel = this.GetModel<IGameModel>();
            if (gameModel.Life.Value > 0)
            {
                gameModel.Life.Value--;
            }
            else
            {
                this.SendEvent<OnMissEvent>();
            }
            
        }
    }
}