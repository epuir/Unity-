using System;
using FrameworkDesign.Example.Command;
using Framework;
using UnityEngine;

namespace FrameworkDesign.Example
{
    public class Enemy:MonoBehaviour,IController
    {
        private void OnMouseDown()
        {
            gameObject.SetActive(false);
            this.SendCommand<KillEnemyCommand>();
        }

         IArchitecture IBelongToArchitecture.GetAchitecture()
        {
            return PointGame.Interface;
        }
        void ICanSetArchitecture.SetArchitecture(IArchitecture architecture)
        {
            throw new NotImplementedException();
        }
    }
}