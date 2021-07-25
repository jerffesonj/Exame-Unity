using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    Camera cam;
    InputPlayer input;

    float playerSpeed = 2.0f;
    Vector3 playerVelocity;
    
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        input = GetComponent<InputPlayer>();
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        Vector2 playerInput = input.GetMovement();

        Vector3 move = new Vector3(playerInput.x, 0, playerInput.y);

        move = cam.transform.forward * move.z + cam.transform.right * move.x;
        move.y = 0;

        controller.Move(move * Time.deltaTime * playerSpeed);
    }
}
