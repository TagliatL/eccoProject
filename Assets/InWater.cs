using UnityEngine;
using System.Collections;

public class InWater : MonoBehaviour {

	int gravityValue;
	public bool inWater;
	public float rotationExit;
	public float rotationEnter;

	void Start() {
		inWater = false;
		gravityValue = 40;
	}

	
	void Update() {
		
		rigidbody2D.gravityScale = gravityValue;

		ApplySmoothToGravity();
	}

	void ApplySmoothToGravity() {

		if(inWater == true)
		{
			if(gravityValue > 0)
				gravityValue--;
		}

		if(inWater == false)
		{
			if(gravityValue < 100)
				gravityValue++;
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		inWater = true;
		rotationEnter = this.transform.rotation.eulerAngles.z;
		if ((rotationEnter <= rotationExit+10)||(rotationEnter >= rotationExit-10))
		{
			Debug.Log("Squalala");
		}
		//Debug.Log("Enter : " + this.transform.rotation.z);
	}

	void OnTriggerExit2D(Collider2D other)
	{
		inWater = false;
		rotationExit = this.transform.rotation.eulerAngles.z;
		//Debug.Log("Exit : " + rotationExit.ToString());
	}
}
