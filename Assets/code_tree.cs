﻿using UnityEngine;
using System.Collections;

public class code_tree : MonoBehaviour {

	Animator ani_treeGrow;

	GameObject tear;

	GameObject shadowtear;
	SpriteRenderer sr_shadowtear;

	float shadowtear_y;

	//bool isTearTouchwithBall;

	float startShadowTear_localy;
	float currentShadowTear_y;

	Camera camera;
	GameObject cam;
	float t;

	GameObject ball;
	Rigidbody2D rb_ball;

	GameObject room;
	GameObject raven2;

	SpriteRenderer sr_room;
	SpriteRenderer sr_ball;
	SpriteRenderer sr_raven2;
    // need a terre

	public bool isRaven2cloneStart;

	float timeCounter;
	float teardropBegin;
	bool isFirstTearDrop;
	bool isCry;
	int ranTear1;
	int ranTear2;
	int ranTear3;
	bool isTearTimeOver;
	bool isTearHitBall;

	float lengthRole;

	float shadowtearloacal_y;

	GameObject c1;
	GameObject c2;
	GameObject c3;

	GameObject lflyraven;
	Animator ani_flyraven;
	SpriteRenderer sr_flayraven;

	float step;
	GameObject lmark1;

	SpriteRenderer sp_tree;

	public AudioClip au_7;
	public AudioClip au_8;

	private AudioSource source;

	void Start () 
	{
		
//		tear = Instantiate(Resources.Load("tree_tear")) as GameObject;
//		tear.transform.position = new Vector3 (110.0f, -2.5f,0);
//
//		tear = Instantiate(Resources.Load("tree_tear")) as GameObject;
//		tear.transform.position = new Vector3 (112.0f, -2.5f,0);

//		tear = Instantiate(Resources.Load("tree_tear")) as GameObject;
		ani_treeGrow = GetComponent<Animator> ();
		//Debug.Log (ani_treeGrow);

		shadowtear = GameObject.Find ("shadow_tear");
		sr_shadowtear = shadowtear.GetComponent<SpriteRenderer> ();
		sr_shadowtear.enabled = false;

		//isTearTouchwithBall = false;

		startShadowTear_localy = shadowtear.transform.localPosition.y;
		//Debug.Log ("v3: "+ startV3ShadowTear);

		currentShadowTear_y = 10.0f; 
		lengthRole = 5.5f;// equals the length of the role;

		cam = GameObject.Find ("Main Camera");
		camera = cam.GetComponent<Camera>();

		ball = GameObject.Find ("Ball");
		rb_ball = ball.GetComponent<Rigidbody2D> ();

		room = GameObject.Find ("room");
		raven2 = GameObject.Find ("raven2");

		sr_raven2 = raven2.GetComponent<SpriteRenderer> ();
		sr_room = room.GetComponent<SpriteRenderer> ();
		sr_ball = ball.GetComponent<SpriteRenderer> ();

		isRaven2cloneStart = false;

		isFirstTearDrop = false;

		isCry = false;

		isTearTimeOver = false;

		isTearHitBall = false;

		t = 0f;

		c1 = GameObject.Find ("c1");
		c2 = GameObject.Find ("c2");
		c3 = GameObject.Find ("c3");
		//Debug.Log (c1);

		lflyraven = GameObject.Find ("flyaniraven");
		ani_flyraven = lflyraven.GetComponent<Animator> ();
		sr_flayraven = lflyraven.GetComponent<SpriteRenderer> ();
		sr_flayraven.enabled = false;

		lmark1 = GameObject.Find ("mark1");

		sp_tree = this.GetComponent<SpriteRenderer> ();

		source = this.GetComponent<AudioSource> ();

	}

