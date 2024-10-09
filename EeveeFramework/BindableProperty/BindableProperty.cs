using System.Collections;
using System;
using System.Collections.Generic;

namespace Framework
{
    public class BindableProperty<T> where T: IEquatable<T>
    {
        private T mValue = default(T);

        public T Value
        {
            get => mValue;
            set
            {
                if (!mValue.Equals(value))
                {
                    mValue = value;
                    mOnValueChange?.Invoke(value);
                }
            }
        }
        
        private Action<T> mOnValueChange = (v) => { };

        public IUnRegister RegisterOnValueChange(Action<T> onValueChange)
        {
            mOnValueChange += onValueChange;
            return new BindablePropertyUnRegister<T>()
            {
                BindableProperty = this,
                OnValueChange = onValueChange
            };
        }

        public void  UnResgisterOnValueChange(Action<T> onValueChange)
        {
            mOnValueChange -= onValueChange;
        }
    }

    public class BindablePropertyUnRegister<T> : IUnRegister where T : IEquatable<T>
    {
        public BindableProperty<T> BindableProperty { get; set; }
        public Action<T> OnValueChange { get; set; }
        public void UnRegister()
        {
            
        }
    }
}

