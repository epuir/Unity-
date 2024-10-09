namespace Framework
{
    public interface ISystem:IBelongToArchitecture,ICanSetArchitecture,ICanGetUillity,ICanGetModel,ICanSendEvent,ICanRegisterEvent,ICanGetSystem
    {
        void Init();
    }
    
    public abstract class AbstractSystem:ISystem
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

        void ISystem.Init()
        {
            OnInit();
        }

        protected abstract void OnInit();
    }
}