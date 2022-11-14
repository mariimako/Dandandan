using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collidable
{
    //Logic
    protected bool collected;//protected-->it is private, but children have acess, so chest has access
    protected override void OnCollide(Collider2D coll)
    {
        if(coll.name == "player0")
        OnCollect();
    }
    protected virtual void OnCollect(){
        collected = true;
    }
}
