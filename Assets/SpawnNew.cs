using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNew : MonoBehaviour {
	//All given groups
	public GameObject[] groups; 
	public GameObject[] groupsAlternative; 

	//Spawn the next group
	public GameObject spawnNext(){
		int i = Random.Range(0, groups.Length);

		// Spawn Group at current Position
		return Instantiate(groups[i],
			new Vector3(3, 14),
			Quaternion.identity);
	}
	public bool gameOver(GameObject group)
	{ 		Transform[] blockposition = group.GetComponent<Rotation>().blocks; 		if (!gameObject.GetComponent<CubeArray>().isValidTurn(blockposition))
		{ 			return true; 		} 		return false;
	}
}
