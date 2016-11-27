using UnityEngine;
using System.Collections;

public class tear1 : MonoBehaviour {

	float speed_tear;
	GameObject room;
	bool tearBeginMove;

	Animator ani_tear1;
	Vector3 roomReduce;

	void Start () {
		speed_tear = 2.0f;
		room = GameObject.Find ("room");
		tearBeginMove = false;
		ani_tear1 = GetComponent<Animator> ();

		roomReduce = new Vector3 (room.transform.position.x, room.transform.position.y -20.0f, room.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
	   
		if (tearBeginMove)
		{
			float step = speed_tear * Time.deltaTime;
			this.transform.position = Vector3.MoveTowards(this.transform.position, roomReduce, step);
			Debug.Log ("excute if");
		}

	}

	void tearGuide1 () 
	{
	//	Debug.Log ("tear go!");
		ani_tear1.SetTrigger ("tearflow");

		tearBeginMove = true;

	}
}
