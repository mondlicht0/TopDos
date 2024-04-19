namespace TopDos.Enemies.FSM
{
    public interface IState
    {
        void Enter();
        void LogicUpdate();
        void PhysicsUpdate();
        void Exit();
    }
}
