using CounterApp;
using Framework;

namespace FrameworkDesign.Example
{

    interface IGameModel:IModel
    {
        BindableProperty<int> KillCount { get; }
        BindableProperty<int> Gold { get; }
        BindableProperty<int> Score { get; }
        BindableProperty<int> BestScore { get; }
        
        BindableProperty<int> Life { get; }
    }
    public class GameModel:AbstractModel,IGameModel
    {
        
        public BindableProperty<int> KillCount { get; } = new BindableProperty<int>()
        {
            Value = 0
        };

        public BindableProperty<int> Gold { get; } = new BindableProperty<int>()
        {
            Value = 0
        };

        public BindableProperty<int> Score { get; } = new BindableProperty<int>()
        {
            Value = 0
        };

        public BindableProperty<int> BestScore { get; } = new BindableProperty<int>()
        {
            Value = 0
        };

        public BindableProperty<int> Life { get; } = new BindableProperty<int>();
        
        protected override void Oninit()
        {
            var storage = this.GetUillity<IStorage>();
            BestScore.Value = storage.LoadInt(nameof(BestScore), 0);
            BestScore.RegisterOnValueChange(v => storage.SaveInt(nameof(BestScore), v) );
            
            Life.Value = storage.LoadInt(nameof(Life), 0);
            Life.RegisterOnValueChange(v => storage.SaveInt(nameof(Life), v) );
            
            Gold.Value = storage.LoadInt(nameof(Gold), 0);
            Gold.RegisterOnValueChange(v => storage.SaveInt(nameof(Gold), v) );
        }
    }
}