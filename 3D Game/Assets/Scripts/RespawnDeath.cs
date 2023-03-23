using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnDeath : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] List<GameObject> checkPoints;
    [SerializeField] Vector3 vectorPoint;
    [SerializeField] float dead;

    private void Update()
    {
        if(player.transform.position.y<-dead)
        {
            Die();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        vectorPoint=player.transform.position;
        Destroy(other.gameObject);
    }

        void Die()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<PlayerMovement>().enabled = false;
        Invoke(nameof(Respawn), 1.3f);
    }

    private void Respawn()
    {
        player.transform.position = vectorPoint;
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<PlayerMovement>().enabled = true;
    }
}
