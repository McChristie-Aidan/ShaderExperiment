using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField]
    protected int health = 1;
    public int Health { get { return health; } private set { health = value; } }
    public void TakeDamage()
    {
        this.TakeDamage(1);
    }
    public void TakeDamage(int damageAmount)
    {
        this.Health -= damageAmount;
    }
    public void Die()
    {
        Die(0);
    }
    public void Die(float timeTilDeath)
    {
        this.enabled = false;
        if (this.GetComponent<NavMeshAgent>() != null)
        {
            this.GetComponent<NavMeshAgent>().enabled = false;
            this.GetComponent<MoveTowardPlayer>().enabled = false;
        }
        Destroy(this.gameObject, timeTilDeath);
    }
}
