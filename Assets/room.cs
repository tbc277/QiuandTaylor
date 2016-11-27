using UnityEngine;
using System.Collections;

public class room : MonoBehaviour {

	GameObject ball;
	GameObject c3;
	bool isAddRigidbody_c3;

	void Start () {
		ball = GameObject.Find ("Ball");

		c3 = GameObject.Find ("c3");
		isAddRigidbody_c3 = false;

	}


	void Update () {
		if (ball.transform.position.x > 109.29f && ball.transform.position.y < -9.61f && ball.transform.position.y > -16.62f && !isAddRigidbody_c3 ) //lock the door
		{
			//Debug.Log ("move into room");
			Rigidbody2D rb = c3.AddComponent<Rigidbody2D>();
			isAddRigidbody_c3 = true;
		}

		//need to add a 
	
	}


}
