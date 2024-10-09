using System;
using System.Linq.Expressions;
using Framework;
using Framework.FSM;
using UnityEngine;
namespace FrameworkDesign.Example
{
    public class BBB : IState
    {
        public void OnEnter()
        {
            Debug.Log("BS");
        }

        public void OnExit()
        {
            Debug.Log("BE");
        }

        public void OnUpdate()
        {
            Debug.Log("BU");
        }
    }
    public class AAA : IState
    {
        public void OnEnter()
        {
            Debug.Log("AS");
        }

        public void OnExit()
        {
            Debug.Log("AE");
        }

        public void OnUpdate()
        {
            Debug.Log("AU");
        }
    }
    public class Test:MonoBehaviour
    {
        private FSM fsm = new FSM(new Blackboard());
        private void Awake()
        {
          fsm.AddState(new AAA());
          fsm.AddState(new BBB());
          fsm.SwitchState(new AAA());
        }
        
        private void Update()
        {
            fsm.OnUpdate();
            if (Input.GetKeyDown(KeyCode.F))
            {
                fsm.SwitchState(new BBB());
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                fsm.SwitchState(new AAA());
            }
        }
    }

    public class Blue
    {
        public void Connect()
        {
            Debug.Log("连接蓝牙");
        }
    }
}