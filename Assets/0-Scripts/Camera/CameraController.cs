using Mirror;
using UnityEngine;

public class CameraController : NetworkBehaviour
{
    [SerializeField] private Transform playerTransform;

    [SerializeField] private float distanceZ = -5f;
    [SerializeField] private float distanceY = 2f;
    [SerializeField] private float smoothSpeed = 2f;

    private Vector3 _targetPos;

    private void Start()
    {
        if (!isLocalPlayer)
        {
            gameObject.SetActive(false);
        }
    }
    
    void LateUpdate()
    {
        _targetPos = playerTransform.position + playerTransform.forward * distanceZ + Vector3.up * distanceY;

        transform.position = Vector3.Lerp(transform.position, _targetPos, Time.deltaTime * smoothSpeed);

        transform.LookAt(playerTransform.position);
    }
}