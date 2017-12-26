using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class spawn hold all existing cube groups and
 * can spawn a random one
 */
public class GroupSpawner : MonoBehaviour {
	
	//All given groups
	public GameObject[] groups; 

	//Spawn the next group
	public GameObject spawnNext(){
		int i = Random.Range(0, groups.Length);
		return Instantiate(groups[i],
			new Vector3(3, 14),
			Quaternion.identity);
	}
}
