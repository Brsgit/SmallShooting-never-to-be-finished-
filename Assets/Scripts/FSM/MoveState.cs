using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    public MoveState(PlayerController controller) : base(controller) { }

    public override void Move()
    {
        PlayerController.Waypoints.GetNextWaypoint().MoveTo();
    }
}
