using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    float spawnRate;
    float spawnTimeStamp;
    [SerializeField]
    float spawnDelay;
    float delayTimeStamp;

    [SerializeField]
    GameObject enemy;
    [SerializeField]
    GameObject target;

    private void Start()
    {
        delayTimeStamp = Time.time + spawnDelay;
    }
    // Update is called once per frame
    void Update()
    {
        if (delayTimeStamp < Time.time)
        {
            if (spawnTimeStamp < Time.time)
            {
                MoveTowardPlayer agent = Instantiate(enemy, this.transform).GetComponent<MoveTowardPlayer>();
                if (agent != null)
                {
                    agent.target = this.target;
                }

                spawnTimeStamp = Time.time + spawnRate;
            }
        }  
    }
}
