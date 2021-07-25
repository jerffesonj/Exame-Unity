using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    
    [SerializeField] CanvasScript canvas;

    [SerializeField] GameObject player;

    int playerPoints;
    
    public int totalObjOnTable;

    bool on3Dview;
    
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        Control3DViewComponents(false);

        yield return new WaitForSeconds(1);

        Control3DViewComponents(true);

    }

    // Update is called once per frame
    void Update()
    {
        CheckTotalObjects();   
    }
    void CheckTotalObjects()
    {
        if (totalObjOnTable >= 3)
        {
            canvas.ShowGameOver();
        }
    }

    public void Control3DViewComponents(bool value)
    {
        Player.GetComponent<CameraMovement>().enabled = value;
        Player.GetComponent<PlayerInteract>().enabled = value;
        Player.GetComponent<PlayerController>().enabled = value;
    }

    public void AddPoints(int value)
    {
        playerPoints += value;
    }
    public void AddItemTable(int value)
    {
        totalObjOnTable += value;
    }

    public static GameController Instance { get => instance; }
    public CanvasScript Canvas { get => canvas; }
    public GameObject Player { get => player; }
    public int PlayerPoints { get => playerPoints; set => playerPoints = value; }
    public bool On3dView { get => on3Dview; set => on3Dview = value; }
}
