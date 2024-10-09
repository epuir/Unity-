using System;
using Framework;
using FrameworkDesign.Example.System;
using UnityEngine;
using UnityEngine.UI;

namespace FrameworkDesign.Example
{
    public class GamePanel:MonoBehaviour,IController
    {
        private ICountDownSystem mCountDownSystem;
        private IGameModel mGameModel;

        private void Awake()
        {
            mCountDownSystem = this.GetSystem<ICountDownSystem>();
            mGameModel = this.mGameModel;

            mGameModel.Gold.RegisterOnValueChange(OnGoldValueChange);
            mGameModel.Life.RegisterOnValueChange(OnLifeValueChange);
            mGameModel.Score.RegisterOnValueChange(OnScoreValueChange);
        }

        private void OnGoldValueChange(int obj)
        {
            transform.Find("GoldText").GetComponent<Text>().text = "金币：" + obj;
        }

        private void OnLifeValueChange(int obj)
        {
            transform.Find("LifeText").GetComponent<Text>().text = "生命：" + obj;
        }

        private void OnScoreValueChange(int obj)
        {
            transform.Find("ScoreText").GetComponent<Text>().text = "分数：" + obj;
        }

        private void Update()
        {
            if (Time.frameCount % 20 == 0)
            {
                transform.Find("CountDownText").GetComponent<Text>().text = mCountDownSystem.CurrentRemainSeconds + "s";
                mCountDownSystem.Update();
            }
        }

        private void OnDestroy()
        {
            mGameModel.Gold.UnResgisterOnValueChange(OnGoldValueChange);
            mGameModel.Life.UnResgisterOnValueChange(OnLifeValueChange);
            mGameModel.Score.UnResgisterOnValueChange(OnScoreValueChange);
            mGameModel = null;
            mCountDownSystem = null;
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