using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Navigation
{
    public class WaypointContainer : MonoBehaviour
    {
        private List<IDestination> _waypoints;
        public IEnumerable<IDestination> Waypoints => _waypoints;

        private void Start()
        {
            _waypoints = GetComponentsInChildren<IDestination>().ToList();
        }

    }
}

