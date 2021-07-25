using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cam;
    [SerializeField] CinemachinePOV camPov;

    [SerializeField] Transform gameOverCameraPosition;

    [SerializeField] Vector3 gameOverCameraRotation;
    private void Start()
    {
        camPov = cam.GetCinemachineComponent<CinemachinePOV>();
    }
    public IEnumerator GameOverMovement()
    {
        float timeToMove = 0;

        while (timeToMove < 2)
        {
            timeToMove += Time.deltaTime;
            GameController.Instance.Player.transform.position = Vector3.Lerp(GameController.Instance.Player.transform.position, gameOverCameraPosition.transform.position, 2 * Time.deltaTime);
            camPov.m_HorizontalAxis.Value = Mathf.Lerp(camPov.m_HorizontalAxis.Value, gameOverCameraRotation.x, 2 * Time.deltaTime);
            camPov.m_VerticalAxis.Value = Mathf.Lerp(camPov.m_VerticalAxis.Value, gameOverCameraRotation.y, 2 * Time.deltaTime);

            yield return null;
        }
    }
}
