using UnityEngine;
using System.Collections;

public class MoveFloorFlip : MonoBehaviour {

	float x, StartX;
	private Vector2 v = new Vector2();
	bool left;
	// Use this for initialization
	void Start()
	{
		v.x = transform.position.x;
		v.y = transform.position.y;
		x = v.x;
		StartX = x; 
		left = false;
	}
	//this is a comment
	// Update is called once per frame
	void Update()
	{
		// If the input is moving the player right and the player is facing left...
		if (x > 0 && !left)
			// ... flip the player.
			Flip();

		// Otherwise if the input is moving the player left and the player is facing right...
		else if (x < 0 && left)
			// ... flip the player.
			Flip();
		
		if (left)
		{
			x += -.05F;
		}
		else
		{
			x += .05F;
		}
		if (transform.position.x >= StartX+10)
		{

			left = true;

		}
		if (transform.position.x <= StartX)
		{
			left = false;
		}
		v.x = x;
		this.transform.position = v;
	}
	void FixedUpdate()
	{


	}

	void Flip()
	{
		// Switch the way the player is labelled as facing.
		//facingRight = !facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}

