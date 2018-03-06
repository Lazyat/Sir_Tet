using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonMort : MonoBehaviour {
	
	public AudioClip sonMort;
	private AudioSource source;
	private float volLowRange = .5f;
	private float volHighRange = 1.0f;

	// Use this for initialization
	void Start () {
		float vol = Random.Range (volLowRange, volHighRange);
        source.PlayOneShot(sonMort,vol);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
