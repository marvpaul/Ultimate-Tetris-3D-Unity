using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	
	public float timestep = 0.2F; 
	float time; 

	//The actual group which can rotate and will move down
	public GameObject actualGroup; 
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime; 
		if (time > timestep) {
			time = 0; 
			moveDown (); 
		}
	}

	void moveDown(){
		
		this.gameObject.GetComponent<CubeArray> ().removeTemp (actualGroup.GetComponent<Rotation> ().blocks); 

		actualGroup.transform.position += Vector3.down;  
		Transform[] blocks = actualGroup.GetComponent<Rotation> ().blocks;

		if (!this.gameObject.GetComponent<CubeArray> ().isValidTurn (blocks)) {
			actualGroup.transform.position += Vector3.up; 
			actualGroup.GetComponent<Rotation> ().isActive = false; 
			actualGroup = this.gameObject.GetComponent<SpawnNew> ().spawnNext ();
			this.gameObject.GetComponent<CubeArray> ().updateArray (); 
		}
		this.gameObject.GetComponent<CubeArray> ().updateArray (); 
		actualGroup.GetComponent<Rotation> ().isActive = true; 

	}
}
