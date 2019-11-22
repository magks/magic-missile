using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 1;
    [HideInInspector]
    public int Health;
    // Start is called before the first frame update
    void Start()
    {
        Health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(Health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
