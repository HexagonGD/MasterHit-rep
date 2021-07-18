namespace HitMaster.States
{
    public interface IState
    {
        void Begin();
        void End();
        void OnClick();
        void OnUpdate();
    }
}