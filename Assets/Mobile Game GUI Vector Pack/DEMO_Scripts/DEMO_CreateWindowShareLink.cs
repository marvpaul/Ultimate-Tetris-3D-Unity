using UnityEngine;
using System.Collections;

public class DEMO_CreateWindowShareLink : MonoBehaviour {

	public GameObject window;
	public GameObject buttonClose;
	private GameObject canvas;
	public int windowIndicator;
	private GameObject newWindow;


	// Use this for initialization
	void Start () {
		windowIndicator = 0;
		canvas = GameObject.Find("Canvas");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CreateWindow(){
		if(windowIndicator == 0) {
			windowIndicator += 1;

			Debug.Log ("---> Window ShareLink create");
			newWindow = Instantiate(window);
			newWindow.transform.SetParent(canvas.transform);
		}
	}



}
