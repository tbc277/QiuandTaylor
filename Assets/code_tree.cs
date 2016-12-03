using UnityEngine;
using System.Collections;

public class code_tree : MonoBehaviour {

	Animator ani_treeGrow;

	GameObject tear;

	GameObject shadowtear;
	SpriteRenderer sr_shadowtear;

	float shadowtear_y;

	bool isTearTouchwithBall;

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

	void Start () 
	{
		
		tear = Instantiate(Resources.Load("tree_tear")) as GameObject;
		tear.transform.position = new Vector3 (110.0f, -2.5f,0);

		//Rigidbody2D rg_tear = gameObject.AddComponent<Rigidbody2D>(  ) as Rigidbody2D;	

		tear = Instantiate(Resources.Load("tree_tear")) as GameObject;
		tear.transform.position = new Vector3 (112.0f, -2.5f,0);
//		tear = Instantiate(Resources.Load("tree_tear")) as GameObject;
		ani_treeGrow = GetComponent<Animator> ();
		//Debug.Log (ani_treeGrow);

		shadowtear = GameObject.Find ("shadow_tear");
		sr_shadowtear = shadowtear.GetComponent<SpriteRenderer> ();
		sr_shadowtear.enabled = false;


		isTearTouchwithBall = false;

		startShadowTear_y = shadowtear.transform.position.y;
		//Debug.Log ("v3: "+ startV3ShadowTear);

		currentShadowTear_y = 10.0f; // equals the length of the role;

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
	}

	void Update ()
	{
		shadowtear_y = shadowtear.transform.position.y;
		//Debug.Log ("y: " +shadowtear.transform.position.y);

		if (isTearTouchwithBall) 
		{
			shadowtear_y  = shadowtear_y  + 10.0f;
		}

// to judge if the person is filled wth empty
		if ( Mathf.Abs (currentShadowTear_y - startShadowTear_y) < 1.0f)
		{
			// all colors reverse, prepare for another scene
			//Camera, role, room, terre, player cannot move now
			//sr_room.color = Color.black;

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
	}

	void treeGrow()
	{
		ani_treeGrow.SetTrigger ("treegrow");
		//initiate tears

		tear = Instantiate(Resources.Load("tree_tear")) as GameObject;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.name == "Ball") 
		{
			sr_shadowtear.enabled = true;

			isTearTouchwithBall = true;

		}

	}
}
