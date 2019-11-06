using UnityEngine;
using System.Collections;

public class Clockwise : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame


	float x;
	// Update is called once per frame
	void Update () {
		x -= Time.deltaTime * 25;

		transform.rotation = Quaternion.Euler(0, 0, x);
	}
	

}
