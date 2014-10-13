using UnityEngine;
using System.Collections;

public class Controlable : MonoBehaviour {

	public int speed;
	protected void FixedUpdate () {

		GetInput();
	}

	void GetInput() {
		transform.Rotate(new Vector3(0,0,Input.GetAxis("L_XAxis_1"))* Time.deltaTime * speed);

		if (Input.GetButtonDown("A_1"))
			rigidbody.AddForce(new Vector3(0, Input.GetAxis("L_XAxis_1"), 0) * 500);	
	}
}
