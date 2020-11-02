using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCreator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject cube = (GameObject)Resources.Load("cube");
        for(int i = 0; i < 5; i++){
            for(int j = 0; j < 8; j++){
                GameObject cubeInstance = Instantiate(cube); 
                cubeInstance.transform.position += Vector3.right*2f*i ;
                cubeInstance.transform.position += Vector3.up*2f*j;
                cubeInstance.transform.parent = GameObject.Find("Grid").transform;

            }
        }

        for(int i = -1; i <= 5; i++){
                GameObject cubeInstance = Instantiate(cube); 
                cubeInstance.transform.position += Vector3.right*2f*i;
                cubeInstance.transform.position += Vector3.back*1.25f; 
                cubeInstance.transform.position += Vector3.down*2f; 
                cubeInstance.transform.parent = GameObject.Find("Grid").transform;
        }

        for(int i = 0; i < 8; i++){
                GameObject cubeInstance = Instantiate(cube); 
                cubeInstance.transform.position += Vector3.up*2f*i;
                cubeInstance.transform.position += Vector3.back*1.25f; 
                cubeInstance.transform.position += Vector3.right*5f*2f; 
                cubeInstance.transform.parent = GameObject.Find("Grid").transform;
        }

        for(int i = 0; i < 8; i++){
                GameObject cubeInstance = Instantiate(cube); 
                cubeInstance.transform.position += Vector3.left *2f;
                cubeInstance.transform.position += Vector3.up*2f*i;
                cubeInstance.transform.position += Vector3.back*1.25f; 
                cubeInstance.transform.parent = GameObject.Find("Grid").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
