using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

// This has been attached to TextRecognition Prefab and is for debug purposes
// This can be changed to add automatic word handling from a given database which will be done at some later time
public class WordDetection : MonoBehaviour, ITextRecoEventHandler {
	private TextRecoBehaviour mTextRecoBehaviour;

	// Use this for initialization
	void Start ()
	{
		// Get TextRecognition prefab GameObject
		mTextRecoBehaviour = GetComponent<TextRecoBehaviour>();
		if (mTextRecoBehaviour) {
			// registers a new TextReco event handler
			// These handlers are called after all trackables have been updated for this frame
			mTextRecoBehaviour.RegisterTextRecoEventHandler(this);
		}
	}

	public void OnInitialized(){
		// when TextRecognition Prefab is initialized
		Debug.Log("Initalized!");
	}

	// when a new word is detected
	public void OnWordDetected(WordResult wordResult)
	{
		// stores word from wordResult
		var word = wordResult.Word;
		// add the new word detected to debug log
		Debug.Log("Text: New word: " + wordResult.Word.StringValue);
	}

	// when a word is lost
	public void OnWordLost(Word word){
		// stores word String value in wordValue varibale
		var wordValue = word.Name;
		// add the new word detected to debug log
		Debug.Log("Text: Word Lost: " + wordValue);
	}
}