using System;
using UnityEngine;

namespace Navigation
{
    public class Waypoint : MonoBehaviour, IDestination
    {
        private Transform _transform;

        private void Start()
        {
            _transform = transform;
        }

        public void MoveTo()
        {
            throw new NotImplementedException();
        }
    }
}
