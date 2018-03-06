using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptControlleur : MonoBehaviour {

	public GameObject block;
	public GameObject cameraJeu;
	public float timerLongeur;
	public float timer;
	public bool jeu;

	public Sprite[] couleurs;
	
	private int longeurSol;
	private int longeurMur;
	private int[] compteurBlock;
	private int min;
	public int niveau;
	private GameObject[] murs;
	private int blockTotal;
	private GameObject score;
	void Start() {
		niveau = 0;
		jeu = true;
		score = GameObject.Find("score");
		score.GetComponent<Text>().text = "0";

		timerLongeur = 1f;
		timer = timerLongeur;

		longeurSol = 10;
		longeurMur = 30;

		compteurBlock = new int[longeurSol - 2];

		creerSol (longeurSol);
		murs = creerMurs (longeurMur, longeurSol);
	}

	void Update () {
	score.GetComponent<Text>().text = blockTotal.ToString();
		//arreter les timer
		if (Input.GetKeyDown (KeyCode.Escape)) {
			jeu = !jeu;
		}

		if (jeu) {
			timer -= Time.deltaTime;
			if (timer <= 0f) {
				creerBlockDangereux ();
				timer = timerLongeur - Mathf.Log((niveau * 0.1f) + 0.5f, 2);
			}
		}
			
		//bouger la camera par rapport au minimum
		cameraJeu.transform.position = new Vector3 (0, 0 + min, -10);
	}

	//creer le sol
	void creerSol(int longeur) {
		for (int x = 0; x < longeur; x++) {
			GameObject blockSol = Instantiate(block, new Vector2(x-(longeur/2), -4), Quaternion.identity);
			blockSol.GetComponent<SpriteRenderer>().sprite = couleurs[0];			
			print ("Sol:cree Block " + (x-(longeur/2)) + ";-4");
		}
	}

	//creer les murs
	GameObject[] creerMurs(int longeur, int longeurSol) {
		GameObject[] murs = new GameObject[longeur * 2];

		for (int x = 0; x < 2; x++) {
			for (int y = 0; y < longeur; y++) {
				murs[(x*longeur)+y] = Instantiate(block, new Vector2((x-(longeurSol/2))+(x*(longeurSol-2)), y-3), Quaternion.identity);
				print ("Mur:cree Block " + x + ";" + y);
			}
		}
		
		foreach (GameObject blockMur in murs) {
			blockMur.GetComponent<SpriteRenderer>().sprite = couleurs[0];	
		}

		return murs;
	}

	//creer block dangereux
	void creerBlockDangereux() {
		int positionChoisie = -1;

		//trouver le minimum
		min = compteurBlock[0];
		for (int pos = 0; pos < compteurBlock.Length; pos++) {
			if (compteurBlock [pos] < min) {
				min = compteurBlock [pos];
			}
		}

		//trouver toutes les positions minimum
		int[] positionsDisponibles = new int[compteurBlock.Length];
		for (int pos = 0; pos < compteurBlock.Length; pos++) {
			if (compteurBlock [pos] == min) {
				positionsDisponibles [pos] = 1;
			} else {
				positionsDisponibles [pos] = 0;
			}
		}
			
		//choisir parmi les positions disponibles
		for(int pos = 0; pos < compteurBlock.Length; pos++) {
			do {
				int rand = Random.Range (0, compteurBlock.Length);
				if (positionsDisponibles[rand] == 1) {
					positionChoisie = rand;
				} else {
					//si gauche mur et droite meme taille
					if (rand - 1 == -1
						&& compteurBlock[rand] == compteurBlock[rand + 1]) {

						positionChoisie = rand;
					}

					//si droite mur et gauche meme taille
					if (rand + 1 == compteurBlock.Length
						&& compteurBlock[rand] == compteurBlock[rand - 1]) {

						positionChoisie = rand;
					}

					//si droite et gauche meme taille
					if (rand - 1 != -1
						&& rand + 1 != compteurBlock.Length
						&& compteurBlock[rand] == compteurBlock[rand + 1]
						&& compteurBlock[rand] == compteurBlock[rand - 1]) {

						positionChoisie = rand;
					}
						
				}
			} while (positionChoisie == -1);
		}

		//creer le block dangereux
		GameObject blockDanger = Instantiate(block, new Vector2(positionChoisie - longeurSol/2 + 1, 5 + min), Quaternion.identity);
		blockDanger.GetComponent<Rigidbody2D> ().isKinematic = false;
		
		//couleur random
		int randCouleur = Random.Range (1, 8);
		blockDanger.GetComponent<SpriteRenderer>().sprite = couleurs[randCouleur];

		//augmenter le nombre de la position choisie
		compteurBlock [positionChoisie]++;

		//calculer le nombre total de bloc dangereux puis augmenter le niveau
		blockTotal = 0;
		foreach(int block in compteurBlock) {
			blockTotal+=block;
		}
		niveau = blockTotal/10;

		//debug
		string str = "compteurBlock: ";
		for (int i = 0; i < compteurBlock.Length; i++) {
			str += compteurBlock[i] + ",";
		}
		print (str);
	}
}
