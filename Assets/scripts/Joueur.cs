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
		velociteSaut = 5;
		vitesseMouvement = 3;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			rb.velocity = new Vector2(0, velociteSaut);
			print("espace");
		}

		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.Translate(Vector2.left * vitesseMouvement * Time.deltaTime);
			print("gauche");
		}

		if (Input.GetKey(KeyCode.RightArrow)) {
			transform.Translate(Vector2.right * vitesseMouvement * Time.deltaTime);
			print("droite");
		}
	}
}
