using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomShoot : EnemyShoot
{
    public float additionalRandomDelay;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        timeSinceLastShot += Random.value * additionalRandomDelay;
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (timeSinceLastShot <= 0)
        {
            timeSinceLastShot = shotDelay + Random.value * additionalRandomDelay;
            GameObject newBullet = ShootBullet();
        }
        else
        {
            timeSinceLastShot -= Time.deltaTime;
        }
        LinkedListNode<GameObject> first = bullets.First;
        if (first != null)
        {
            if (first.Value != null && !first.Value.activeSelf)
            {
                bullets.RemoveFirst();
                ProjectilePool.projectilePool.returnPooledObject(PoolID.enemyProjectile, first.Value);
            }
        }
    }
}
