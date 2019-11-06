using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void onGUI()
    {
        GUI.Label(new Rect(10, 10, 400, 90), "myTimer = " + 9);
    }

}
