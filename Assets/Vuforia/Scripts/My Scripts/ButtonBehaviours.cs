using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// This is attached with a button OnClick(It will be called when a button is clicked)
// This script has been attached to "Start Camera" Button in Start scene and "Back" button in textReco scene
public class ButtonBehaviours : MonoBehaviour
{
	Button btn;
	// for storing scene name
	public string sceneName;

	// for initialization
	void Start ()
	{
		// Fetch the Button GameObject
		btn = GetComponent<Button> ();
		// Add listener to take action(Call TaskOnClick() function) when button is pressed.
		btn.onClick.AddListener (TaskOnClick);
	}

	// when button is pressed
	void TaskOnClick ()
	{
		Debug.Log ("scene will be changed to " + sceneName);
		// Load Scene specified by string sceneName
		SceneManager.LoadScene (sceneName);
	}
}