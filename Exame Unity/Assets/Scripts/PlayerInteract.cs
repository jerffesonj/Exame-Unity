using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [Header("Posição que o item vai ficar")]
    [SerializeField] Transform locationObject;

    [Header ("Tempo do movimento do objeto")]
    [Range(0, 10)] [SerializeField] float timeToMoveObject;

    [Header("Distância do objecto pego em relação ao Jogador")] 
    [Range(0, 5)] [SerializeField] float objectDistance;
    
    Camera cam;
    InputPlayer input;
    ItemScript item;
    RotateObj rotateObj;
    float timeHoldingButton;
    bool isHoldingButton;
    bool isHoldingItem;

    void Start()
    {
        cam = GetComponent<Camera>();
        input = GetComponent<InputPlayer>();
        rotateObj = GetComponent<RotateObj>();
        locationObject.position = transform.position + transform.forward * objectDistance;
    }

    // Update is called once per frame
    void Update()
    {
        ButtonCheck();
        
        locationObject.position = transform.position + transform.forward * objectDistance;

        ReleaseItem();

        PlayerRaycast();
    }

    void ButtonCheck()
    {
        if (input.GetInteract() == true)
        {
            isHoldingButton = true;
        }
        if (input.GetInteractHoldCancel() == true)
        {
            isHoldingButton = false;
            timeHoldingButton = 0;
        }

        if (isHoldingButton)
        {
            timeHoldingButton += Time.deltaTime;
            if(timeHoldingButton >= 1)
            {
                timeHoldingButton=1;
            }
        }
    }

    void ReleaseItem()
    {
        if (input.GetInteractHoldCancel() == true)
        {
            if (isHoldingItem)
            {
                isHoldingItem = false;

                item.ReleaseItem();
                if (item.OnTable)
                {
                    GameController.Instance.AddPoints(item.Points);
                    GameController.Instance.AddItemTable(1);
                }
            }
        }
    }

    void PlayerRaycast()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, 1.5f))
        {
            Debug.DrawRay(cam.transform.position, cam.transform.forward * 1.5f, Color.red);

            InteractDoor(hit);

            InteractItem(hit);
        }
    }

    void InteractDoor(RaycastHit hit)
    {
        if (hit.transform.gameObject.CompareTag("Porta"))
        {
            if (input.GetInteract() == true)
            {
                hit.transform.gameObject.GetComponentInParent<PortaScript>().ActiveFuncion();
            }
        }
    }

    void InteractItem(RaycastHit hit)
    {
        if (hit.transform.gameObject.CompareTag("Item"))
        {
            if (isHoldingButton)
            {
                if (timeHoldingButton >= 0.015f)
                {
                    isHoldingItem = true;
                    item = hit.transform.GetComponent<ItemScript>();

                    hit.transform.GetComponent<Interactable>().ActiveFuncion(timeToMoveObject, locationObject);
                }

                if (timeHoldingButton < 0.015f)
                {
                    ItemScript itemScript = hit.transform.GetComponent<ItemScript>();

                    rotateObj.RotateObject = itemScript.transform;
                    rotateObj.enabled = true;

                    itemScript.SaveLastPos();
                    itemScript.Location = locationObject;
                    
                    if (timeToMoveObject != 0) 
                        itemScript.MoveTime = timeToMoveObject;

                    GameController.Instance.Canvas.Show3DView();
                }
            }
        }
    }

    public bool IsHoldingItem { get => isHoldingItem; set => isHoldingItem = value; }
    public bool IsHoldingButton { get => isHoldingButton; set => isHoldingButton = value; }
    public void ResetTimeHoldingButton() => timeHoldingButton = 0;
}
