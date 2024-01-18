using System.Collections.Generic;
using System.Linq;
using Mirror;
using Mirror.Experimental;
using NWH.Common.Vehicles;
using NWH.VehiclePhysics2.Sound.SoundComponents;
using UnityEngine;
using NetworkTransform = Mirror.NetworkTransform;

namespace NWH.VehiclePhysics2.Multiplayer
{
    /// <summary>
    ///     Adds multi-player functionality to a vehicle through Mirror networking.
    /// </summary>
    [RequireComponent(typeof(NetworkIdentity))]
    [RequireComponent(typeof(VehicleController))]
    public class MirrorMultiplayerVehicle : NetworkBehaviour
    {
        private NetworkIdentity _networkIdentity;
        private VehicleController _vehicleController;
        private bool _vehicleInitialized = false;

        private void Awake()
        {
            _networkIdentity = GetComponent<NetworkIdentity>();
            _vehicleController = GetComponent<VehicleController>();
            _vehicleController.onVehicleInitialized.AddListener(() =>
            {
                _vehicleInitialized = true;
                _vehicleController.MultiplayerIsRemote = !_networkIdentity.isOwned;

            });
        }


        private void Update()
        {
            if (!_vehicleInitialized) return;

            if (_networkIdentity.isServerOnly)
            {
                RpcMultiplayerState(_vehicleController.GetMultiplayerState());
            }
            else if (_networkIdentity.isOwned)
            {
                CmdMultiplayerState(_vehicleController.GetMultiplayerState());
            }
        }


        [Command]
        private void CmdMultiplayerState(VehicleController.MultiplayerState value)
        {
            if (_vehicleInitialized) RpcMultiplayerState(value);
        }


        [ClientRpc]
        private void RpcMultiplayerState(VehicleController.MultiplayerState value)
        {
            if (_vehicleInitialized && !_networkIdentity.isOwned) _vehicleController.SetMultiplayerState(value);
        }
    }
}