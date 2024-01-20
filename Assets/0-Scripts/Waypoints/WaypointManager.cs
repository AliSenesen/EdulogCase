using System;
using _0_Scripts.Events;
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

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            WaypointEvents.onWaypointPassed += OnWaypointPassed;
        }

        private void UnSubscribeEvents()
        {
            WaypointEvents.onWaypointPassed -= OnWaypointPassed;
        }


        private void OnDisable()
        {
            UnSubscribeEvents();
        }


        private void InitializeWaypoints()
        {
            for (int i = 0; i < wayPointObjects.Length; i++)
            {
                wayPointObjects[i].SetActive(i == _currentIndex);
            }
        }

        private void OnWaypointPassed()
        {
            SetNextWaypoint();
        }

        private void SetNextWaypoint()
        {
            if (_currentIndex >= 0 && _currentIndex < wayPointObjects.Length)
            {
                wayPointObjects[_currentIndex].SetActive(false);
            }

            _currentIndex++;
         
            if (_currentIndex < wayPointObjects.Length)
            {
                wayPointObjects[_currentIndex].SetActive(true);
            }
        }
    }
}