using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

enum EnemyState{ Attacking, Feared}

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour, IDamagable
{
    private EnemyState state = EnemyState.Attacking;

    [SerializeField]
    protected int health = 1;
    public int Health { get { return health; } private set { health = value; } }

    NavMeshAgent navMeshAgent;
    [SerializeField]
    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        this.navMeshAgent = GetComponent<NavMeshAgent>();
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(target.transform.position);
    }
    public void ChangeTarget(GameObject gameObject)
    {
        this.target = gameObject;
    }
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
        }
        Destroy(this.gameObject, timeTilDeath);
    }
}
