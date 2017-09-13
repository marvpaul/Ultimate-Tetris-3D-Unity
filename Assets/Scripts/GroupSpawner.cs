using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class spawn hold all existing cube groups and
 * can spawn a random one
 */
public class GroupSpawner : MonoBehaviour {
	//A wrapper GO which wraps all groups
	public GameObject groupWrapper; 
	//All given groups
	public GameObject[] groups; 

	//Spawn the next group
	public GameObject spawnNext(){
		int i = Random.Range(0, groups.Length);
		GameObject newGroup = Instantiate(groups[i], new Vector3(3, 14), Quaternion.identity);
		newGroup.transform.parent = groupWrapper.transform; 
		return newGroup; 
	}
}
