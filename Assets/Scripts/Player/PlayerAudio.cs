using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource fire;
    public AudioSource jump;
    public AudioSource death;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        return;
    }

    public void ShootSound()
    {
        fire.PlayOneShot(fire.clip);
    }

    public void JumpSound()
    {
        jump.Play();
    }

    public void DeathSound()
    {
        death.Play();
    }
}
