
public class MoveState : State
{
    public MoveState(PlayerController controller) : base(controller) { }

    public override void Move()
    {
        var waypoint = PlayerController.WaypointsController.GetNextWaypoint();
        if (waypoint != null)
        {
            var destination = waypoint.ProvideDestination();
            PlayerController.Agent.destination = destination;
        }
    }
}
