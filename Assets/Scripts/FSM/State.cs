using UnityEngine;

namespace Core
{
    public abstract class State
    {
        protected PlayerController PlayerController;

        public State(PlayerController controller)
        {
            PlayerController = controller;
        }

        public virtual void Win() { }

        public virtual void Shoot(Vector3 destination) { }

        public virtual void Move() { }
    }

}
