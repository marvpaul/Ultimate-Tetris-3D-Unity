using UnityEngine;
using System.Collections;

public class DEMO_DestroyWindow : MonoBehaviour {

	private GameObject parentWindow;
	private GameObject callButton;


	public void Start(){

	}

	public void Update(){
		
	}

	public void DestroyWindowParent(){
		Debug.Log("destroy window");
		callButton = GameObject.Find("bt_ShareLink");
		callButton.GetComponent<DEMO_CreateWindowShareLink>().windowIndicator = 0;
		Destroy(this.transform.parent.transform.gameObject);
	}
}
