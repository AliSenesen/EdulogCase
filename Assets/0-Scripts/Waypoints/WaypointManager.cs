using UnityEngine;

namespace _0_Scripts.Waypoints
{
    public class WaypointManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] wayPointObjects;

        private int _currentIndex = 0;

        void Start()
        {
            InitializeWaypoints();
        }

        private void InitializeWaypoints()
        {
            for (int i = 0; i < wayPointObjects.Length; i++)
            {
                wayPointObjects[i].SetActive(i == _currentIndex);
            }
        }

        public void SetNextWaypoint()
        {
            _currentIndex++;
            if (_currentIndex < wayPointObjects.Length)
            {
                wayPointObjects[_currentIndex].SetActive(true);
            }
        }
    }
}