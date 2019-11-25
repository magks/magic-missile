using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWhenInRange : MonoBehaviour
{
    // Start is called before the first frame update
    MonoBehaviour[] comps;
    Collider2D collider;
    void Start()
    {
        collider = GetComponent<Collider2D>();
        comps = GetComponents<MonoBehaviour>();
        foreach(MonoBehaviour comp in comps)
        {
            comp.enabled = false;
        }
        collider.enabled = true;
        this.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnInRange()
    {
        foreach(MonoBehaviour comp in comps)
        {
            comp.enabled = true;
        }
    }

    public void OnNotInRange()
    {
        foreach (MonoBehaviour comp in comps)
        {
            comp.enabled = false;
        }
        collider.enabled = true;
    }
}
