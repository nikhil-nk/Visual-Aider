using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTransition : MonoBehaviour {

	int scalingFramesLeft = 0;
	int scaledown = 0;
	public int speed = 5;

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{

		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			scalingFramesLeft = 10;
		}else if(Input.GetKeyDown (KeyCode.DownArrow)) {
			scaledown = 10;
		}


		if (scalingFramesLeft > 0) {
			transform.localScale = Vector3.Lerp (transform.localScale, transform.localScale * 2, Time.deltaTime * speed);
			scalingFramesLeft--;
		}
		if(scaledown> 0 ){
			transform.localScale = Vector3.Lerp (transform.localScale, transform.localScale / 2, Time.deltaTime * speed);
			scaledown--;
		}



	}
}
