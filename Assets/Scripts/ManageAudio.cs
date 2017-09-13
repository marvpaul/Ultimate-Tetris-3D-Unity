using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageAudio : MonoBehaviour {
	public AudioSource fullLine, cantMove; 

	public void playCantMove(){
		cantMove.Play (); 
	}

	public void PlayFullLine(){
		fullLine.Play (); 
	}
}
