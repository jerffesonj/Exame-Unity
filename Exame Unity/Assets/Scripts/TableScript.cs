using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableScript : MonoBehaviour
{
    public Transform[] locations;

    public bool itemOnTrigger;

    public Transform obj;

    public float moveTime;

    public int localIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (itemOnTrigger)
        {
            if (!GameController.Instance.Player.GetComponent<PlayerInteract>().IsHoldingItem)
            {
                obj.transform.position = Vector3.Lerp(obj.position, locations[localIndex].position, moveTime * Time.deltaTime);
                itemOnTrigger = false;

            }
        }
    }

    public void CheckItemInRange(bool value, Transform item, int itemLocationIndex)
    {
        itemOnTrigger = value;
        obj = item;
        localIndex = itemLocationIndex;
    }
}
