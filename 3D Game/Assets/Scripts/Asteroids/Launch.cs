using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{    
    public Transform projectileSpawmPoint;
    public GameObject projectilePrefab;
    public float projectileSpeed = 10;
        
    public bool stopSpawning=false;
    public float spawnTime;
    public float spawnDelay;


    private void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }    
   
    public void SpawnObject()
    {
        var projectile = Instantiate(projectilePrefab, projectileSpawmPoint.position, projectileSpawmPoint.rotation);
        projectile.GetComponent<Rigidbody>().velocity = projectileSpawmPoint.forward * projectileSpeed;
        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
    }

}
