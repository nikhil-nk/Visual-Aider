using UnityEngine;
using Vuforia;
using System.Collections;

// This has been attached to each word prefab(Trackable) and myModelPrefab is its corresponding 3D model
public class MyPrefabInstantiator : MonoBehaviour, ITrackableEventHandler
{
	private TrackableBehaviour mTrackableBehaviour;
	public Transform myModelPrefab;

	// Use this for initialization
	void Start ()
	{
		// Get Trackable prefab GameObject
		mTrackableBehaviour = GetComponent<TrackableBehaviour> ();
		if (mTrackableBehaviour) {
			// registers a new Tracker event handler at the Tracker
			// These handlers are called as soon as ALL Trackables have been updated in this frame
			mTrackableBehaviour.RegisterTrackableEventHandler (this);
		}
	}

	// Update is called once per frame
	void Update ()
	{
	}

	// When trackable state is changed (i.e. prefab is detected or lost)
	public void OnTrackableStateChanged (
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{ 
		// Calls OnTrackingFound() whenever trackable status change to detected or tracked or extende_tracked
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
		    newStatus == TrackableBehaviour.Status.TRACKED ||
		    newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) {
			OnTrackingFound ();
		}
	}

	// when prefab is detected
	private void OnTrackingFound ()
	{
		if (myModelPrefab != null) {
			// instantiate myModelPrefab GameObject
			Transform myModelTrf = GameObject.Instantiate (myModelPrefab) as Transform;
			// set mTrackableBehavior(Trackable Prefab) as parent of myModelPrefab
			myModelTrf.parent = mTrackableBehaviour.transform;
			// set myModelPrefab position relative to trackable prefab
			myModelTrf.localPosition = new Vector3 (0f, .5f, 0f);
			// set rotation axis
			myModelTrf.localRotation = Quaternion.identity;
			// set size of myModelPrefab
			myModelTrf.localScale = new Vector3 (10f, 10f, 10f);
			// sets the local state of GameObject
			myModelTrf.gameObject.active = true;
		}
	}
}