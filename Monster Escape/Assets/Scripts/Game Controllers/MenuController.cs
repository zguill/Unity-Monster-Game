using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class MenuController : MonoBehaviour {

    public Button start; 

	// Use this for initialization
	void Start () {

        start = start.GetComponent<Button>();
	}
	
	// Update is called once per frame
	public void StartLevel() {

        Application.LoadLevel(1);


		
	}
}
