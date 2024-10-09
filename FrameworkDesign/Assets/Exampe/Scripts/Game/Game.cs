using System;
using Exampe.Scripts.Event;
using Framework;
using UnityEngine;

namespace FrameworkDesign.Example
{
    public class Game:MonoBehaviour,IController
    {
        private void Awake()
        {
            Debug.Log("成功注册");
            this.RegisterEvent<GameStartEven>(OnGameStart);

            this.RegisterEvent<OnCountDownEndEvent>(e =>
            {
                transform.Find("Enemise").gameObject.SetActive(false);
            }).UnRegisterWhenGameObjectDestoryed(gameObject);
            
            this.RegisterEvent<GamePassEvent>(e =>
            {
                transform.Find("Enemise").gameObject.SetActive(false);
            }).UnRegisterWhenGameObjectDestoryed(gameObject);
        }
        

        private void OnDestroy()
        {
            this.UnRegisterEvent<GameStartEven>(OnGameStart);
            Debug.Log("销毁");
        }

        private void OnGameStart(GameStartEven e)
        {
            var enemyroot = transform.Find("Enemies");
            enemyroot.gameObject.SetActive(true);
            foreach (Transform enemy in enemyroot)
            {
                enemy.gameObject.SetActive(true);
            }
            Debug.Log("敌人");
            
            
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