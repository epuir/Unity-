using System;
using System.Security.Cryptography.X509Certificates;

namespace Framework
{
    public interface ICanRegisterEvent:IBelongToArchitecture
    {
        
    }

    public static class CanRegisterEventExtension
    {
        public static IUnRegister RegisterEvent<T>(this ICanRegisterEvent self, Action<T> onEvent)
        {
            return self.GetAchitecture().RegisterEvent(onEvent);
        }
        
        public static void UnRegisterEvent<T>(this ICanRegisterEvent self, Action<T> onEvent)
        {
            self.GetAchitecture().UnRegisterEvent<T>(onEvent);
        }
    }
}