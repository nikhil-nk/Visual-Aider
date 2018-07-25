using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This has been attached to "Exit" Button in Start Scene
public class ExitApplication : MonoBehaviour
{
	Button btn;
	// 
	private bool quit = false;

	// for initializtion
	void Start ()
	{
		// Fetch the Button GameObject
		btn = GetComponent<Button> ();
		// Add listener to take action(Call TaskOnClick() function) when button is pressed.
		btn.onClick.AddListener (TaskOnClick);
	}

	// Update is called once per frame
	void Update ()
	{
		// when quit is true quit application
		if (quit == true) {
			Application.Quit ();	
		}
	}

	// when button is pressed
	void TaskOnClick ()
	{
		Debug.Log ("Quit button pressed! Quitting App");
		// changes quit value to true
		quit = true;
	}
}