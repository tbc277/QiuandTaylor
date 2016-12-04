using UnityEngine;
using System.Collections;

public class raven2clone : MonoBehaviour {
	
	GameObject ltree;

	code_tree lcode_tree_script;

	bool lisRaven2cloneStart;

	float step;
	float speed_raven;

	GameObject raven2destination;

	GameObject lball;

	GameObject lcloud1;
	float cloud1_x;

	GameObject lcloud2;
	float cloud2_x;

	GameObject lcloud3;
	float cloud3_x;

	float cloud1_x2;

	GameObject lpuzzleBpoint1;
	GameObject lpuzzleBpoint2;

	bool cloud1_loop1;
	bool cloud1_loop2;

	bool cloud2_loop1;
	bool cloud2_loop2;

	bool cloud3_loop1;
	bool cloud3_loop2;

	void Start () 
	{
		
		ltree = GameObject.Find ("tree");
		lcode_tree_script = ltree.GetComponent<code_tree> ();

		speed_raven = 0.5f;

		raven2destination = GameObject.Find ("raven2destination");

		lball = GameObject.Find ("Ball");

		lcloud1 = GameObject.Find ("cloud1");
		cloud1_x = lcloud1.transform.position.x;

		lcloud2 = GameObject.Find ("cloud2");
		cloud2_x = lcloud2.transform.position.x;

		lcloud3 = GameObject.Find ("cloud3");
		cloud3_x = lcloud3.transform.position.x;

		//Debug.Log ("cloud1_y :" + cloud1_y);

		lpuzzleBpoint1 = GameObject.Find ("puzzleBpoint1");
		lpuzzleBpoint2 = GameObject.Find ("puzzleBpoint2");
		cloud1_loop1 = true;
		cloud1_loop2 = false;
		cloud2_loop1 = true;
		cloud2_loop2 = false;
		cloud3_loop1 = true;
		cloud3_loop2 = false;
	}
	

