using UnityEngine;
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

	bool is35;

	SpriteRenderer sr_room;
	SpriteRenderer sr_raven2;

	public Color color1 = Color.black;
	public Color color2 = Color.white;
	public float duration = 3.0F;
	Camera camera;
	GameObject cam;
	float t;

	GameObject raven_3;

	GameObject ltree;
	GameObject ptree;

	SpriteRenderer sp_tree;

	bool isGenerateTree;
	bool isBiggerEnough;

	GameObject terre_1;
	SpriteRenderer sr_terre_1;
	GameObject terre_2;
	SpriteRenderer sr_terre_2;
	GameObject terre_3;
	SpriteRenderer sr_terre_3;
	GameObject o1;
	SpriteRenderer sr_o1;
	GameObject o2;
	SpriteRenderer sr_o2;
	GameObject o3;
	SpriteRenderer sr_o3;

	Animator ani_ball;

	GameObject ltearless1;
	GameObject ltearless2;
	SpriteRenderer sr_tearless1;
	SpriteRenderer sr_tearless2;

	Vector3 placeCry;

	GameObject lgrow_tear;
	SpriteRenderer sr_grow_tear;

	Animator ani_grow_tear;

	public AudioClip au_cry;

	private AudioSource source;

	void Start () {

		ani_raven2 = this.GetComponent<Animator> ();

		isBigger = false;

		ball = GameObject.Find ("Ball");
		rb_ball = ball.GetComponent<Rigidbody2D> ();

		girl = GameObject.Find ("girl");
		room = GameObject.Find ("room");

		sr_room = room.GetComponent<SpriteRenderer> ();
		sr_raven2 = this.GetComponent<SpriteRenderer> ();

		is35 = false;

		cam = GameObject.Find ("Main Camera");
		camera = cam.GetComponent<Camera>();

		sr_room.color = color2; // Color.black

		t = 0f;

		raven_3 = GameObject.Find ("raven3");

		ltree = GameObject.Find ("tree");
		isGenerateTree = false;

		isBiggerEnough = false;

		terre_1 = GameObject.Find ("terre_1");
		sr_terre_1 = terre_1.GetComponent<SpriteRenderer> ();
		terre_2 = GameObject.Find ("terre_2");
		sr_terre_2= terre_2.GetComponent<SpriteRenderer> ();
		terre_3 = GameObject.Find ("terre_2");
		sr_terre_3= terre_3.GetComponent<SpriteRenderer> ();

		o1 = GameObject.Find ("o1");
		sr_o1= o1.GetComponent<SpriteRenderer> ();
		o2 = GameObject.Find ("o2");
		sr_o2= o2.GetComponent<SpriteRenderer> ();
		o3 = GameObject.Find ("o3");
		sr_o3= o3.GetComponent<SpriteRenderer> ();

		sp_tree = ltree.GetComponent<SpriteRenderer> ();

		sp_tree.enabled = false;

		ani_ball = ball.GetComponent<Animator> ();

		ltearless1 = GameObject.Find ("tearless1");
		ltearless2 = GameObject.Find ("tearless2");

		sr_tearless1 = ltearless1.GetComponent<SpriteRenderer> ();
		sr_tearless2 = ltearless2.GetComponent<SpriteRenderer> ();

		placeCry = new Vector3 (112.6f, -10.5f,0);

		lgrow_tear = GameObject.Find ("grow_tear");

		sr_grow_tear = lgrow_tear.GetComponent<SpriteRenderer> ();
		sr_grow_tear.enabled = false;

		ani_grow_tear = lgrow_tear.GetComponent<Animator> ();

		source = this.GetComponent<AudioSource> ();
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

		if (isBiggerEnough  && !is35) 
		{
			currentTime = timeCounter;
			//Debug.Log ("reach the max point");

			Destroy (girl);
			//Destroy (room);
			sr_room.enabled = false;


			is35 = true;
		}

		if ((timeCounter - currentTime) > 1.0f && is35) 
		{
			
			ball.transform.position = Vector3.MoveTowards(ball.transform.position, placeCry,  5.0f * Time.deltaTime);
			ani_ball.SetTrigger ("tear");

			source.PlayOneShot (au_cry, 0.8f);

		}

		if ((timeCounter - currentTime) > 3.0f && is35)
		{
        //play cry animation
			sr_raven2.enabled = false;
		   //Destroy (gameObject);


		}

		if ((timeCounter - currentTime) > 5.0f && is35) 
		{
			sr_grow_tear.enabled = true;
			ani_grow_tear.SetTrigger ("grow");
		}


		if ((timeCounter - currentTime) > 7.0f && is35)
		{
		//room become white
			Debug.Log("greater than 7");
			sr_room.enabled = true;
			sr_room.color = new Color(0f, 0f, 0f, 255f);


			rb_ball.isKinematic = false;
			ball.transform.position = new Vector3 (113.0f, -12.0f, 0);

			sr_terre_1.enabled = false;
			//sr_terre_2.enabled = false;
			sr_terre_3.enabled = false;
			sr_o1.enabled = false;
			sr_o2.enabled = false;
			sr_o3.enabled = false;

			sr_terre_2.color = Color.white;
			sr_terre_2.enabled = true;

			sr_tearless1.enabled = false;
			sr_tearless2.enabled = false;


			if (t <= 1.0f)
			{
				t += 0.05f;
			}
		
			camera.backgroundColor = Color.Lerp(color1, color2, t);
			//camera.backgroundColor = color2;

			raven_3.SendMessage ("appear");



		}

		if ((timeCounter - currentTime) > 8.0f && is35)
		{
			if (!isGenerateTree) 
			{
//				ptree = Instantiate (Resources.Load ("tree")) as GameObject;
//				ptree.transform.position = new Vector3 (113.0f, -15.16f, 0);
				isGenerateTree = true;
			}

			ltree.SendMessage ("treeGrow");
			//Debug.Log ("tree grow");
		}

		if ((timeCounter - currentTime) > 11.0f && is35) 
		{
			Destroy (gameObject);
			//sr_raven2.enabled = false;
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

	void whenBiggerEnough()
	{
		isBiggerEnough = true;
	}


}
