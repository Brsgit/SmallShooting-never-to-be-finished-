using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Navigation
{
    public class WaypointsContainer : MonoBehaviour
    {
        private List<IDestination> _waypoints;

        private int _nextWaypoint = 0;

        public IEnumerable<IDestination> Waypoints => _waypoints;

        private void Start()
        {
            _waypoints = GetComponentsInChildren<IDestination>().ToList();
        }

        public IDestination GetNextWaypoint()
        {
            if (_nextWaypoint == _waypoints.Count)
            {
                Debug.Log("Reached last destination point");
                return null;
            }
            return _waypoints[_nextWaypoint++];
        }

    }
}

