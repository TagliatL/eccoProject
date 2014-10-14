using UnityEngine;
using System.Collections;

public class InWater : MonoBehaviour {

	float gravityValue;
	public bool inWater;
	public float rotationExit;
	public float rotationEnter;
	GameObject splashParticle;

	void Start() {
		inWater = false;
		gravityValue = 40;
		splashParticle = GameObject.Find("Splash");
		splashParticle.SetActive(false);
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
			splashParticle.SetActive(false);
			if(gravityValue < 60)
				gravityValue+=0.2f;
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		splashParticle.SetActive(true);
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
		splashParticle.SetActive(true);
		inWater = false;
		rotationExit = this.transform.rotation.eulerAngles.z;
		//Debug.Log("Exit : " + rotationExit.ToString());
	}
}
