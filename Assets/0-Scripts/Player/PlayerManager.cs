using _0_Scripts.Waypoints;
using DG.Tweening;
using Mirror;
using UnityEngine;

namespace _0_Scripts.Player
{
    public class PlayerManager : NetworkBehaviour
    {
        private Vector3 _startPosPlayer1 = new Vector3(-4.5f, -0.01f, 0f);
        private Vector3 _startPosPlayer2 = new Vector3(4.5f, -0.01f, 0f);

        public void Start()
        {
            SetStartPositions();
        }

        private void SetStartPositions()
        {
            if (isLocalPlayer)
            {
                if (isServer)
                {
                    transform.DOMove(_startPosPlayer1, .5f);
                }
                else
                {
                    transform.DOMove(_startPosPlayer2, .5f);
                }
            }
        }

       
    }
}