using UnityEngine;
using System.Collections;

public class MoveFloor : MonoBehaviour {
    float x, StartX;
    private Vector2 v = new Vector2();
    bool left;
    // Use this for initialization
    void Start()
    {
        v.x = transform.position.x;
        v.y = transform.position.y;
        x = v.x;
        StartX = x; 
        left = false;
    }
    //this is a comment
    // Update is called once per frame
    void Update()
    {
        if (left)
        {
            x += -.05F;
        }
        else
        {
            x += .05F;
        }
        if (transform.position.x >= StartX + 20)
        {

            left = true;

        }
        if (transform.position.x <= StartX)
        {
            left = false;
        }
        v.x = x;
        this.transform.position = v;
    }
    void FixedUpdate()
    {
       

    }

}

