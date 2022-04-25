using UnityEngine;

namespace Core
{
    public class WinState : State
    {
        public WinState(PlayerController controller) : base(controller) { }

        public override void Win()
        {
            Debug.Log("You won!");
        }
    }

}
