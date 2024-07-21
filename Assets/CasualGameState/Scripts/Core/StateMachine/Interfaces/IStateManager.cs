namespace Konzit.CasualGame.State
{
    public interface IStateManager
    {
        void Initialize();
        void SwitchToState(string stateName);
    }

    //[Description("When create enum state name, please make sure create name of class state is the same with enum state name!!")]
    //public enum StateName
    //{ }
}
