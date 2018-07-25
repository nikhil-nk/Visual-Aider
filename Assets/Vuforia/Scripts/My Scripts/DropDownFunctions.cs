using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This has been attached to "ChangeSize" dropDown
public class DropDownFunctions : MonoBehaviour
{

	Dropdown m_Dropdown;
	// prefab on which we want to perform action with help of the dropdown
	public Transform myPrefabModel;
	// scale to which prefab which will be changed finally
	private Vector3 newScale;
	// speed at which size will be changed
	public float speed = 3f;
	// if it is greater than 0, then only resizing will take place(for frame control for smooth change in size)
	private int scaleDown = 0;

	// for initializtion
	void Start ()
	{
		//Fetch the Dropdown GameObject
		m_Dropdown = GetComponent<Dropdown> ();
		//Add listener for when the value of the Dropdown changes, to take action
		m_Dropdown.onValueChanged.AddListener (delegate {
			DropdownValueChanged (m_Dropdown);
		});

		//Initialize the size of prefab to the corresponding size for first value of the Dropdown
		if (myPrefabModel != null && m_Dropdown.value == 0) {
			myPrefabModel.localScale = new Vector3 (.5f, .5f, .5f);
		}
	}

	// Update is called once per frame
	void Update ()
	{
		// if a prefab has been selected and scaleDown value is greater than 0, then size will be changed
		// it will also decrease the value of scaleDown each time frame updates.
		// scaleDown has been used so that size change does not happen in one frame (if it does, then size change will not be smooth)
		// Lerp has been used so that size change happens with a fixed speed (it also has been applied for smooth change of size)
		if (myPrefabModel != null && scaleDown > 0) {
			myPrefabModel.localScale = Vector3.Lerp (myPrefabModel.localScale, newScale, Time.deltaTime * speed);
			scaleDown--;
		}
	}

	// when DropDown value is changed
	void DropdownValueChanged (Dropdown change)
	{
		// set the newScale value to required sizes according to different options
		if (change.value == 0) {
			newScale = new Vector3 (.5f, .5f, .5f);
		} else if (change.value == 1) {
			newScale = new Vector3 (1f, 1f, 1f);
		} else if (change.value == 2) {
			newScale = new Vector3 (2f, 2f, 2f);
		}  
		// set the scaleDown variable to 10
		scaleDown = 10;
	}
}