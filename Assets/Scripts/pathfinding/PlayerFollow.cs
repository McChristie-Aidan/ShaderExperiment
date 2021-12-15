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
    // Start is called before the first frame update
    void Start()
    {
        player = this.GetComponent<NavMeshAgent>();
        cam = Camera.main;
        player = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        mouse = Mouse.current;
    }
    public void OnClick(InputAction.CallbackContext context)
    {
        Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (context.started == true)
            {
                player.SetDestination(hit.point);
                Instantiate(particleEffect).transform.position = hit.point;
            }
        }
    }
}