	void Update ()
	{
		ranTear1 = Random.Range (0, 60);
		ranTear2 = Random.Range (0, 70);
		ranTear3 = Random.Range (0, 80);
		//Debug.Log ("random: " + ranTear1); 

		timeCounter += Time.deltaTime;

		shadowtear_y = shadowtear.transform.position.y;

		shadowtearloacal_y = shadowtear.transform.localPosition.y;
		//Debug.Log ("y: " +shadowtear.transform.position.y);
		//Debug.Log("shadowtear_y: " + shadowtear_y);

//		if (isTearTouchwithBall) 
//		{
//			shadowtear_y  = shadowtear_y  + 10.0f;
//		}
		Debug.Log( "distance: "+ shadowtearloacal_y +" - " +startShadowTear_localy);
// to judge if the person is filled wth empty
		if ( Mathf.Abs (shadowtearloacal_y - startShadowTear_localy) > lengthRole  && isTearHitBall)
		{
			// all colors reverse, prepare for another scene
			//Camera, role, room, terre, player cannot move now
			//sr_room.color = Color.black;
			Debug.Log("move to puzzle 3");
			if (t <= 2.0f)
			{
				t += 0.05f;
			}

			camera.backgroundColor = Color.Lerp(Color.white, Color.black, t);
			rb_ball.isKinematic = false;

			sr_flayraven.enabled = true;
			ani_flyraven.SetTrigger ("flyraven");
			step = 5.0f * Time.deltaTime;
			lflyraven.transform.position = Vector3.MoveTowards(lflyraven.transform.position, lmark1.transform.position, step);

			//source.PlayOneShot (au_8, 0.8f);


			//Destroy (shadowtear);
			sr_shadowtear.enabled = false;
			Destroy (c2);

			isRaven2cloneStart = true;

			sr_raven2.enabled = true;
			sr_raven2.color = Color.white;// may still change the color
			sr_room.color = Color.white;
			sr_ball.color = Color.black;
			// add an animation of raven fly away!
		}

//tears come!!
		if ((timeCounter - teardropBegin) >1.5f && isFirstTearDrop   && ranTear1 == 3 && !isTearTimeOver)  
		{						
			tear = Instantiate(Resources.Load("tree_tear")) as GameObject;
			tear.transform.position = new Vector3 (112.0f, -5.7f,0);
	
			Debug.Log ("tree is crying!");
		}

		if ((timeCounter - teardropBegin) >1.5f && isFirstTearDrop   && ranTear2 == 3 && !isTearTimeOver)
		{
			tear = Instantiate(Resources.Load("tree_tear")) as GameObject;
			tear.transform.position = new Vector3 (110.0f, -5.96f,0);
		}
		if ((timeCounter - teardropBegin) >1.5f && isFirstTearDrop   && ranTear3 == 3 && !isTearTimeOver)
		{
			tear = Instantiate(Resources.Load("tree_tear")) as GameObject;
			tear.transform.position = new Vector3 (114.0f, -5.2f,0);
		}

//Destroy the tears!
		//Debug.Log("tear_y: " + tear.transform.position.y);

//		if (tear.transform.position.y < 0.4f) 
//		{
//			Debug.Log ("too low...");
//			Destroy (tear);
//		}
//		if(isTearHitBall)
//		{
//			shadowtear_y  = shadowtear_y  + 10.0f;
//			shadowtear.transform.position = new Vector3 (shadowtear.transform.position.x, shadowtear_y, 0);
//		}
	
	}

	void treeGrow()
	{
		ani_treeGrow.SetTrigger ("treegrow");
		//initiate tears
		//tear = Instantiate(Resources.Load("tree_tear")) as GameObject;
		sp_tree.enabled = true;
		Debug.Log ("tree Grow");

		source.PlayOneShot (au_7, 0.8f);

	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.name == "Ball") 
		{
			sr_shadowtear.enabled = true;
			//isTearTouchwithBall = true;

			Debug.Log ("tearCollision");

			if(!isFirstTearDrop)
			{
				isFirstTearDrop = true;
				teardropBegin = timeCounter;
			    Debug.Log ("teardropBegin: " + teardropBegin);
			}
		}

	}

	void isTearTouchwithBall ()
	{
		isTearHitBall = true;
		Debug.Log ("hitted by tear " +shadowtear.transform.position.y);
		shadowtear_y  = shadowtear_y  + 0.003f;
        shadowtear.transform.position = new Vector3 (shadowtear.transform.position.x, shadowtear_y, 0);
	}
}
