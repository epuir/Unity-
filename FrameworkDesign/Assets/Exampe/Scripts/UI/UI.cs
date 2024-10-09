using System;
using Exampe.Scripts.Event;
using Framework;
using UnityEngine;

namespace FrameworkDesign.Example
{
    public class UI:MonoBehaviour,IController
    {
        private void Start()
        {
            GetAchitecture().RegisterEvent<GamePassEvent>(OnGamePass);
            this.RegisterEvent<OnCountDownEndEvent>(e =>
            {
                transform.Find("Canvas/GamePanel").gameObject.SetActive(false);
                transform.Find("Canvas/GameOverPanel").gameObject.SetActive(true);
            }).UnRegisterWhenGameObjectDestoryed(gameObject);
        }

        private void OnDestroy()
        {
            GetAchitecture().UnRegisterEvent<GamePassEvent>(OnGamePass);
        }

        private void OnGamePass(GamePassEvent e)
        {
            Debug.Log("结束");
            transform.Find("Canvas/GamePassPanel").gameObject.SetActive(true);
            transform.Find("Canvas/GamePassPanel").gameObject.SetActive(true);
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