using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObj : MonoBehaviour
{
    [Header ("Velocidade do giro do objeto")]
    [SerializeField] float rotationSpeed = 20;

    Transform rotateObject;
    InputPlayer input;
    bool holding;

    private void Start()
    {
        input = GetComponent<InputPlayer>();
    }
    private void Update()
    {
        CheckInput();

        Rotate();
    }

    void CheckInput()
    {
        if (input.GetInteractHold())
            holding = true;

        if (input.GetInteractHoldCancel())
            holding = false;
    }

    void Rotate()
    {
        if (holding)
        {
            float rotX = input.GetMouseLook().x * rotationSpeed;
            float rotY = input.GetMouseLook().y * rotationSpeed;

            rotateObject.Rotate(Vector3.up, -rotX);
            rotateObject.Rotate(Vector3.right, rotY);
        }
    }

    public Transform RotateObject { set => rotateObject = value; }
}

