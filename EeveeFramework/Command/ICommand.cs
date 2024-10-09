namespace Framework
{
    public interface ICommand:IBelongToArchitecture,ICanSetArchitecture,ICanGetUillity,ICanGetModel,ICanGetSystem,ICanSendEvent,ICanSendCommand
    {
        void Execute();
    }
    public abstract class AbstractCommand:ICommand
    {
        private IArchitecture mArchitecture;
        
        IArchitecture IBelongToArchitecture.GetAchitecture()
        {
            return mArchitecture;
        }

        void ICanSetArchitecture.SetArchitecture(IArchitecture architecture)
        {
            mArchitecture = architecture;
        }
        
        void ICommand.Execute()
        {
            OnExecute();
        }

        protected abstract void OnExecute();

    }
}