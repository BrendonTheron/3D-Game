using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDeletion : MonoBehaviour
{    
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(GameObject.FindWithTag("Enemy"));
    }
}
