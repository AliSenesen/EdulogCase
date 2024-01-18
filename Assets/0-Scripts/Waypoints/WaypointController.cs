using UnityEngine;

namespace _0_Scripts.Waypoints
{
    public class WaypointController : MonoBehaviour
    {
        public bool IsEnabled;

        [SerializeField] private WaypointManager manager;

        private void Start()
        {
            IsEnabled = true;
        }

        private void Update()
        {
            if (!IsEnabled)
            {
                manager.SetNextWaypoint();
                gameObject.SetActive(false);
            }
        }
    }
}