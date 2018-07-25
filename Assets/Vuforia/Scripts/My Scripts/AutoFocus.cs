using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

// It sets the camera focus to "FOCUS_MODE_TRIGGERAUTO"(Triggers a single autofocus operation each time the user touches the screen).
public class AutoFocus : MonoBehaviour
{
	// for initialization
	void Start ()
	{
		var vuforia = VuforiaARController.Instance;
		// registers a callback with the VuforiaBehaviour when the Vuforia process has started, which then will call OnVuforiaStarted() function
		vuforia.RegisterVuforiaStartedCallback (OnVuforiaStarted);
		// registers a callback with the VuforiaBehaviour when the Vuforia process pauses, which then will call OnPaused() function
		vuforia.RegisterOnPauseCallback (OnPaused);
	}

	// when Vuforia starts 
	private void OnVuforiaStarted ()
	{
		// set focus mode = "FOCUS_MODE_TRIGGERAUTO" when vuforia process starts
		bool focusModeSet = CameraDevice.Instance.SetFocusMode (
			                    CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO);
		// show message in debug log if focus mode = "FOCUS_MODE_TRIGGERAUTO" is not supported.
		if (!focusModeSet) {
			Debug.Log ("Failed to set focus mode (unsupported mode).");
		}
	}
		
	private void OnPaused (bool paused)
	{
		// when Vuforia resumes
		if (!paused) { 
			// Set again focus mode = "FOCUS_MODE_TRIGGERAUTO" when app is resumed
			CameraDevice.Instance.SetFocusMode (
				CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO);
		}
	}
}