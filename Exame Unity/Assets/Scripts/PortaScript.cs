using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaScript : Interactable
{
    Animator anim;
    bool open = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Open", open);
    }

    public override void ActiveFuncion()
    {
        open = !open;
    }

    public bool Open { get => open; set => open = value; }
   
}
