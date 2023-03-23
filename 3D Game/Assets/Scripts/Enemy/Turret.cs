using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    Transform _Player;
    float dist;
    public float maxDist;
    public Transform head, cannon;
    public GameObject _bullet;
    [SerializeField] float bulletSpeed=20;
    public float fireRate, nextFire;

    // Start is called before the first frame update
    void Start()
    {
        _Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        dist=Vector3.Distance(_Player.position, transform.position);
        if (dist <= maxDist)
        {
            head.LookAt(_Player.position);
            if(Time.time >= nextFire)
            {
                nextFire = Time.time + 1f / fireRate;
                Shoot();
            }
            
        }
    }

    void Shoot()
    {
        GameObject clone = Instantiate(_bullet, cannon.position, cannon.rotation);
        clone.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
        Destroy(clone, 10);        
    }
}
