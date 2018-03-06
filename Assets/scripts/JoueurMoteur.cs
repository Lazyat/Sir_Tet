using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JoueurMoteur : MonoBehaviour {

private Vector2 velocity;
private Rigidbody2D rb;
public float maxSpeed , maxSpeedJump, radiusCircle;
public GameObject SolCheck, TopCheck;
public LayerMask layer;
public AudioClip jumpSound;
private AudioSource source;
private float volLowRange = .5f;
private float volHighRange = 1.0f;
public GameObject sonMort;

void Awake () {
    source = GetComponent<AudioSource>();
}

void Start () {
	velocity = Vector2.zero;
	rb = GetComponent<Rigidbody2D>();
}

void FixedUpdate () {
	PerformAction();
}

private void PerformAction(){
	bool auSol = Physics2D.OverlapCircle(SolCheck.transform.position, radiusCircle, layer );
	bool auPlafond = Physics2D.OverlapCircle(TopCheck.transform.position, radiusCircle, layer );

	if (auSol && Input.GetKeyDown(KeyCode.UpArrow)){
		rb.AddForce(new Vector2(0, maxSpeedJump), ForceMode2D.Impulse);
		float vol = Random.Range (volLowRange, volHighRange);
        source.PlayOneShot(jumpSound,vol);
	}
	if (Input.GetKey(KeyCode.LeftArrow)) {
			//transform.Translate(Vector2.left * vitesseMouvement * Time.deltaTime);
			
		if(rb.velocity.x > -8) {
			rb.AddForce(new Vector2(-maxSpeed, 0)*10);
			GetComponent<SpriteRenderer>().flipX = true;
		}
	}

	if(Input.GetKeyUp(KeyCode.LeftArrow)) {
		rb.velocity = new Vector2(rb.velocity.x*0.25f, rb.velocity.y);
	}
		

	if (Input.GetKey(KeyCode.RightArrow)) {
			//transform.Translate(Vector2.right * vitesseMouvement * Time.deltaTime);
			
		if(rb.velocity.x < 8) {
			rb.AddForce(new Vector2(maxSpeed, 0)*10);
			GetComponent<SpriteRenderer>().flipX = false;
		}

	}
	if(Input.GetKeyUp(KeyCode.RightArrow)) {
		rb.velocity = new Vector2(rb.velocity.x*0.25f, rb.velocity.y);
		
	}


	if ((auSol) && (auPlafond)){
		GameObject mort = Instantiate(sonMort, new Vector2(0,0), Quaternion.identity);
		Destroy(this.gameObject);
		SceneManager.LoadScene("death");
	} 
	
	
}
	private void OnDrawGizmos(){
		Gizmos.DrawSphere(SolCheck.transform.position, radiusCircle);
		Gizmos.DrawSphere(TopCheck.transform.position, radiusCircle);
	}

}


