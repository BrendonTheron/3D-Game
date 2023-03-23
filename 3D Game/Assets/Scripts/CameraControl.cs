
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    /*public GameObject player;

    private Vector3 offset;

    

    private void Start()
    {
        offset = transform.position - player.transform.position;
    }

    

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }*/
    public Transform PlayerTransform;

    private Vector3 _cameraOffset;

    [Range(0.01f, 1f)]
    public float SmoothFactor;

    public bool LookAtPlayer = false;

    public bool RotateAroundPlayer = true;

    public float RoataionSpeed = 5f;

    private void Start()
    {
        _cameraOffset = transform.position - PlayerTransform.position;
    }

    private void LateUpdate()
    {
        if (RotateAroundPlayer)
        {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RoataionSpeed, Vector3.up);

            _cameraOffset = camTurnAngle * _cameraOffset;
        }

        Vector3 newPos = PlayerTransform.position + _cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);

        if(LookAtPlayer || RotateAroundPlayer)
        {
            transform.LookAt(PlayerTransform);
        }
    }
}
