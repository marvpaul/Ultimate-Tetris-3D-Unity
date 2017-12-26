using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class CubeArray : MonoBehaviour {
	Highscore hScore; 
	bool[,] isCube; 
	// Use this for initialization
	void Start () {
		hScore = gameObject.GetComponent<Highscore> (); 
		isCube = new bool[10,17];
		updateArrayBool (); 
	}

	//Update the cube array and return false if there is any intersection between two cubes
	public bool updateArrayBool(){
		isCube = new bool[10, 17]; 
		bool withoutIntersection = true; 
		foreach (GameObject cube in GameObject.FindGameObjectsWithTag("Cube")) {
			int x = (int)cube.transform.position.x; 
			int y = (int)cube.transform.position.y;
			if (x >= 0 && x < isCube.GetLength (0) && y >= 0 && y < isCube.GetLength (1)) {
				bool cubeSetted = isCube [x, y]; 
				if (cubeSetted) {
					//Position in array is always setted
					withoutIntersection = false;
				} else {
					isCube [(int)cube.transform.position.x, (int)cube.transform.position.y] = true;
				}
			} else {
				//Position is out of range 
				withoutIntersection = false; 
			}
		}
		return withoutIntersection; 
	}


	public void checkForFullLine(){

		//Check if there is any full line 
		List<int> isFullLine = new List<int> (); 
		for (int i = 0; i < isCube.GetLength (1); i++) {
			bool isFull = true; 
			for (int j = 0; j < isCube.GetLength (0); j++) {
				if (!isCube [j, i])
					isFull = false; 	
			} 
			if (isFull)
				isFullLine.Add (i); 
		}

		hScore.addPointsForLines (isFullLine.Count); 

		//For each full line
		for(int i = 0; i < isFullLine.Count; i++){
			//Delete all cubes in a row
			foreach (GameObject cube in GameObject.FindGameObjectsWithTag("Cube")) {
				int y = (int)cube.transform.position.y;
				if(isFullLine[i] == y){
					//Heres goes a incredible cool explosion effect!!!
					Destroy (cube); 
				}
			}
			//Set down all cubes above the deleted row
			foreach (GameObject cube in GameObject.FindGameObjectsWithTag("Cube")) {
				int y = (int)cube.transform.position.y;
				if(isFullLine[i] < y){
					cube.transform.position += Vector3.down; 
				}
			}
			gameObject.GetComponent<ManageAudio> ().PlayFullLine (); 

			for (int j = 0; j < isFullLine.Count; j++) {
				isFullLine [j] -= 1;
			}
		}
			

	}
}

/*
 * 	//Only for debug purposes 
private void printArray(){
	int rowLength = isCube.GetLength(0);
	int colLength = isCube.GetLength(1);

	for (int i = 0; i < rowLength; i++)
	{
		string line = ""; 
		for (int j = 0; j < colLength; j++)
		{
			line += isCube [i, j].ToString (); 
		}
		print (line); 
	}
	Console.ReadLine();
}
*/