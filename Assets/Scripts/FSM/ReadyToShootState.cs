using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyToShootState : State
{
    public ReadyToShootState(PlayerController controller) : base(controller) { }

    public override void Start()
    {
        base.Start();
    }

    public override void Shoot()
    {
        base.Shoot();
    }
}
