using System.Linq;
using UnityEngine;

namespace Navigation
{
    [RequireComponent(typeof(WaypointContainer))]
    public class WaypointController : MonoBehaviour
    {
        private WaypointContainer _container;

        private int _nextWaypoint = 0;

        private void Awake()
        {
            _container = GetComponent<WaypointContainer>();
        }

        public IDestination GetNextWaypoint()
        {
            if (_nextWaypoint == _container.Waypoints.Count())
            {
                Debug.Log("Reached last destination point");
                return null;
            }
            return _container.Waypoints.ElementAt(_nextWaypoint++);
        }
    }

}
