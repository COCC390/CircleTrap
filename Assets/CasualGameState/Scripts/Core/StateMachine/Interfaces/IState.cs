namespace Konzit.CasualGame.State
{
    public interface IState
    {
        void Initialize();
        void OnState();
        void Dispose();
        void ChangeState(string stateName);
    }

}

