using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NoRotate : MonoBehaviour
{
    public Transform player;
    private Vector3 offset;
    Quaternion rotation;
    void Awake()
    {
        rotation = transform.rotation;        
    }

    void LateUpdate()
    {
        transform.rotation = rotation;
        transform.position = player.transform.position + offset;
    }
}
