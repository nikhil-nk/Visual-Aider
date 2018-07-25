using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmoothTransition : MonoBehaviour {

	public Button yourButton;
	public Transform myModelPrefab;
	private int scaleFactor = 0;
	public int speed = 5;
	void Start()
	{
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void Update(){
		if (myModelPrefab != null && scaleFactor>0)
		{
			myModelPrefab.localScale = Vector3.Lerp(myModelPrefab.localScale, myModelPrefab.localScale * 2, Time.deltaTime*speed);
			scaleFactor--;	
		}
	}

	void TaskOnClick()
	{
		Debug.Log("You have clicked the button!");
		scaleFactor = 10;
//		if (myModelPrefab != null)
//		{
//			//			Transform myModelTrf = GameObject.Instantiate(myModelPrefab) as Transform;
//			//			myModelTrf.parent = mTrackableBehaviour.transform;
//			//			myModelTrf.localPosition = new Vector3(0f, .5f, 0f);
//			//			myModelTrf.localRotation = Quaternion.identity;
//			myModelPrefab.localScale = new Vector3(0.5f, 0.5f, 0.5f);
//			//			myModelTrf.gameObject.active = true;
//		}
	}
}
