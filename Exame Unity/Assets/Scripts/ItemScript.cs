using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : Interactable
{
    [SerializeField] int points;

    [SerializeField] int locationTableIndex;

    [SerializeField] float moveTime;

    Transform location;
    Transform tableLocation;

    bool onTable;
    bool hold;

    Vector3 currentPos;

    void Start()
    {
        currentPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.Instance.On3dView)
        {
            if (location != null)
            {
                this.transform.position = Vector3.Lerp(transform.position, location.position, moveTime * Time.deltaTime);
            }
        }
        else
        {
            if (hold)
            {
                Interactable();
            }
            else
            {
                if (onTable)
                {
                    this.transform.position = Vector3.Lerp(transform.position, tableLocation.position, (moveTime / 3) * Time.deltaTime);
                }
                else
                {
                    this.transform.position = Vector3.Lerp(transform.position, currentPos, (moveTime / 3) * Time.deltaTime);
                }
                location = null;
            }
        }
    }

    void Interactable()
    {
        if (onTable)
        {
            this.transform.position = Vector3.Lerp(transform.position, tableLocation.position, (moveTime / 3) * Time.deltaTime);
            this.transform.position = Vector3.Lerp(transform.position, location.position, moveTime * Time.deltaTime);
            SaveLastPos();
        }
        else
        {
            this.transform.position = Vector3.Lerp(transform.position, location.position, moveTime * Time.deltaTime);
            SaveLastPos();
        }
    }

    public void SaveLastPos()
    {
        currentPos = this.transform.position;
    }

    public override void ActiveFuncion(float timeToMoveObject, Transform locationObject)
    {
        moveTime = timeToMoveObject;

        location = locationObject;

        GetComponent<BoxCollider>().isTrigger = true;

        hold = true;
    }

    public void ReleaseItem()
    {
        hold = false;
        if (!onTable)
        {
            location = null;

            GetComponent<BoxCollider>().isTrigger = false;
        }
    }


    public void CheckItemOnTableTrigger(bool value, TableScript table)
    {
        onTable = value;
        tableLocation = table.locations[locationTableIndex];
    }

    public float MoveTime { set => moveTime = value; }
    public int Points { get => points; }
    public bool OnTable { get => onTable; }
    public int LocalFinalIndex { get => locationTableIndex; }
    public Transform Location { set => location = value; }

}
