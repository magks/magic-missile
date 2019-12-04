using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGAudio : MonoBehaviour
{
    public AudioSource cave;
    public AudioSource jungle;
    public AudioSource castle;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlayCave()
    {
        cave.Play();
    }
    
    public void PlayJungle()
    {
        jungle.Play();
    }

    public void PlayCastle()
    {
        castle.Play();
    }
}
