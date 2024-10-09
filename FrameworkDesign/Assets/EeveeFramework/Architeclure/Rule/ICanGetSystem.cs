namespace Framework
{
    public interface ICanGetSystem:IBelongToArchitecture
    {
        
    }

    public static class CanGetSystemExtension
    {
        public static T GetSystem<T>(this ICanGetSystem self) where T:class,ISystem
        {
            return self.GetAchitecture().GetSystem<T>();
        }
    }
}