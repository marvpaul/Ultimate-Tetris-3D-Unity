using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public GameObject startButton, window, windowPause, pauseBtn;

	// Use this for initialization
	void Awake () {
		Time.timeScale = 0; 
	}

	public void OnClickStart(){
		Time.timeScale = 1; 
		window.SetActive (false); 
		this.gameObject.GetComponent<Movement> ().startGame (); 
	}

	public void OnClickExit(){
		Application.Quit (); 
	}

	public void OnClickRestart(){
		windowPause.SetActive (false); 
		Application.LoadLevel (Application.loadedLevelName); 
	}

	public void OnClickPause(){
		pauseBtn.GetComponent<Button> ().interactable = false; 
		Time.timeScale = 0F;
		windowPause.SetActive (true); 
	}

	public void OnClickContinue(){
		pauseBtn.GetComponent<Button> ().interactable = true; 
		Time.timeScale = 1F;
		windowPause.SetActive (false); 
	}
}