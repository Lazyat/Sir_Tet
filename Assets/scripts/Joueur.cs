using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur : MonoBehaviour {

	private Rigidbody2D rb;
	public int velociteSaut;
	public int vitesseMouvement;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		velociteSaut = 18;
		vitesseMouvement = 2;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Space)) {
			rb.AddForce(new Vector2(0, velociteSaut)*velociteSaut);
		}



		if (Input.GetKey(KeyCode.LeftArrow)) {
			//transform.Translate(Vector2.left * vitesseMouvement * Time.deltaTime);
			
			if(rb.velocity.x > -8) {
				rb.AddForce(new Vector2(-vitesseMouvement, 0)*10);
			}
		}

		if(Input.GetKeyUp(KeyCode.LeftArrow)) {
			rb.velocity = new Vector2(rb.velocity.x*0.25f, rb.velocity.y);
		}
		

		if (Input.GetKey(KeyCode.RightArrow)) {
			//transform.Translate(Vector2.right * vitesseMouvement * Time.deltaTime);
			
			if(rb.velocity.x < 8) {
				rb.AddForce(new Vector2(vitesseMouvement, 0)*10);
			}

		}
		if(Input.GetKeyUp(KeyCode.RightArrow)) {
			rb.velocity = new Vector2(rb.velocity.x*0.25f, rb.velocity.y);
		}
		print(rb.velocity);
	}

 	

}
