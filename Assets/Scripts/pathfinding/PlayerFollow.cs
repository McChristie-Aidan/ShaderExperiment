using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerFollow : MonoBehaviour
{
    Camera cam;
    InputDevice mouse;
    NavMeshAgent player;

    [SerializeField]
    GameObject particleEffect;

    [SerializeField]
    public GameObject[] waypoints;

    int currentWaypoint = 0;
    [SerializeField]
    float waypointDist = .5f;
    // Start is called before the first frame update
    void Start()
    {
        player = this.GetComponent<NavMeshAgent>();
        cam = Camera.main;
        player = GetComponent<NavMeshAgent>();
        waypoints = GameObject.FindGameObjectsWithTag("Waypoints");
    }

    // Update is called once per frame
    void Update()
    {
        mouse = Mouse.current;

        if (Vector3.Distance(waypoints[currentWaypoint % waypoints.Length].transform.position, this.transform.position) < waypointDist)
        {
            currentWaypoint++;
        }

        player.SetDestination(waypoints[currentWaypoint % waypoints.Length].transform.position);
    }
    public void OnClick(InputAction.CallbackContext context)
    {
        //Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
        //RaycastHit hit;

        //if (Physics.Raycast(ray, out hit))
        //{
        //    if (context.started == true)
        //    {
        //        player.SetDestination(hit.point);
        //        Instantiate(particleEffect).transform.position = hit.point;
        //    }
        //}
    }
}
