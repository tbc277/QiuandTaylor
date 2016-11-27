using UnityEngine;
using System.Collections;

public class girl : MonoBehaviour {
	float x;
	float y;
	float current_x;
	float current_y;
	float timeCounter;
	float currentTime;

	Animator ani_girl;
	void Start () 
	{
		x = transform.position.x;
		y = transform.position.y;
		//Debug.Log ("x+y: " + x + ", "+ y);

		ani_girl= this.GetComponent<Animator> ();

		currentTime = 0;
	}
	

	void Update () 
	{
		

		//Debug.Log ("deltaTime: " + timeCounter);

//		if ((timeCounter - currentTime) > 1) 
//		{
			current_x = transform.position.x;
			current_y = transform.position.y;

//			if (Mathf.Abs (current_x - x) > 0.5 || Mathf.Abs (current_y - y) > 0.5) 
//			{
//				//Debug.Log("girl is moving");
//				ani_girl.SetBool ("left", true);
//
////			if (x < current_x) 
////			{
////				ani_girl.SetBool ("right", true);
////			}
////
//			}
//		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		//Debug.Log("girl is moving " +col.gameObject.name);

		if (col.gameObject.name == "Ball") 
		{
			//Debug.Log ("collide with Ball");
			ani_girl.SetBool ("left", true);

		}

	}

	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.name == "Ball") 
		{
			//Debug.Log ("collide with Ball");
			ani_girl.SetBool ("left", false);

		}
	}
}