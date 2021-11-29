using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Camera cam;
    GameObject go;
    GameObject player;
    InputDevice mouse;
    [SerializeField]
    GameObject pointerEffect;
    private void Start()
    {
        cam = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        mouse = Mouse.current;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
        Plane groundPlane = new Plane(Vector3.up, player.transform.position);

        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance))
        {
            if (context.started == true)
            {
                Vector3 point = ray.GetPoint(rayDistance);
                Instantiate(pointerEffect).transform.position = point;
            }
        } 
    }
}
