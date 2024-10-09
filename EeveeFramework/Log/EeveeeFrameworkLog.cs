using UnityEngine;

namespace Framework
{
    /// <summary>
    /// 日志系统
    /// </summary>
    public static class ELog
    {
        public interface ILogHelper
        {
            
        }
        
        private static ILogHelper _helper;
        
        //设置LogHelper
        public static void SetLogHelper(ILogHelper help)
        {
            _helper = help;
        }

        public static void EPrint(this object @class,Object message = null)
        {
            UnityEngine.Debug.Log(@class,message);
        }

        public static void EDebug(string message)
        {
            UnityEngine.Debug.Log(message);
        }
       
    }
}