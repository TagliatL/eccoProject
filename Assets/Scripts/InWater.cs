using UnityEngine;
using System.Collections;

public class InWater : MonoBehaviour {

	float gravityValue;
	public bool inWater;
	public float rotationExit;
	public float rotationEnter;
	GameObject splashParticle;

	void Start() {
		inWater = true;
		gravityValue = 0;
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
				gravityValue-=2;
		}

		if(inWater == false)
		{
			splashParticle.SetActive(false);
			if(gravityValue < 60)
				gravityValue+=0.5f;
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		splashParticle.SetActive(true);
		splashParticle.transform.parent = null;
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
		splashParticle.transform.parent = this.transform;
		splashParticle.transform.position = this.transform.position;
		splashParticle.transform.localScale = new Vector3(1,1,1);
		splashParticle.SetActive(true);
		inWater = false;
		rotationExit = this.transform.rotation.eulerAngles.z;
		//Debug.Log("Exit : " + rotationExit.ToString());
	}
}
