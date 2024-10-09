using System;
using Exampe.Scripts.Command;
using Framework;
using UnityEngine;
using UnityEngine.UI;

namespace FrameworkDesign.Example
{
    public class GametartPanel:MonoBehaviour,IController
    {
        private IGameModel mGameModel;
        private void Start()
        {
            GameObject.Find("BtnStart").GetComponent<Button>().onClick.AddListener(() =>
            {
                GameObject.Find("Canvas/GameStartPanel").gameObject.SetActive(false);
                this.SendCommand<StartGameCommand>();
            });
            
            transform.Find("BtnBuyLife").GetComponent<Button>().onClick.AddListener(() =>
            {
                this.SendCommand<BuyLifeCommand>();
            });

            mGameModel = this.GetModel<IGameModel>();
            mGameModel.Gold.RegisterOnValueChange(OnGoldValueChange);
            mGameModel.Life.RegisterOnValueChange(OnLifeValueChange);
            
            OnLifeValueChange(mGameModel.Life.Value);
            OnGoldValueChange(mGameModel.Gold.Value);

            transform.Find("BestScoreText").GetComponent<Text>().text = "最高分：" + mGameModel.BestScore.Value;
        }

        private void OnLifeValueChange(int obj)
        {
            transform.Find("LifeText").GetComponent<Text>().text = "生命：" + obj;
        }

        private void OnGoldValueChange(int obj)
        {
            if (obj > 0)
            {
                transform.Find("BtnBuyLife").gameObject.SetActive(true);
            }
            else
            {
                transform.Find("BtnBuyLife").gameObject.SetActive(false);
            }

            transform.Find("GoldText").GetComponent<Text>().text = "金币：" + obj;
        }

        private void OnDestroy()
        {
            mGameModel.Gold.UnResgisterOnValueChange(OnGoldValueChange);
            mGameModel.Life.UnResgisterOnValueChange(OnLifeValueChange);
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