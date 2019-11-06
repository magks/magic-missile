using UnityEngine;
using System.Collections;

public class RotateBeginLight : MonoBehaviour {

    bool goingUp = true;
	// Use this for initialization
	void Start () {
	
	}

    float x;
    // Update is called once per frame
    void Update()
    {

        if (x < 115 && goingUp)
        {
            x += Time.deltaTime * 25;

            transform.rotation = Quaternion.Euler(0, 0, x);

        }
        else
        {
            goingUp = false;
            x += -Time.deltaTime * 25;

            transform.rotation = Quaternion.Euler(0, 0, x);

        }

        if(x < 2)
        {
            goingUp = true;
        }
    }
}
