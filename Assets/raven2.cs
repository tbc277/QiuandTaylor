﻿using UnityEngine;
using System.Collections;

public class raven2 : MonoBehaviour {

	Animator ani_raven2;
	bool isBigger;

	GameObject ball;
	Rigidbody2D rb_ball;

	GameObject girl;
	GameObject room;

	float timeCounter;
	float currentTime;

	bool is25;

	SpriteRenderer sr_room;
	SpriteRenderer sr_raven2;

	public Color color1 = Color.black;
	public Color color2 = Color.white;
	public float duration = 3.0F;
	Camera camera;
	GameObject cam;
	float t;

	void Start () {

		ani_raven2 = this.GetComponent<Animator> ();

		isBigger = false;

		ball = GameObject.Find ("Ball");
		rb_ball = ball.GetComponent<Rigidbody2D> ();

		girl = GameObject.Find ("girl");
		room = GameObject.Find ("room");

		sr_room = room.GetComponent<SpriteRenderer> ();
		sr_raven2 = this.GetComponent<SpriteRenderer> ();

		is25 = false;

		cam = GameObject.Find ("Main Camera");
		camera = cam.GetComponent<Camera>();

		sr_room.color = color2;

		t = 0f;
	}
	

	void Update () {


//		if (t <= 1.0f)
//		{
//			t += 0.01f;
//		}
//		//float t = Mathf.PingPong(Time.time, duration) / duration;
//		camera.backgroundColor = Color.Lerp(color1, color2, t);

		timeCounter += Time.deltaTime;
		
		if(isBigger)
		{
			//Debug.Log ("Bigger: " + this.gameObject.transform.localScale);

			//this.gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0);
		}

		if (this.gameObject.transform.localScale.x == 25.0f  && !is25) 
		{
			currentTime = timeCounter;
			//Debug.Log ("reach the max point");

			Destroy (girl);
			//Destroy (room);
			sr_room.enabled = false;

			is25 = true;
		}

		if ((timeCounter - currentTime) > 3.0f && is25)
		{


        //play cry animation
			sr_raven2.enabled = false;
		   //Destroy (gameObject);
		}

		if ((timeCounter - currentTime) > 7.0f && is25)
		{
		//room become white
			Debug.Log("greater than 7");
			sr_room.color = new Color(0f, 0f, 0f, 255f);


			if (t <= 1.0f)
			{
				t += 0.05f;
			}
		
			camera.backgroundColor = Color.Lerp(color1, color2, t);
			//camera.backgroundColor = color2;
		}
	}

	void OnCollisionEnter2D()
	{
		//Debug.Log ("touch the raven");
		ani_raven2.SetBool ("bigger", true);

		isBigger = true;
	}

	void whenBigger()
	{
		Debug.Log ("whenBigger");
		rb_ball.isKinematic = true;

		// say some word "depressed".
	}
}
