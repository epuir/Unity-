using System;
using UnityEngine;
using Framework;
namespace Exampe.Events
{
    public class TypeEventSystemExample:MonoBehaviour
    {
        public struct EventA:IEventGroup
        {}
        
        public struct EventB:IEventGroup
        {
            public int B;
        }
        public struct EventC:IEventGroup
        {}
        
        public struct EventD:IEventGroup
        {}

        private TypeEventSystem mTypeEventSystem = new TypeEventSystem();
        public interface IEventGroup
        {
            
        }

        private void Start()
        {
            mTypeEventSystem.Register<EventA>(OnEventA);
            mTypeEventSystem.Register<EventB>(b =>
            {
                Debug.Log("EventB"+b.B);
            }).UnRegisterWhenGameObjectDestoryed(gameObject);
            
            mTypeEventSystem.Register<IEventGroup>(e =>
            {
                Debug.Log("CG");
            }).UnRegisterWhenGameObjectDestoryed(gameObject);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                mTypeEventSystem.Send<EventA>();
            }
            
            if (Input.GetKeyDown(KeyCode.M))
            {
                mTypeEventSystem.Send<EventB>(new EventB(){B = 555});
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                mTypeEventSystem.Send<IEventGroup>(new EventC());
                mTypeEventSystem.Send<IEventGroup>(new EventD());
            }
        }

        private void OnEventA(EventA obj)
        {
            Debug.Log("OnEventA");
        }

        private void OnDestroy()
        {
            mTypeEventSystem.UnRegister<EventA>(OnEventA);
            mTypeEventSystem = null;
        }
    }
}