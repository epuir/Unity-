using System;
using System.Runtime.InteropServices;
using Framework;
 
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

namespace CounterApp
{
    public class CounterViewController:MonoBehaviour,IController
    {
        private ICounterModel mCounterModel;
        private void Start()
        {
            mCounterModel = this.GetModel<ICounterModel>();

            mCounterModel.Count.RegisterOnValueChange(OnCountChange);

            OnCountChange(mCounterModel.Count.Value);
            
            transform.Find("ButAdd").GetComponent<Button>().onClick.AddListener(() =>
            {
                //交互逻辑触发表现逻辑
                this.SendCommand<AddCountCommand>();
            });
            
            transform.Find("ButSub").GetComponent<Button>().onClick.AddListener(() =>
            {
               this.SendCommand<SubCountCommand>();
            });
            
        }

        private void OnCountChange(int obj)
        {
            transform.Find("CountText").GetComponent<Text>().text = mCounterModel.Count.Value.ToString();
        }

        private void OnDestroy()
        {
            mCounterModel.Count.UnResgisterOnValueChange(OnCountChange); 
            mCounterModel = null;
        }

        IArchitecture IBelongToArchitecture.GetAchitecture()
        {
            return CounterApp.Interface;
        }

         void ICanSetArchitecture.SetArchitecture(IArchitecture architecture)
        {
            throw new NotImplementedException();
        }
    }

    public interface ICounterModel:IModel
    {
        BindableProperty<int> Count { get; }
    }

    public  class CounterModel:AbstractModel,ICounterModel
    {
        protected override void Oninit()
        {
            Debug.Log("Count_Model构造");
            var storage = this.GetUillity<IStorage>();
            Count.Value = storage.LoadInt("COUNTER_COUNT");
            Count.RegisterOnValueChange(count =>
            {
                storage.SaveInt("COUNTER_COUNT", count);
            });
        }

        public  BindableProperty<int> Count { get; } = new BindableProperty<int>()
        {
            Value = 0
        };
        
    }
}