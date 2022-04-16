using System.Collections.Generic;
using UnityEngine;

namespace Navigation
{
    public class WaypointsContainer : MonoBehaviour
    {
        [SerializeField] private List<IDestination> _waypoints;

        private int _nextWaypoint = 0;

        public IEnumerable<IDestination> Waypoints => _waypoints;

        public IDestination GetNextWaypoint()
        {
            return _waypoints[_nextWaypoint++];
        }

    }
}

