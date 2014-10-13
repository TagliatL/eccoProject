using UnityEngine;
using System.Collections;

public class InWater : MonoBehaviour {

	int gravityValue;
	bool inWater;

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
			if(gravityValue < 40)
				gravityValue++;
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		inWater = true;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		inWater = false;
	}
}
