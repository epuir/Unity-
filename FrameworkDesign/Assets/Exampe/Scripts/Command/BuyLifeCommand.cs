using Framework;
using FrameworkDesign.Example;

namespace Exampe.Scripts.Command
{
    public class BuyLifeCommand:AbstractCommand
    {
        protected override void OnExecute()
        {
            var gameModel = this.GetModel<IGameModel>();
            gameModel.Gold.Value--;
            gameModel.Life.Value++;
        }
    }
}