using System;
using System.Collections.Generic;

namespace Framework
{
    public interface IArchitecture
    {
        void RegisterSystem<T>(T system) where T : ISystem;
        void RegisterUtillity<T>(T uutillity) where T:IUtility;
        void RegisterModel<T>(T model) where T:IModel;

        T GetModel<T>() where T : class,IModel;
        T GetUtility<T>() where T : class,IUtility;

        T GetSystem<T>() where T : class, ISystem;
        void SendCommand<T>() where T : ICommand, new();
        void SendCommand<T>(T command) where T : ICommand;

        void SendEvent<T>() where T : new();

        void SendEvent<T>(T e);

        IUnRegister RegisterEvent<T>(Action<T> onEvent);

        void UnRegisterEvent<T>(Action<T> onEvent);


    }
    public abstract class  Architecture<T> :IArchitecture where T:Architecture<T>,new()
    {
        /// <summary>
        /// 是否初始化
        /// </summary>
        private bool mInited = false;

        private List<ISystem> mSystems = new List<ISystem>();
        private List<IModel> mModels = new List<IModel>();

        public static Action<T> OnRegisterPatch = architecture => { };
        
        private static T mArchitecture;

        private IOCContainer mContainer = new IOCContainer();
        
        public static IArchitecture Interface
        {
            get
            {
                if (mArchitecture == null)
                {
                    MakeSureArchitecture();
                }

                return mArchitecture;
            }
        }
        static void MakeSureArchitecture()
        {
            
            if (mArchitecture == null)
            {
                mArchitecture = new T();
                mArchitecture.Init();

                OnRegisterPatch?.Invoke(mArchitecture);
                foreach (var architectureModel in mArchitecture.mModels)
                {
                    architectureModel.Init();
                }
                mArchitecture.mModels.Clear();

                foreach (var architecturesystem in mArchitecture.mSystems)
                {
                    architecturesystem.Init();
                }
                mArchitecture.mSystems.Clear();
                
                mArchitecture.mInited = true;
            }
        }

        protected abstract void Init();

        // public static T Get<T>() where T : class
        // {
        //     MakeSureArchitecture();
        //     return mArchitecture.mContainer.Get<T>();
        // }
        //
        // public static void Register<T>(T instance)
        // {
        //     MakeSureArchitecture();
        //     mArchitecture.mContainer.Register(instance);
        // }

        public void RegisterSystem<T>(T system) where T : ISystem
        {
            system.SetArchitecture(this);
            mContainer.Register<T>(system);
            if (!mInited)
            {
                mSystems.Add(system);
            }
            else
            {
                system.Init();
            }

        }

        public void RegisterUtillity<T>(T utillity) where T:IUtility
        {
            mContainer.Register<T>(utillity);
        }

        public void RegisterModel<T>(T model) where T :IModel
        {
            model.SetArchitecture(this);
            mContainer.Register<T>(model);
            if (!mInited)
            {
                mModels.Add(model);
            }
            else
            {
                model.Init();
            }
           
        }

        public T GetModel<T>() where T : class,IModel
        {
            return mContainer.Get<T>();
        }

        public T GetUtility<T>() where T : class,IUtility
        {
            return mContainer.Get<T>();
        }

        public T GetSystem<T>() where T : class, ISystem
        {
            return mContainer.Get<T>();
        }

        public void SendCommand<T>() where T : ICommand, new()
        {
            var command = new T();
            command.SetArchitecture(this);
            command.Execute();
        }

        public void SendCommand<T>(T command) where T : ICommand
        {
            command.SetArchitecture(this);
            command.Execute();
        }

        private ITypeEvnetSystem mTypeEvnetSystem = new TypeEventSystem();
        
        public void SendEvent<T>() where T : new()
        {
           mTypeEvnetSystem.Send<T>();
        }

        public void SendEvent<T>(T e)
        {
            mTypeEvnetSystem.Send<T>(e);
        }

        public IUnRegister RegisterEvent<T>(Action<T> onEvent)
        {
            return mTypeEvnetSystem.Register(onEvent);
        }

        public void UnRegisterEvent<T>(Action<T> onEvent)
        {
            mTypeEvnetSystem.UnRegister(onEvent);
        }
    }
}

