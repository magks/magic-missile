using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
 
 public class EnemyPool: MonoBehaviour
{
     public GameObject fadeOverlay;
	 GameObject[] enemies; 
     private SpriteRenderer fadeSprite;
     int enemiesLeft = 0;
     bool complete = false;

     // Use this for initialization
     void Start () 
	 {
		 get_enemy_count();
         fadeSprite = fadeOverlay.GetComponent<SpriteRenderer>();
     }

    IEnumerator fadeOut()
    {
        complete = true;
        Color fadeColor = fadeSprite.color;
        float opacity = 0;
        float fadeSeconds = 4;
        float timeLeft = 0;
        while (opacity != 1)
        {
            yield return null;
            timeLeft += Time.deltaTime;
            opacity = Mathf.Min(1, timeLeft / fadeSeconds);
            fadeColor.a = opacity;
            fadeSprite.color = fadeColor;
        }
        SceneManager.LoadScene("StartMenu 1");
    }

	void get_enemy_count()
	{ 
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
	   	enemiesLeft = enemies.Length;
	}

     // Update is called once per frame
     void Update () 
	 {
		 get_enemy_count();
         if(enemiesLeft == 0 && !complete)
         {
			 Debug.Log("Level3: All enemies defeated!");
             StartCoroutine(fadeOut());
         }
     }
 }
