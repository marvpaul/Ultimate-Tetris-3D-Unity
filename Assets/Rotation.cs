using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {
	public bool isActive; 
	int rotAngel = 0; 
	Vector3[][] rotation; 
	public Transform[] blocks; 
	public string type; 

	// Use this for initialization
	void Start () {

		//Assign the 4 blocks of each group 
		blocks = new Transform[4]; 
		for (int i = 0; i < transform.childCount; i++) {
			blocks [i] = transform.GetChild (i); 
		}

		getRotByType (type); 
	}

	//Perform rotation to left side
	public void rotateLeft(bool back){
		if(!back)GameObject.Find ("Main Camera").GetComponent<CubeArray> ().removeTemp (blocks); 
		if (rotAngel == 0) {
			rotate (1); 
			rotAngel = 90; 
		} else if (rotAngel == 90) {
			rotate (2); 
			rotAngel = 180; 
		}else if (rotAngel == 180) {
			rotate (3); 
			rotAngel = 270; 
		} else if (rotAngel == 270) {
			rotate (0); 
			rotAngel = 0; 
		}
		if (!back && !GameObject.Find ("Main Camera").GetComponent<CubeArray> ().isValidTurn (blocks)) {
			rotateRight (true); 
		} 
	}



	//Perform rotation clockwards
	public void rotateRight(bool back){
		if(!back)GameObject.Find ("Main Camera").GetComponent<CubeArray> ().removeTemp (blocks); 
		if (rotAngel == 0) {
			rotate (3); 
			rotAngel = 270; 
		} else if (rotAngel == 90) {
			rotate (0); 
			rotAngel = 0; 
		} else if (rotAngel == 180) {
			rotate (1);
			rotAngel = 90; 
		} else if (rotAngel == 270) {
			rotate (2); 
			rotAngel = 180; 
		}
		if (!back && !GameObject.Find ("Main Camera").GetComponent<CubeArray> ().isValidTurn (blocks)) {
			rotateLeft (true); 
		} 
	}

	//Rotate the blocks to position pos
	void rotate(int pos){
		for (int i = 0; i < blocks.Length; i++) {
			blocks [i].localPosition = rotation [pos] [i]; 
		}
	}

	//Check if a key was pressed and perform rotation 
	void Update(){
		if (isActive) {
			if (Input.GetKeyDown (KeyCode.R)) {
				rotateRight (false); 
				GameObject.Find ("Main Camera").GetComponent<CubeArray> ().updateArray ();
			} else if (Input.GetKeyDown (KeyCode.L)) {
				rotateLeft (false); 
				GameObject.Find ("Main Camera").GetComponent<CubeArray> ().updateArray ();
			}
		}

	}

	//Get the rotation pattern by type of the group 
	void getRotByType(string type){
		if (type == "I") {
			Vector3[] rot0 = new Vector3[] {
				new Vector3 (0,0,0),
				new Vector3 (1,0,0),
				new Vector3 (2,0,0),
				new Vector3 (3,0,0)
			};
			Vector3[] rot90 = new Vector3[] {
				new Vector3 (2,1,0),
				new Vector3 (2,0,0),
				new Vector3 (2,-1,0),
				new Vector3 (2,-2,0)
			};
			rotation = new Vector3[][]{ rot0, rot90, rot0, rot90 };
		} else if (type == "T") {
			Vector3[] rot0 = new Vector3[] {
				new Vector3 (0,0,0),
				new Vector3 (1,0,0),
				new Vector3 (2,0,0),
				new Vector3 (1,-1,0)
			};
			Vector3[] rot90 = new Vector3[] {
				new Vector3 (1,1,0),
				new Vector3 (1, 0, 0),
				new Vector3 (2, 0, 0),
				new Vector3 (1,-1,0)
			};
			Vector3[] rot180 = new Vector3[] {
				new Vector3 (0,-1,0),
				new Vector3 (1, 0, 0),
				new Vector3 (1, -1, 0),
				new Vector3 (2,-1,0)
			};
			Vector3[] rot270 = new Vector3[] {
				new Vector3 (0,0,0),
				new Vector3 (1, 0, 0),
				new Vector3 (1, 1, 0),
				new Vector3 (1,-1,0)
			};
			rotation = new Vector3[][]{ rot0, rot90, rot180, rot270 };
		} else if (type == "L") {
			Vector3[] rot0 = new Vector3[] {
				new Vector3 (0,0,0),
				new Vector3 (1,0,0),
				new Vector3 (2,0,0),
				new Vector3 (0,-1,0)
			};
			Vector3[] rot90 = new Vector3[] {
				new Vector3 (1,1,0),
				new Vector3 (1, 0, 0),
				new Vector3 (1, -1, 0),
				new Vector3 (2,-1,0)
			};
			Vector3[] rot180 = new Vector3[] {
				new Vector3 (0,-1,0),
				new Vector3 (1, -1, 0),
				new Vector3 (2, -1, 0),
				new Vector3 (2,0,0)
			};
			Vector3[] rot270 = new Vector3[] {
				new Vector3 (0,1,0),
				new Vector3 (1, 0, 0),
				new Vector3 (1, 1, 0),
				new Vector3 (1,-1,0)
			};
			rotation = new Vector3[][]{ rot0, rot90, rot180, rot270 };
		}else if (type == "L2") {
			Vector3[] rot0 = new Vector3[] {
				new Vector3 (0,0,0),
				new Vector3 (1,0,0),
				new Vector3 (2,0,0),
				new Vector3 (2,-1,0)
			};
			Vector3[] rot90 = new Vector3[] {
				new Vector3 (1,1,0),
				new Vector3 (1, 0, 0),
				new Vector3 (1, -1, 0),
				new Vector3 (2,1,0)
			};
			Vector3[] rot180 = new Vector3[] {
				new Vector3 (0,-1,0),
				new Vector3 (1, -1, 0),
				new Vector3 (2, -1, 0),
				new Vector3 (0,0,0)
			};
			Vector3[] rot270 = new Vector3[] {
				new Vector3 (0,-1,0),
				new Vector3 (1, 0, 0),
				new Vector3 (1, 1, 0),
				new Vector3 (1,-1,0)
			};
			rotation = new Vector3[][]{ rot0, rot90, rot180, rot270 };
		} else if (type == "Z1") {
			Vector3[] rot0 = new Vector3[] {
				new Vector3 (1,0,0),
				new Vector3 (2,0,0),
				new Vector3 (0,-1,0),
				new Vector3 (1,-1,0)
			};
			Vector3[] rot90 = new Vector3[] {
				new Vector3 (0,0,0),
				new Vector3 (1, 0, 0),
				new Vector3 (0, 1, 0),
				new Vector3 (1,-1,0)
			};
			rotation = new Vector3[][]{ rot0, rot90, rot0, rot90 };
		} else if (type == "Z2") {
			Vector3[] rot0 = new Vector3[] {
				new Vector3 (1,0,0),
				new Vector3 (0,0,0),
				new Vector3 (2,-1,0),
				new Vector3 (1,-1,0)
			};
			Vector3[] rot90 = new Vector3[] {
				new Vector3 (2,0,0),
				new Vector3 (1, 0, 0),
				new Vector3 (2,1, 0),
				new Vector3 (1,-1,0)
			};
			rotation = new Vector3[][]{ rot0, rot90, rot0, rot90 };
		} else if (type == "O") {
			Vector3[] rot0 = new Vector3[] {
				new Vector3(0,0,0), 
				new Vector3(1,0,0),
				new Vector3(1,1,0),
				new Vector3(0,1,0)
			};
			rotation = new Vector3[][]{ rot0, rot0, rot0, rot0 };
		}
	}
}
