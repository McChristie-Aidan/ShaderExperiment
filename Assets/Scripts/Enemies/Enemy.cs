using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState{ Attacking, Feared}

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

    private float effectTimeStamp;

    [SerializeField]
    GameObject fearTrigger;
    // Start is called before the first frame update
    void Start()
    {
        this.navMeshAgent = GetComponent<NavMeshAgent>();
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }

        state = EnemyState.Attacking;
    }

    // Update is called once per frame
    void Update()
    {
        //normal action
        if (state == EnemyState.Attacking)
        {
            navMeshAgent.SetDestination(target.transform.position);
        }
        //feared action
        if (state == EnemyState.Feared)
        {
            navMeshAgent.SetDestination(InverseTarget());
        }
        //return state to normal
        if (state != EnemyState.Attacking && effectTimeStamp < Time.time)
        {
            this.state = EnemyState.Attacking;
        }
    }
    //run away from target
    Vector3 InverseTarget()
    {
        Vector3 result = new Vector3();

        result = this.transform.position - target.transform.position;

        result = this.transform.position + result;

        return result;
    }
    public void ChangeState(EnemyState newState, float time) 
    {
        Debug.Log("StateChanged");
        this.state = newState;
        effectTimeStamp = Time.time + time;
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
        if (ScoreKeeper.Instance != null)
        {
            ScoreKeeper.Instance.score++;
        }
    }
}
