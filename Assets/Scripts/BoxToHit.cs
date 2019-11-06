using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BoxToHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        
	
	}

    // Instant reset when object touches wall.
    void OnCollisionEnter2D(Collision2D c1)
    {
        SceneManager.LoadScene("new scene");
    }

    // Possible use later for polishing
    //void OnTriggerEnter2D(Collider2D c1) {
    //    for (int i = 0; i < 100000000; i++)
    //    { }
    //    SceneManager.LoadScene("New scene");
    //}
    //ontriggerenter2d
}
