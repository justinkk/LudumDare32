using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {	
	public float speed;

	private bool pulling; //true iff trying to pull the AOL disk

	// FixedUpdate is called once per physics step
	void FixedUpdate() {
		//Figure out which direction to go
		int up = 0, left = 0;

		if (Input.GetKey(KeyCode.W))
			up += 1;
		if (Input.GetKey(KeyCode.A)) 
			left += 1;
		if (Input.GetKey(KeyCode.S))
			up -= 1;
		if (Input.GetKey(KeyCode.D))
			left -=1;
		if (Input.GetKey("up"))
			up += 1;
		if (Input.GetKey("left"))
			left += 1;
		if (Input.GetKey("down"))
			up -= 1;
		if (Input.GetKey("right"))
			left -= 1;

		//Calculate velocity
		Vector2 newVelocity = Vector2.zero;

		if (up > 0)
			newVelocity.y = 1;
		else if (up < 0)
			newVelocity.y = -1;
		if (left > 0)
			newVelocity.x = -1;
		else if (left < 0)
			newVelocity.x = 1;

		newVelocity = newVelocity.normalized;
		newVelocity *= speed;
		GetComponent<Rigidbody2D>().velocity = newVelocity;

		//Set if you're pulling
		pulling = Input.GetKey(KeyCode.Space);
	}

	//Return true iff you are trying to pull the disk toward you
	public bool isPulling() {
		return pulling;
	}
}
