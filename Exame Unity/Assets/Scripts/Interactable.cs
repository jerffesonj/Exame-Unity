using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable: MonoBehaviour
{
    public virtual void ActiveFuncion() { }

    public virtual void ActiveFuncion(float timeToMoveObject, Transform locationObject) { }

}
