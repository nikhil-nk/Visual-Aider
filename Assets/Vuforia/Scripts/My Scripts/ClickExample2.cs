using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClickExample2 : MonoBehaviour
{
	float speed = 0.1f;
	private Vector3 newScale;
	private Vector3 oldScale;
	private Transform myModel;
	bool onClick = false;

	public void TaskOnClick(Transform myModelPrefab)
	{
		onClick = true;
		Debug.Log("You have clicked a button!");
		if (myModelPrefab != null)
		{
			myModel = myModelPrefab;
			newScale = new Vector3(2f, 2f, 2f);
			oldScale = myModelPrefab.localScale;
		}
	}

	void Update(){
		if (myModel != null && onClick != false) {
			myModel.localScale = Vector3.Lerp (newScale, oldScale, Time.deltaTime * speed);
			onClick = false;
		}
	}
}