using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class player : MonoBehaviour
{
	private BoxCollider2D boxCollider;
	
	private Vector3 moveDelta;

	private RaycastHit2D hit;

	private void Start()
	{
		boxCollider = GetComponent<BoxCollider2D>();
	}
	private void FixedUpdate()
	{
		//reset moveDelta
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");

		moveDelta = new Vector3(x,y,0);
		//swap sprite direction whether going right or left
		if (moveDelta.x > 0)
			transform.localScale = Vector3.one;
		else if (moveDelta.x < 0)
			transform.localScale = new Vector3(-1, 1, 1);
		//make sure if we can moveby casting a box there, if box retruns null, no other blocking
		hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));

		//move
		if (hit.collider == null)
        {
			transform.Translate(0,moveDelta.y * Time.deltaTime,0);
        } 

		//make sure if we can moveby casting a box there, if box retruns null, no other blocking
		hit = Physics2D.BoxCast(transform.position , boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));

		//move
		if (hit.collider == null)
		{
			transform.Translate(moveDelta.x * Time.deltaTime,0,0);
		}

	}
}

