using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : Shoot
{
    PlayerAudio audioPlayer;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        audioPlayer = GetComponent<PlayerAudio>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override GameObject ShootBullet(Direction dir)
    {
        audioPlayer.ShootSound();
        return base.ShootBullet(dir);
    }
}
