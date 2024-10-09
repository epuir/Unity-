using System;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.FSM
{
    
   
    
    public class Blackboard
    {
        //储存数据 
    }
    
    public class FSM
    {
        public IState curstate;
        public List<Type> states;
        public Blackboard blackboard;
        public FSM(Blackboard blackboard)
        {
            this.states = new List<Type>();
            this.blackboard = blackboard;
        }
        public void AddState(IState state)
        {
            // if (!(state is IState))
            // {
            //     Debug.Log("传入状态非继承IState");
            //     return;
            // }

            if (states.Contains(state.GetType()))
            {
                Debug.Log("重复注册");
            }
            
            Debug.Log("状态注册");
            states.Add(state.GetType());
        }
        
        
        public void SwitchState(IState state) 
        {
            if(!states.Contains(state.GetType()))
            {
                Debug.Log("状态未注册");
                return;
            }

            if (curstate!= null&&curstate.GetType().Equals(state.GetType()))
            {
                Debug.Log("已经是该状态无法转变");
                return;
            }
            
            if(curstate != null)
            {
                curstate.OnExit();
            }
            curstate = state;
            curstate.OnEnter();
        }

        public void InitState()
        {
            if (!(curstate==null))
            {
                curstate.OnExit();
                curstate.OnEnter();
            }
            
        }
        public void OnUpdate()
        {
            curstate.OnUpdate();
        }
    }
}