using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClickExample : MonoBehaviour
{
	public Button yourButton;
	public Transform myModelPrefab;

	void Start()
	{
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		Debug.Log("You have clicked the button!");
		if (myModelPrefab != null)
		{
			//			Transform myModelTrf = GameObject.Instantiate(myModelPrefab) as Transform;
			//			myModelTrf.parent = mTrackableBehaviour.transform;
			//			myModelTrf.localPosition = new Vector3(0f, .5f, 0f);
			//			myModelTrf.localRotation = Quaternion.identity;
			myModelPrefab.localScale = new Vector3(0.5f, 0.5f, 0.5f);
			//			myModelTrf.gameObject.active = true;
		}
	}
}