using System;
using System.Collections.Generic;
using FrameworkDesign.Example;
using GameFramework;
using UnityEngine;
using UnityGameFramework.Runtime;

public class EveenTest : MonoBehaviour
{
    string welcomeMessage = Utility.Text.Format("Hello Game Framework {0}.", GameFramework.Version.GameFrameworkVersion);
    private void Start()
    {
        Type a = this.GetType();
        var w =  (EveenTest)Activator.CreateInstance(a);
    }

    class LogHelp:GameFrameworkLog.ILogHelper
    {
        public void Log(GameFrameworkLogLevel level, object message)
        {
            Debug.Log("一次测试");
        }
    }
}

public class FXYS<T> where T :List<T>
{
   public void Show()
    {
        Debug.Log(typeof(T));
    }
}
