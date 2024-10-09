namespace Framework.FSM
{
    public interface IState
    {
        void OnEnter();
        void OnExit();
        void OnUpdate();
        //void OnCheck();
        //void FixUpdate();
    }
}