using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cam;
    
    [Header ("Sensibilidade eixo X")]
    [Range(0, 10)] [SerializeField] float sensitiveX;

    [Header("Sensibilidade eixo Y")]
    [Range(0, 10)][SerializeField] float sensitiveY;

    CinemachinePOV cameraPOV;

    InputPlayer input;
    Vector3 startRotation;

    private void Start()
    {
        input = GetComponent<InputPlayer>();
        cameraPOV = cam.GetCinemachineComponent<CinemachinePOV>();
        startRotation = transform.rotation.eulerAngles;
    }
    private void LateUpdate()
    {
        RotateCamera();
    }

    void RotateCamera()
    {
        cameraPOV.m_HorizontalAxis.m_InputAxisValue = input.GetMouseLook().x / sensitiveX;
        cameraPOV.m_VerticalAxis.m_InputAxisValue = input.GetMouseLook().y / sensitiveY;
    }

   
}
