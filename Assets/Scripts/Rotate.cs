using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    float x;
	// Update is called once per frame
	void Update () {
        x += Time.deltaTime * 50;

        transform.rotation = Quaternion.Euler(0, 0, x);
    }

}
