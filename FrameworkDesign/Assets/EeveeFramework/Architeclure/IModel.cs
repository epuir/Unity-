namespace Framework
{
    public interface IModel:IBelongToArchitecture,ICanSetArchitecture,ICanGetUillity,ICanSendEvent
    {
        void Init();
    }

    public abstract class AbstractModel:IModel
    {
        private IArchitecture mArchitecturel;
        IArchitecture IBelongToArchitecture.GetAchitecture()
        {
            return mArchitecturel;
        }

        void ICanSetArchitecture.SetArchitecture(IArchitecture architecture)
        {
            mArchitecturel = architecture;
        }
        void IModel.Init()
        {
            Oninit();
        }

        protected abstract void Oninit();
        
        
    }
}