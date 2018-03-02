using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour {

	private bool isStarted = true;

	public void change(){
		isStarted = !isStarted;
	}
	
	// Update is called once per frame
	void Update () {
		while (isStarted) {
			this.transform.SetPositionAndRotation (new Vector3 (this.transform.position.x, this.transform.position.y + 1, this.transform.position.z), new Quaternion (0f, 0f, 0f, 0f));
			new WaitForSecondsRealtime (1f);
		}
	}
}