	void Update ()
	{
		
		lisRaven2cloneStart = lcode_tree_script.isRaven2cloneStart;
		Debug.Log(lisRaven2cloneStart);

		step = speed_raven * Time.deltaTime;

		cloud1_x2 = lcloud1.transform.position.x;

//raven 2 clone fly to the point
		if (lisRaven2cloneStart)
		{

			this.transform.position = Vector3.MoveTowards(this.transform.position, raven2destination.transform.position, step);
			speed_raven = speed_raven + 0.05f;

			//if the player get that point， use kevin's coding: when reaching this area, three clouds begin to move throu the player
			if (Mathf.Abs(lball.transform.position.x - this.transform.position.x) < 100.0f)
			{

				//Debug.Log ("ball.x:" + lball.transform.position.x +" raven2clone.x: " + this.transform.position.x );
				//Debug.Log("in point 1 and point 2");
				//Debug.Log ("p1 x: " + lpuzzleBpoint1.transform.position.x + "p2 x: " + lpuzzleBpoint2.transform.position.x);
				if ( Input.GetKey (KeyCode.RightArrow) ) 
				{
//cloud1
					if (!cloud1_loop2 || cloud1_loop1) 
					{
						if (lcloud1.transform.position.x <= lpuzzleBpoint1.transform.position.x || lcloud1.transform.position.x <= lpuzzleBpoint2.transform.position.x) 
						{
							//Debug.Log ("1");
							cloud1_x = cloud1_x + 0.05f;
							//lcloud1.transform.position.y = cloud1_y; 
							lcloud1.transform.position = new Vector3 (cloud1_x, lcloud1.transform.position.y, 0);  // move to the right

//							if ( Input.GetKey (KeyCode.LeftArrow) )
//							{
//								cloud1_x2 = cloud1_x2 - 0.05f;
//								lcloud1.transform.position = new Vector3 (cloud1_x2, lcloud1.transform.position.y, 0);  
//								Debug.Log ("cloud1_x2: " +cloud1_x2);
//							}

							if (lcloud1.transform.position.x >= lpuzzleBpoint2.transform.position.x) 
							{
								Debug.Log ("1-2");
//							cloud1_x = cloud1_x - 0.05f;
//							lcloud1.transform.position = new Vector3 (cloud1_x, lcloud1.transform.position.y, 0); 
								cloud1_loop2 = true;
								cloud1_loop1 = false;
							}
						} 
					}

					if (cloud1_loop2 || !cloud1_loop1) 
					{
						if (lcloud1.transform.position.x >= lpuzzleBpoint2.transform.position.x || lcloud1.transform.position.x > lpuzzleBpoint1.transform.position.x) 
						{
							//Debug.Log ("2");
							cloud1_x = cloud1_x - 0.05f;
							lcloud1.transform.position = new Vector3 (cloud1_x, lcloud1.transform.position.y, 0); 


//							if ( Input.GetKey (KeyCode.LeftArrow) )
//							{
//								cloud1_x2 = cloud1_x2 + 0.05f;
//								lcloud1.transform.position = new Vector3 (cloud1_x2, lcloud1.transform.position.y, 0);  
//								Debug.Log ("cloud1_x2: " +cloud1_x2);
//							}

							if (lcloud1.transform.position.x <= lpuzzleBpoint1.transform.position.x) {
								Debug.Log ("2-2");
//							cloud1_x = cloud1_x + 0.05f;		
//							lcloud1.transform.position = new Vector3 (cloud1_x, lcloud1.transform.position.y, 0);  // move to the right
								cloud1_loop2 = false;
								cloud1_loop1 = true;
							}
						}
					}
//cloud2
					if (!cloud2_loop2 || cloud2_loop1) 
					{
						if (lcloud2.transform.position.x <= lpuzzleBpoint1.transform.position.x || lcloud2.transform.position.x <= lpuzzleBpoint2.transform.position.x) 
						{
							Debug.Log ("1");
							cloud2_x = cloud2_x + 0.05f;
							//lcloud1.transform.position.y = cloud1_y; 
							lcloud2.transform.position = new Vector3 (cloud2_x, lcloud2.transform.position.y, 0);  // move to the right

							if (lcloud2.transform.position.x >= lpuzzleBpoint2.transform.position.x) {
								Debug.Log ("1-2");
								//							cloud1_x = cloud1_x - 0.05f;
								//							lcloud1.transform.position = new Vector3 (cloud1_x, lcloud1.transform.position.y, 0); 
								cloud2_loop2 = true;
								cloud2_loop1 = false;
							}
						} 
					}

					if (cloud2_loop2 || !cloud2_loop1) 
					{
						if (lcloud2.transform.position.x >= lpuzzleBpoint2.transform.position.x || lcloud2.transform.position.x > lpuzzleBpoint1.transform.position.x) {
							//Debug.Log ("2");
							cloud2_x = cloud2_x - 0.05f;
							lcloud2.transform.position = new Vector3 (cloud2_x, lcloud2.transform.position.y, 0); 

							if (lcloud2.transform.position.x <= lpuzzleBpoint1.transform.position.x) {
								Debug.Log ("2-2");
								//							cloud1_x = cloud1_x + 0.05f;		
								//							lcloud1.transform.position = new Vector3 (cloud1_x, lcloud1.transform.position.y, 0);  // move to the right
								cloud2_loop2 = false;
								cloud2_loop1 = true;
							}
						}


					}

//cloud3	
					if (!cloud3_loop2 || cloud3_loop1) 
					{
						if (lcloud3.transform.position.x <= lpuzzleBpoint1.transform.position.x || lcloud3.transform.position.x <= lpuzzleBpoint2.transform.position.x) {
							//Debug.Log ("1");
							cloud3_x = cloud3_x + 0.05f;
							//lcloud1.transform.position.y = cloud1_y; 
							lcloud3.transform.position = new Vector3 (cloud3_x, lcloud3.transform.position.y, 0);  // move to the right

							if (lcloud3.transform.position.x >= lpuzzleBpoint2.transform.position.x) {
								//Debug.Log ("1-2");
								//							cloud1_x = cloud1_x - 0.05f;
								//							lcloud1.transform.position = new Vector3 (cloud1_x, lcloud1.transform.position.y, 0); 
								cloud3_loop2 = true;
								cloud3_loop1 = false;
							}
						} 
					}

					if (cloud3_loop2 || !cloud3_loop1) 
					{
						if (lcloud3.transform.position.x >= lpuzzleBpoint2.transform.position.x || lcloud3.transform.position.x > lpuzzleBpoint1.transform.position.x) {
							//Debug.Log ("2");
							cloud3_x = cloud3_x - 0.05f;
							lcloud3.transform.position = new Vector3 (cloud3_x, lcloud3.transform.position.y, 0); 

							if (lcloud3.transform.position.x <= lpuzzleBpoint1.transform.position.x) {
								Debug.Log ("2-2");
								//							cloud1_x = cloud1_x + 0.05f;		
								//							lcloud1.transform.position = new Vector3 (cloud1_x, lcloud1.transform.position.y, 0);  // move to the right
								cloud3_loop2 = false;
								cloud3_loop1 = true;
							}
						}


					}

			

				}

////  towards right
//				if ( Input.GetKey (KeyCode.LeftArrow) ) {
//					//cloud1
//					if (!cloud1_loop2 || cloud1_loop1) {
//						if (lcloud1.transform.position.x <= lpuzzleBpoint1.transform.position.x || lcloud1.transform.position.x <= lpuzzleBpoint2.transform.position.x) {
//
//							cloud1_x = cloud1_x + 0.05f;
//
//							lcloud1.transform.position = new Vector3 (cloud1_x, lcloud1.transform.position.y, 0);  // move to the right
//
//							if (lcloud1.transform.position.x >= lpuzzleBpoint2.transform.position.x) {
//	
//
//								cloud1_loop2 = true;
//								cloud1_loop1 = false;
//							}
//						} 
//					}
//
//					if (cloud1_loop2 || !cloud1_loop1) {
//						if (lcloud1.transform.position.x >= lpuzzleBpoint2.transform.position.x || lcloud1.transform.position.x > lpuzzleBpoint1.transform.position.x) {
//							Debug.Log ("2");
//							cloud1_x = cloud1_x - 0.05f;
//							lcloud1.transform.position = new Vector3 (cloud1_x, lcloud1.transform.position.y, 0); 
//
//							if (lcloud1.transform.position.x <= lpuzzleBpoint1.transform.position.x) {
//								Debug.Log ("2-2");
//								//							cloud1_x = cloud1_x + 0.05f;		
//								//							lcloud1.transform.position = new Vector3 (cloud1_x, lcloud1.transform.position.y, 0);  // move to the right
//								cloud1_loop2 = false;
//								cloud1_loop1 = true;
//							}
//						}
//					}
//					//cloud2
//					if (!cloud2_loop2 || cloud2_loop1) {
//						if (lcloud2.transform.position.x <= lpuzzleBpoint1.transform.position.x || lcloud2.transform.position.x <= lpuzzleBpoint2.transform.position.x) {
//							Debug.Log ("1");
//							cloud2_x = cloud2_x + 0.05f;
//							//lcloud1.transform.position.y = cloud1_y; 
//							lcloud2.transform.position = new Vector3 (cloud2_x, lcloud2.transform.position.y, 0);  // move to the right
//
//							if (lcloud2.transform.position.x >= lpuzzleBpoint2.transform.position.x) {
//								Debug.Log ("1-2");
//								//							cloud1_x = cloud1_x - 0.05f;
//								//							lcloud1.transform.position = new Vector3 (cloud1_x, lcloud1.transform.position.y, 0); 
//								cloud2_loop2 = true;
//								cloud2_loop1 = false;
//							}
//						} 
//					}
//
//					if (cloud2_loop2 || !cloud2_loop1) {
//						if (lcloud2.transform.position.x >= lpuzzleBpoint2.transform.position.x || lcloud2.transform.position.x > lpuzzleBpoint1.transform.position.x) {
//							//Debug.Log ("2");
//							cloud2_x = cloud2_x - 0.05f;
//							lcloud2.transform.position = new Vector3 (cloud2_x, lcloud2.transform.position.y, 0); 
//
//							if (lcloud2.transform.position.x <= lpuzzleBpoint1.transform.position.x) {
//								Debug.Log ("2-2");
//								//							cloud1_x = cloud1_x + 0.05f;		
//								//							lcloud1.transform.position = new Vector3 (cloud1_x, lcloud1.transform.position.y, 0);  // move to the right
//								cloud2_loop2 = false;
//								cloud2_loop1 = true;
//							}
//						}
//
//
//					}
//
//					//cloud3	
//					if (!cloud3_loop2 || cloud3_loop1) {
//						if (lcloud3.transform.position.x <= lpuzzleBpoint1.transform.position.x || lcloud3.transform.position.x <= lpuzzleBpoint2.transform.position.x) {
//							//Debug.Log ("1");
//							cloud3_x = cloud3_x + 0.05f;
//							//lcloud1.transform.position.y = cloud1_y; 
//							lcloud3.transform.position = new Vector3 (cloud3_x, lcloud3.transform.position.y, 0);  // move to the right
//
//							if (lcloud3.transform.position.x >= lpuzzleBpoint2.transform.position.x) {
//								//Debug.Log ("1-2");
//								//							cloud1_x = cloud1_x - 0.05f;
//								//							lcloud1.transform.position = new Vector3 (cloud1_x, lcloud1.transform.position.y, 0); 
//								cloud3_loop2 = true;
//								cloud3_loop1 = false;
//							}
//						} 
//					}
//
//					if (cloud3_loop2 || !cloud3_loop1) {
//						if (lcloud3.transform.position.x >= lpuzzleBpoint2.transform.position.x || lcloud3.transform.position.x > lpuzzleBpoint1.transform.position.x) {
//							//Debug.Log ("2");
//							cloud3_x = cloud3_x - 0.05f;
//							lcloud3.transform.position = new Vector3 (cloud3_x, lcloud3.transform.position.y, 0); 
//
//							if (lcloud3.transform.position.x <= lpuzzleBpoint1.transform.position.x) {
//								Debug.Log ("2-2");
//								//							cloud1_x = cloud1_x + 0.05f;		
//								//							lcloud1.transform.position = new Vector3 (cloud1_x, lcloud1.transform.position.y, 0);  // move to the right
//								cloud3_loop2 = false;
//								cloud3_loop1 = true;
//							}
//						}
//
//
//					}
//
//
//
//				}


		}



	}
}
}
