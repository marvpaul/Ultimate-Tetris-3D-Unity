using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

/*
 * Manage loading the scores into the Highscore UI
 */
public class HighscoreManager : MonoBehaviour {
	
	public Text bestScore, actualScore; 
	public GameObject highscorePanel; 

	public void showHighscores(int actualScore){
		highscorePanel.SetActive (true); 
		this.actualScore.text = actualScore.ToString (); 
		loadBestScore (actualScore); 
	}

	public void loadBestScore(int actualScore){
		int lastBestHighscore = PlayerPrefs.GetInt ("Highscore"); 
		if (lastBestHighscore >= actualScore) {
			bestScore.text = lastBestHighscore.ToString (); 
		} else {
			PlayerPrefs.SetInt ("Highscore", actualScore); 
			bestScore.text = actualScore.ToString (); 
		} 
	}

	public void closeHighscorePanel(){
		highscorePanel.SetActive (false); 
		SceneManager.LoadScene (SceneManager.GetActiveScene().name); 
	}
}
