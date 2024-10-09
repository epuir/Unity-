namespace Framework
{
    public static partial class EeveeFrameworkLog
    {
        public interface ILogHelper
        {
            void Log(EeveeFrameworkLogLevel level,object message);
        }
    }
}
   
