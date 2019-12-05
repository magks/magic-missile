using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    //public AudioSource death;
	public AudioClip enemy_death;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        return;
    }

    public void DeathSound()
    {
		float volume = 1;
		// Enemy death sound plays relative to where the camera is
		Vector3 position = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
		//Debug.Log("position:" + position);
		AudioSource.PlayClipAtPoint(enemy_death, position, volume);
		

    }
}
