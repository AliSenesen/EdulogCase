#if UNITY_EDITOR
using NWH.NUI;
using UnityEditor;

namespace NWH.VehiclePhysics2.Multiplayer
{
    [CustomEditor(typeof(MirrorMultiplayerVehicle))]
    [CanEditMultipleObjects]
    public class MirrorMultiplayerVehicleEditor : NUIEditor
    {
        public override bool OnInspectorNUI()
        {
            if (!base.OnInspectorNUI())
            {
                return false;
            }

            MirrorMultiplayerVehicle mmv = target as MirrorMultiplayerVehicle;

            drawer.EndEditor();
            return true;
        }

        public override bool UseDefaultMargins()
        {
            return false;
        }
    }
}

#endif
