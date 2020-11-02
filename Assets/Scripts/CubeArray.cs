using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class CubeArray : MonoBehaviour {
	bool[,] isCube; 

	//Update the cube array and return false if there is any intersection between two cubes
	public bool getCubePositionFromScene(){
		isCube = new bool[10, 17]; 
		foreach (GameObject cube in GameObject.FindGameObjectsWithTag("Cube")) {
			int x = (int)cube.transform.position.x; 
			int y = (int)cube.transform.position.y;
			if (x >= 0 && x < isCube.GetLength (0) && y >= 0 && y < isCube.GetLength (1)) {
				bool cubeSetted = isCube [x, y]; 
				if (cubeSetted) {
					// Two cubes have the same position --> intersection
					return false;
				} else {
					isCube [x, y] = true;
				}
			} else {
				//Position is out of range, e.g. when we are trying to set down when it's not possible
				return false;
			}
		}
		return true; 
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

		gameObject.GetComponent<Highscore>().addPointsForLines (isFullLine.Count); 

		//For each full line
		for(int i = 0; i < isFullLine.Count; i++){
			//Delete all cubes in a row
			foreach (GameObject cube in GameObject.FindGameObjectsWithTag("Cube")) {
				int y = (int)cube.transform.position.y;
				if(isFullLine[i] == y){
					if(cube.transform.parent.childCount == 1){
						Destroy(cube.transform.parent.gameObject);
					} else {
						Destroy (cube); 
					}
				}
			}
			//Set down all cubes above the deleted row
			foreach (GameObject cube in GameObject.FindGameObjectsWithTag("Cube")) {
				int y = (int)cube.transform.position.y;
				if(isFullLine[i] < y){
					cube.transform.position += Vector3.down; 
				}
			}
			
			GameObject.Find("FullLine").GetComponent<AudioSource>().Play();

			for (int j = 0; j < isFullLine.Count; j++) {
				isFullLine [j] -= 1;
			}
		}
			

	}
}