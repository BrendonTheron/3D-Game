using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForce : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] float magnitude = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        rb.AddForce(Vector3.forward*magnitude, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
