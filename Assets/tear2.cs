using UnityEngine;
using System.Collections;

public class tear2 : MonoBehaviour {

	float speed_tear;
	GameObject room;
	bool tearBeginMove;

	Animator ani_tear2;

	void Start () {
	
		speed_tear = 2.0f;
		room = GameObject.Find ("room");
		tearBeginMove = false;
		ani_tear2 = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () 
	{
	
		if (tearBeginMove)
		{
			float step = speed_tear * Time.deltaTime;
			this.transform.position = Vector3.MoveTowards(this.transform.position, room.transform.position, step);
			Debug.Log ("excute if");
		}

	}

	void tearGuide2 () 
	{


		tearBeginMove = true;

	}
}
