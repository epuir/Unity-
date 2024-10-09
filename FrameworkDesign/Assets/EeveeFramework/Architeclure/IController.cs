namespace Framework
{
    public interface IController:IBelongToArchitecture,ICanSetArchitecture,ICanGetModel,ICanGetSystem,ICanSendCommand,ICanRegisterEvent
    {
        
    }
}