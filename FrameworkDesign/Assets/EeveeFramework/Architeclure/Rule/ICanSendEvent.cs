namespace Framework
{
    public interface ICanSendEvent:IBelongToArchitecture
    {
        
    }

    public static class CanSenddEventExtension
    {
        public static void SendEvent<T>(this ICanSendEvent self) where T : new()
        {
            self.GetAchitecture().SendEvent<T>();
        }
        
        public static void SendEvent<T>(this ICanSendEvent self,T e) where T : new()
        {
            self.GetAchitecture().SendEvent<T>(e);
        }
    }
}