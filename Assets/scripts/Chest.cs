using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable//inherits from collectable
{

    public Sprite emptyChest;
    public int pesosAmount = 5;
    protected override void OnCollect()
    {
        if(!collected){//if not collected
            collected=true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;//change to empty chest
            GameManager.instance.ShowText("+" + pesosAmount + " Pesos",25,Color.yellow,transform.position,Vector3.up * 100, 2.0f);
        }

    }
}
