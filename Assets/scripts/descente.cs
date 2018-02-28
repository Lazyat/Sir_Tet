using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class descente : MonoBehaviour {

	private Rigidbody2D rb;
	public int vitesseDescente;	

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		vitesseDescente = 2;
	}
	
	// Update is called once per frame
	void Update () {
		rb.AddForce(new Vector2(0, -vitesseDescente)*10);
	}
}
