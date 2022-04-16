
public class MoveState : State
{
    public MoveState(PlayerController controller) : base(controller) { }

    public override void Move()
    {
        PlayerController.Waypoints.GetNextWaypoint().MoveTo();
    }
}
