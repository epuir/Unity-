using System;
using Exampe.Scripts.Command;
using Exampe.Scripts.Event;
using Framework;
using UnityEngine;

namespace FrameworkDesign.Example
{
    public class ErrorArea:MonoBehaviour,IController
    {
        private void OnMouseDown()
        {
            this.SendCommand<MissCommand>();
        }

        public IArchitecture GetAchitecture()
        {
            return PointGame.Interface;
        }

        public void SetArchitecture(IArchitecture architecture)
        {
            throw new NotImplementedException();
        }
    }
}