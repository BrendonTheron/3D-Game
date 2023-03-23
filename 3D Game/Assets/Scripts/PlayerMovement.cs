using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    SphereCollider sphere;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] AudioSource jump;
       
    public bool grounded = false;
    public float groundCheckDistance =.5f;
    private float bufferCheckDistance = 0.1f;
        
    [SerializeField] LayerMask ground;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sphere = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float vericalInput = Input.GetAxisRaw("Vertical");
                
        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, vericalInput * movementSpeed);
                
        groundCheckDistance = (sphere.radius) + bufferCheckDistance;
        
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);   
            jump.Play();
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDistance))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }

    
}
