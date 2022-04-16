using UnityEngine;

public abstract class State 
{
    protected PlayerController PlayerController;

    public State(PlayerController controller)
    {
        PlayerController = controller;
    }

    public virtual void Start() { }

    public virtual void Shoot(Vector3 destination) { }

    public virtual void Move() { }
}
