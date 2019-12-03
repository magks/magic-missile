﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    static float FadeTime = 1;
    public int maxHealth = 1;
    [HideInInspector]
    public int Health;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        Health = maxHealth;
        sprite = GetComponent<SpriteRenderer>();
    }

    void Die()
    {

    }

    public IEnumerator DeathFade()
    {
        float animTime = 0;
        float startOpacity = sprite.color.a;
        Color newColor = sprite.color;
        while(animTime < FadeTime)
        {
            newColor.a = startOpacity * ((FadeTime - animTime) / FadeTime);
            sprite.color = newColor;
            animTime += Time.deltaTime;
            yield return null;
        }
        
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