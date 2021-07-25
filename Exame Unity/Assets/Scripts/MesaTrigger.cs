using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MesaTrigger : MonoBehaviour
{
    public TableScript table;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ItemScript>())
        {
            ItemScript item = other.GetComponent<ItemScript>();

            table.CheckItemInRange(true, item.transform, item.LocalFinalIndex);

            item.CheckItemOnTableTrigger(true, table);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<ItemScript>())
        {
            ItemScript item = other.GetComponent<ItemScript>();

            table.CheckItemInRange(false, null, -1);

            item.CheckItemOnTableTrigger(false, table);


        }
    }
}
