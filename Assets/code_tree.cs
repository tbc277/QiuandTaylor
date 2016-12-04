using UnityEngine;
using System.Collections;

public class code_tree : MonoBehaviour {

	Animator ani_treeGrow;

	GameObject tear;

	GameObject shadowtear;
	SpriteRenderer sr_shadowtear;

	float shadowtear_y;

	//bool isTearTouchwithBall;

	float startShadowTear_y;
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

		startShadowTear_y = shadowtear.transform.position.y;
		//Debug.Log ("v3: "+ startV3ShadowTear);

		currentShadowTear_y = 10.0f; 
		lengthRole = 7.0f;// equals the length of the role;

		cam = GameObject.Find ("Main Camera");
		camera = cam.GetComponent<Camera>();

		ball = GameObject.Find ("Ball");
		rb_ball = ball.GetComponent<Rigidbody2D> ();

		room = GameObject.Find ("room");
		raven2 = GameObject.Find ("raven2");

		sr_raven2 = raven2.GetComponent<SpriteRenderer> ();
		sr_room = room.GetComponent<SpriteRenderer> ();
		sr_ball = ball.GetComponent<SpriteRenderer> ();

		isRaven2cloneStart = true;

		isFirstTearDrop = false;

		isCry = false;

		isTearTimeOver = false;

		isTearHitBall = false;

		t = 0f;

	}

	void Update ()
	{
		ranTear1 = Random.Range (0, 60);
		ranTear2 = Random.Range (0, 70);
		ranTear3 = Random.Range (0, 80);
		//Debug.Log ("random: " + ranTear1); 

		timeCounter += Time.deltaTime;

		shadowtear_y = shadowtear.transform.position.y;
		//Debug.Log ("y: " +shadowtear.transform.position.y);
		//Debug.Log("shadowtear_y: " + shadowtear_y);

//		if (isTearTouchwithBall) 
//		{
//			shadowtear_y  = shadowtear_y  + 10.0f;
//		}

// to judge if the person is filled wth empty
		if ( Mathf.Abs (shadowtear_y - startShadowTear_y) < lengthRole  && isTearHitBall)
		{
			// all colors reverse, prepare for another scene
			//Camera, role, room, terre, player cannot move now
			//sr_room.color = Color.black;
			Debug.Log("move to puzzle 3");
			if (t <= 1.0f)
			{
				t += 0.05f;
			}

			camera.backgroundColor = Color.Lerp(Color.white, Color.black, t);
			rb_ball.isKinematic = false;

			sr_raven2.enabled = true;
			sr_raven2.color = Color.white;// may still change the color
			sr_room.color = Color.white;
			sr_ball.color = Color.white;

			isRaven2cloneStart = true;
		}

//tears come!!
		if ((timeCounter - teardropBegin) >1.5f && isFirstTearDrop   && ranTear1 == 3 && !isTearTimeOver)  
		{						
			tear = Instantiate(Resources.Load("tree_tear")) as GameObject;
			tear.transform.position = new Vector3 (112.0f, -4.2f,0);
	
			Debug.Log ("tree is crying!");
		}

		if ((timeCounter - teardropBegin) >1.5f && isFirstTearDrop   && ranTear2 == 3 && !isTearTimeOver)
		{
			tear = Instantiate(Resources.Load("tree_tear")) as GameObject;
			tear.transform.position = new Vector3 (110.0f, -4.2f,0);
		}
		if ((timeCounter - teardropBegin) >1.5f && isFirstTearDrop   && ranTear3 == 3 && !isTearTimeOver)
		{
			tear = Instantiate(Resources.Load("tree_tear")) as GameObject;
			tear.transform.position = new Vector3 (114.0f, -4.2f,0);
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

		Debug.Log ("tree Grow");
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
