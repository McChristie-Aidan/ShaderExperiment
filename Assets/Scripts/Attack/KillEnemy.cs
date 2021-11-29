using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "Enemy")
        {
            Kill(other.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "Enemy")
        {
            Kill(collision.gameObject);
        }
    }

    void Kill(GameObject gameObject)
    {
        gameObject.GetComponent<Enemy>().enabled = false;
    }
}
