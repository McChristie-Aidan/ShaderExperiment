using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FearTrigger : MonoBehaviour
{
    public float fearLength;
    private void OnTriggerEnter(Collider other)
    {
        Enemy e = other.GetComponent<Enemy>();

        if (e != null)
        {
            e.ChangeState(EnemyState.Feared, fearLength);
            Debug.Log("enemy feared");
        }

    }
}
