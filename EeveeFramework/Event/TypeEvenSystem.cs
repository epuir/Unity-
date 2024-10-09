using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace Framework
{
    public interface ITypeEvnetSystem
    {
        void Send<T>() where T : new();
        void Send<T>(T t);
        IUnRegister Register<T>(Action<T> onEvent);
        void UnRegister<T>(Action<T> onEvent);
    }

    public interface IUnRegister
    {
        void UnRegister();
    }

    public struct TypeEventSystemUnRegiste<T>:IUnRegister
    {
        public ITypeEvnetSystem TypeEvnetSystem;
        public Action<T> OnEvent;
        public void UnRegister()
        {
            TypeEvnetSystem.UnRegister(OnEvent);
            TypeEvnetSystem = null;
            OnEvent = null;
        }
    }

    public class TypeEventSystem : ITypeEvnetSystem
    {
        public interface IRegistrations
        {
            
        }
        
        public class  Registrations<T>:IRegistrations
        {
            public Action<T> OnEvent = e => { };
            
        }

        private Dictionary<Type, IRegistrations> mEventRegistration = new Dictionary<Type, IRegistrations>();
        
        
        public void Send<T>() where T : new()
        {
            var e = new T();
            Send<T>(e);
        }

        public void Send<T>(T t)
        {
            var type = typeof(T);
            IRegistrations registrations;
            if (mEventRegistration.TryGetValue(type, out registrations))
            {
                (registrations as Registrations<T>)?.OnEvent.Invoke(t);
            }
            
        }

        public IUnRegister Register<T>(Action<T> onEvent)
        {
            var type = typeof(T);
            IRegistrations registrations;
            if (mEventRegistration.TryGetValue(type, out registrations)){}
            else
            {
                registrations = new Registrations<T>();
                mEventRegistration.Add(type,registrations);
            }

            (registrations as Registrations<T>).OnEvent += onEvent;
            return new TypeEventSystemUnRegiste<T>()
            {
                OnEvent = onEvent,
                TypeEvnetSystem = this
            };


        }

        public void UnRegister<T>(Action<T> onEvent)
        {
            var type = typeof(T);
            IRegistrations registrations;
            if (mEventRegistration.TryGetValue(type, out registrations))
            {
                (registrations as Registrations<T>).OnEvent -= onEvent;
            }
            
        }
    }
    
    public class UnResgisterOnDestoryTrigger:MonoBehaviour
    {
        private HashSet<IUnRegister> mUnRegisters = new HashSet<IUnRegister>();

        public void AddUnRegister(IUnRegister unRegister)
        {
            mUnRegisters.Add(unRegister);
        }

        private void OnDestroy()
        {
            foreach (var unRegister in mUnRegisters)
            {
                unRegister.UnRegister();
            }
        }
    }

    public static class UnRegisterExtension
    {
        public static void UnRegisterWhenGameObjectDestoryed(this IUnRegister self,GameObject gameobject)
        {
            var trigger = gameobject.GetComponent<UnResgisterOnDestoryTrigger>();
            if (!trigger)
            {
                Debug.Log("添加到"+gameobject.name);
                trigger = gameobject.AddComponent<UnResgisterOnDestoryTrigger>();
            }
            trigger.AddUnRegister(self);
        }
    }
    
    
}