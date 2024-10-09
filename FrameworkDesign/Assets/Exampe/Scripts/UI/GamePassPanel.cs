using System;
using Framework;
using FrameworkDesign.Example.System;
using UnityEngine;
using UnityEngine.UI;

namespace FrameworkDesign.Example
{
    public class GamePassPanel:MonoBehaviour,IController
    {
        private void Start()
        {
            transform.Find("RemainSecondsText").GetComponent<Text>().text =
                "剩余时间：" + this.GetSystem<CountDownSystem>().CurrentRemainSeconds + "s";

            var gameModel = this.GetModel<IGameModel>();

            transform.Find("BestScoreText").GetComponent<Text>().text = "最高分数：" + gameModel.BestScore.Value;

            transform.Find("ScoreText").GetComponent<Text>().text = "分数：" + gameModel.Score.Value;
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