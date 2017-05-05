using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class CubeArray : MonoBehaviour {
	public bool[,] isCube; 
	// Use this for initialization
	void Start () {
		isCube = new bool[10,17];
		updateArray (); 
	}

	//Check if its a valid turn to apply the coords from positions array
	public bool isValidTurn(Transform[] positions){
		for (int i = 0; i < positions.Length; i++) {
			int x = (int)positions [i].position.x; 
			int y = (int)positions [i].position.y;
			if (Enumerable.Range(0,isCube.GetLength (0)-1).Contains(x) && Enumerable.Range(0,isCube.GetLength (1)-1).Contains(y)) {
				if (isCube [x, y]) {
					return false; 
				}
			} else {
				return false; 
			}
		}
		return true; 
	}

	//Update the cube array 
	public void updateArray(){
		isCube = new bool[10, 17]; 
		foreach (GameObject cube in GameObject.FindGameObjectsWithTag("Cube")) {
			isCube [(int)cube.transform.position.x,(int)cube.transform.position.y] = true;

		}
	}

	//Deactivate the coords from positions array in the isCube array
	//Until the next updateArray() call
	//This function is useful to check if a certain movement is allowed
	//TODO: Combine the removeTemp and isValidTurn methods 
	public void removeTemp(Transform[] positions){
		for (int i = 0; i < positions.Length; i++) {
			int x = (int)positions [i].position.x; 
			int y = (int)positions [i].position.y;
			isCube [x, y] = false;
		}
	}

	//Only for debug purposes 
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
}
