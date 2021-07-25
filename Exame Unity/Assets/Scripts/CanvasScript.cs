using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CanvasScript : MonoBehaviour
{
    [SerializeField] TMP_Text playerScoreText;

    GameOverScript gameOverScript;

    [SerializeField] GameObject playerInfo;
    [SerializeField] GameObject view3D;
    [SerializeField] GameObject GameOver;

    [SerializeField] GameObject indicador;
    
    [SerializeField] GameObject fadeIn;

    bool gameOverOnce;

    private void Start()
    {
        gameOverScript = GetComponent<GameOverScript>();
    }

    void Update()
    {
        playerScoreText.text = GameController.Instance.PlayerPoints.ToString();
        
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ShowGameOver()
    {
        if (!gameOverOnce) 
        {
            gameOverOnce = true;
            StartCoroutine(GameOverEnum());
        }
    }

    IEnumerator GameOverEnum()
    {
        GameController.Instance.Control3DViewComponents(false);

        StartCoroutine(gameOverScript.GameOverMovement());

        yield return new WaitForSeconds(2f);

        fadeIn.SetActive(true);
        GameOver.SetActive(true);
    }

    public void Show3DView()
    {
        GameController.Instance.On3dView = true;

        playerInfo.SetActive(false);
        view3D.SetActive(true);

        GameController.Instance.Control3DViewComponents(false);
    }

    public void Close3DView()
    {
        playerInfo.SetActive(true);
        view3D.SetActive(false);

        GameController.Instance.On3dView = false;

        GameController.Instance.Player.GetComponent<RotateObj>().enabled = false;

        GameController.Instance.Control3DViewComponents(true);

        GameController.Instance.Player.GetComponent<PlayerInteract>().IsHoldingButton = false;
        GameController.Instance.Player.GetComponent<PlayerInteract>().ResetTimeHoldingButton();
    }

    public void ControlIndicator(bool value)
    {
        indicador.SetActive(value);
    }

    public GameObject Indicador { get => indicador; }

}
