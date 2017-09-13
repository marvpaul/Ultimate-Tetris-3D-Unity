using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

/*
 * This class handles movement of the cube groups
 */
public class Movement : MonoBehaviour {
	public float timestep = 0.2F; 
	float time; 

	CubeArray cA; 

	//The actual group which can rotate and will move down
	public GameObject actualGroup; 


	void Start(){
		cA = gameObject.GetComponent<CubeArray> ();
	}

	public void startGame(){
		actualGroup = this.gameObject.GetComponent<GroupSpawner> ().spawnNext ();
	}
	//Move down in interval of timestep
	void Update () {
		time += Time.deltaTime; 
		if (time > timestep) {
			time = 0; 
			move (Vector3.down); 
		}
		checkForInput (); 
	}

	void checkForInput(){
		if (Input.GetKeyDown (KeyCode.R)) {
			actualGroup.GetComponent<Rotation>().rotateRight (false); 
		} else if (Input.GetKeyDown (KeyCode.L)) {
			actualGroup.GetComponent<Rotation>().rotateLeft (false); 
		}
		if (Input.GetKeyDown (KeyCode.A)) {
			move (Vector3.left);
		} else if (Input.GetKeyDown (KeyCode.D)) {
			move (Vector3.right);
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			timestep = 0.05F; 
		} else if (Input.GetKeyUp (KeyCode.S)) {
			gameObject.GetComponent<Highscore> ().setNewSpeed (); 
		}
		cA.updateArrayBool ();
	}

	//Move the current active group or spawn a new group
	void move(Vector3 pos){
		if (actualGroup != null) {
			actualGroup.transform.position += pos; 
			if (!cA.updateArrayBool ()) {
				actualGroup.transform.position -= pos; 
				gameObject.GetComponent<ManageAudio> ().playCantMove (); 
				if(pos == Vector3.down){
					spawnNew (); 
				}
			}
		}
	}

	//Handle spawning a new group and check if there is any intersection after spawning
	private void spawnNew(){
		actualGroup.GetComponent<Rotation> ().isActive = false; 
		actualGroup = gameObject.GetComponent<GroupSpawner> ().spawnNext ();
		actualGroup.GetComponent<Rotation> ().isActive = true;
		if (!cA.updateArrayBool ()) {
			GameObject.Find("Canvas").GetComponent<HighscoreManager>().showHighscores(gameObject.GetComponent<Highscore> ().points);
			Time.timeScale = 0F; 
		} else {
			cA.checkForFullLine ();
		} 
	}
}