using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    static float FadeTime = 1;
    public int maxHealth = 1;
    [HideInInspector]
    public int Health;
    SpriteRenderer sprite;
    //AudioSource audioData;

	// slime death sound 
    private EnemyAudio audioplayer;

    // Start is called before the first frame update
    void Start()
    {
        Health = maxHealth;
        sprite = GetComponent<SpriteRenderer>();
        audioplayer = GetComponent<EnemyAudio>(); 
        Debug.Log("born");
    }

    void Die()
    {
		Debug.Log("dead");
        audioplayer.DeathSound();
		gameObject.SetActive(false);
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
            //audioData = GetComponent<AudioSource>();
            //audioData.Play(0);
			Die();
        }
    }
}
