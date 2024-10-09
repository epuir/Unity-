using System;
using Framework;
using UnityEngine;

namespace Exampe.IOC
{
    public class DIPExample:MonoBehaviour
    {
        public interface IStorags
        {
            void SaveString(string key, string value = "");
            string LoadString(string ksy,string defaultValue = "");
        }

        public class PlayerPrefsStorage:IStorags
        {
            public void SaveString(string key, string value = "")
            {
                PlayerPrefs.SetString(key,value);
            }

            public string LoadString(string key, string defaultValue)
            {
                return PlayerPrefs.GetString(key,defaultValue);
            }
        }

        private void Start()
        {
            var container = new IOCContainer();
            container.Register<IStorags>(new PlayerPrefsStorage());
            var storage = container.Get<IStorags>();
            storage.SaveString("name","wwww");
            Debug.Log(storage.LoadString("name"));
        }
    }
}