using UnityEngine;
using System.Collections;

public class Controlable : MonoBehaviour {

	int speed;
	public int rotationSpeed;
	public int maxSpeed;
	bool controller;
	public bool inWater;
	private string[] gamepadList;

	protected void FixedUpdate () {

		GetInput();
	}

	void Update() {

		gamepadList = Input.GetJoystickNames();
		
		if (gamepadList.Length > 0)
		{
			controller = true;
		}
		
		if (gamepadList.Length == 0)
		{
			controller = false;
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

	void GetInput() {

		rigidbody2D.velocity = new Vector3(0, 0, 0);

			if(controller == true) 
			{
				//Input Manette
				transform.Rotate(new Vector3(0,0,Input.GetAxis("L_XAxis_1"))* Time.deltaTime * rotationSpeed);
				rigidbody2D.AddForce(transform.right * speed);
				
				if ((Input.GetButton("A_1"))&&(this.GetComponent<InWater>().inWater == true))
				{
					if(speed < maxSpeed)
						speed+=2;
				}
				else
				{
					if(speed >=2)
						speed-=2;
				}
			}
			
			if(controller == false)
			{
				//Input Clavier
				transform.Rotate(new Vector3(0,0,Input.GetAxis("K_XAxis"))* Time.deltaTime * rotationSpeed);
				rigidbody2D.AddForce(transform.right * speed);
				
				if ((Input.GetButton("Space"))&&(this.GetComponent<InWater>().inWater == true))
				{
					if(speed < maxSpeed)
						speed+=2;
				}
				else
				{
					if(speed >=2)
						speed-=2;
				}
			}
		}
}
