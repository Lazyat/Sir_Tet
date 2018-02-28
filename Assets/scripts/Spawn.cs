using System.Collections;
using UnityEngine;
using System;

public class Spawn : MonoBehaviour{

	public GameObject go;
	public Vector3 spawnValues;
	public float spawnWait;
	public float startWait;
	
	void Start (){
		StartCoroutine(SpawnBlock());
	}

	IEnumerator SpawnBlock (){
		
		while (true){
			float aa = (float) Math.Ceiling(UnityEngine.Random.Range(-spawnValues.x, spawnValues.x));
			Vector3 spawnPosition = new Vector3 (aa, spawnValues.y, spawnValues.z);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate(go, spawnPosition, spawnRotation);
			yield return new WaitForSeconds(spawnWait);
		}
	}
}
