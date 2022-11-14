using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    public ContactFilter2D filter;
    private BoxCollider2D boxCollider;
    private Collider2D[] hits = new Collider2D[10];

    protected virtual void Start()//all collidables have box collider protected virtual void--> inheritance
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void Update()
    {//collision work
        boxCollider.OverlapCollider(filter, hits);//gets collided onbjects
        for (int i = 0; i < hits.Length; i++)//loop through array
        {
            if (hits[i] == null)
            {
                continue;
            }
            OnCollide(hits[i]);
            //clean up array
            hits[i] = null;
        }

    }

    protected virtual void OnCollide(Collider2D coll)
    {
       Debug.Log(coll.name);
    }

    
}
