using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBoxTuner : MonoBehaviour
{
    BoxCollider2D activeArea;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        activeArea = GetComponent<BoxCollider2D>();
        cam = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        float halfHeight = cam.orthographicSize;
        float halfWidth = halfHeight * cam.aspect;
        activeArea.size = new Vector2(halfWidth * 2, halfHeight *2);
    }
}
