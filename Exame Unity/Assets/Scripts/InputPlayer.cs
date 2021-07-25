using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    PlayerControls playerControl;

    private void Awake()
    {
        playerControl = new PlayerControls();
    }
    private void OnEnable()
    {
        playerControl.Enable();
    }
    private void OnDisable()
    {
        playerControl.Enable();
    }
    public Vector2 GetMovement()
    {
        return playerControl.Player.Movement.ReadValue<Vector2>();
    }
    public Vector2 GetMouseLook()
    {
        return playerControl.Player.Look.ReadValue<Vector2>();
    }
    public bool GetInteract()
    {
        return playerControl.Player.Interact.triggered;
    }
    public bool GetInteractHold()
    {
        return playerControl.Player.InteractHold.triggered;
    }
    public bool GetInteractHoldCancel()
    {
        return playerControl.Player.InteractCancel.triggered;
    }
}
