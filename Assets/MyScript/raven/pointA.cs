using UnityEngine;
using System.Collections;

public class pointA : MonoBehaviour {

	GameObject raven1;
	Vector3 V3_raven1;
	//float disRaven1_Sun;
	GameObject sun;

	float speed_raven;
	Transform Tsun;

	bool isCollidePointA;

	Animator ani_sun;


	void Start () 
	{
		sun = GameObject.Find ("sun");
		raven1 = GameObject.Find ("raven1");

		Tsun = sun.transform;
		speed_raven = 0.5f;

		isCollidePointA = false;

		ani_sun = sun.GetComponent<Animator> ();


	}
	

	void Update () 
	{

		//Debug.Log ("Tsun: "+Tsun.position);
		//V3_raven1.x = raven1.transform.position.x ;

		if (isCollidePointA) //when colliding pointA
		{
			//Debug.Log ("collidePointA();");
		//raven fly into the scene and go to the position where the sun located
			float step = speed_raven * Time.deltaTime;
			raven1.transform.position = Vector3.MoveTowards(raven1.transform.position, Tsun.position, step);
			speed_raven = speed_raven + 0.05f;
        
			if (raven1.transform.position == sun.transform.position) 
			{
				//Debug.Log ("Eatin the sun");

				// play the animation"sun is eaten by the raven", when the animation play over, destroy the hills
				ani_sun.SetTrigger ("trigger_eatensun");

				//destroy itself	
				Destroy (gameObject);
			}

		}

	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		//Debug.Log (coll);	
    //raven come
		//V3_raven1.x = V3_raven1.x +1;
		//raven1.transform.position = V3_raven1;

		isCollidePointA = true;
	
	}


}
