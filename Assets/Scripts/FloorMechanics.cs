using UnityEngine;
using System.Collections;

public class FloorMechanics : MonoBehaviour {
    Color prevColor;

    // Use this for initialization
    void Start () {
        prevColor = GetComponent<Renderer>().material.color;

        GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update () {
        //GetComponent<Renderer>().material.color += new Color(0, 0, 0, .1f);
        //GetComponent<Renderer>().material.color = new Color(0, 0, 0, 1f);
    }

    void OnTriggerEnter2D(Collider2D c1)
    {
        if (!c1.gameObject.name.Equals("player"))
        {
            //GetComponent<Renderer>().material.color = new Color(0, 0, 0, 1f)
            GetComponent<Renderer>().material.color = prevColor;
        }
    }


    void OnTriggerExit2D(Collider2D c1)
    {
        if (!c1.gameObject.name.Equals("player"))
        {
            //GetComponent<Renderer>().material.color = prevColor;
            //GetComponent<Collider2D>().isTrigger = false;
            GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);

        }
    }
}
