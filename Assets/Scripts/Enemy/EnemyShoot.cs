using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : Shoot
{
    GameObject player;
    // Start is called before the first frame update
    protected override void Start()
    {
        timeSinceLastShot = shotDelay;
        player = GameObject.FindGameObjectWithTag("Player");
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (timeSinceLastShot <= 0)
        {
            timeSinceLastShot = shotDelay;
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


    protected Vector2 projectileSpawnLoc(Vector2 dirVector)
    {
        float scale = 2f * gameObject.transform.localScale.x;
        return dirVector.normalized * scale;
    }

    protected virtual GameObject ShootBullet()
    {
        GameObject thisBullet = ProjectilePool.projectilePool.getPooledObject(PoolID.enemyProjectile);
        Projectile bulletProperties = thisBullet.GetComponent<Projectile>();
        Vector3 dirVector3 = player.transform.position - gameObject.transform.position;
        Vector2 dirVector = (new Vector2(dirVector3.x, dirVector3.y)).normalized;
        bullets.AddLast(thisBullet);
        thisBullet.transform.SetParent(gameObject.transform, false);
        thisBullet.transform.localPosition = projectileSpawnLoc(dirVector);
        thisBullet.transform.SetParent(null);
        thisBullet.transform.localScale = dirVector.x > 0? Vector3.one : new Vector3(-1, 1, 1);
        bulletProperties.setDuration(bulletDuration);
        bulletProperties.speed = bulletSpeed;
        bulletProperties.damage = bulletDamage;
        bulletProperties.setDirection(dirVector.normalized);
        thisBullet.SetActive(true);
        return thisBullet;
    }
}
