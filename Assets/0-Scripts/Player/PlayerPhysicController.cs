using _0_Scripts.Waypoints;
using Mirror;
using UnityEngine;

namespace _0_Scripts.Player
{
    public class PlayerPhysicController : NetworkBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (isLocalPlayer)
            {
                if (other.TryGetComponent(out WaypointController wayPoint))
                {
                    wayPoint.IsEnabled = false;
                }
            }
        }
    }
}