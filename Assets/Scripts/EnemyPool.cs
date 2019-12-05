using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
 
 public class EnemyPool: MonoBehaviour
{
     int enemiesLeft = 0;

     // Use this for initialization
     void Start () {
         enemiesLeft = 9; // can i get this programmatically?
     }
     
     // Update is called once per frame
     void Update () 
	 {
		 GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
         enemiesLeft = enemies.Length;

         if(enemiesLeft == 0)
         {
			 Debug.Log("Level3: All enemies defeated!");
			 SceneManager.LoadScene("StartMenu 1"); 
         }
     }
 }
