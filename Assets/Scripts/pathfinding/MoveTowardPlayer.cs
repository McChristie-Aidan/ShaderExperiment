using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MoveTowardPlayer : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    [SerializeField]
    public GameObject target;
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
}
