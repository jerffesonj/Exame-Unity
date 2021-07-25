using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowControlsCanvasTrigger : MonoBehaviour
{ 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameController.Instance.Canvas.ControlIndicator(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameController.Instance.Canvas.ControlIndicator(false);
        }
    }
}
