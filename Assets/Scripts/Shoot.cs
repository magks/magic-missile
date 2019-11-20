using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float bulletSpeed;
    public int bulletDamage;
    public float bulletDuration;
    public float shotDelay;
    float timeSinceLastShot;
    LinkedList<GameObject> bullets;
    // Start is called before the first frame update
    void Start()
    {
        bullets = new LinkedList<GameObject>();
        timeSinceLastShot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeSinceLastShot <= 0)
        {
            if(Input.GetKey(KeyCode.LeftArrow))
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    GameObject newBullet = ShootBullet(Direction.UpLeft);
                    newBullet.transform.rotation = Quaternion.Euler(0, 0, 135);
                    timeSinceLastShot = shotDelay;
                }
                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    GameObject newBullet = ShootBullet(Direction.DownLeft);
                    newBullet.transform.rotation = Quaternion.Euler(0, 0, 225);
                    timeSinceLastShot = shotDelay;
                }
                else
                { 
                    GameObject newBullet = ShootBullet(Direction.Left);
                    newBullet.transform.rotation = Quaternion.Euler(0, 0, 180);
                    timeSinceLastShot = shotDelay;
                }
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    GameObject newBullet = ShootBullet(Direction.UpRight);
                    newBullet.transform.rotation = Quaternion.Euler(0, 0, 45);
                    timeSinceLastShot = shotDelay;
                }
                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    GameObject newBullet = ShootBullet(Direction.DownRight);
                    newBullet.transform.rotation = Quaternion.Euler(0, 0, 315);
                    timeSinceLastShot = shotDelay;
                }
                else
                {
                    GameObject newBullet = ShootBullet(Direction.Right);
                    newBullet.transform.rotation = Quaternion.Euler(0, 0, 0);
                    timeSinceLastShot = shotDelay;
                }
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                GameObject newBullet = ShootBullet(Direction.Up);
                newBullet.transform.rotation = Quaternion.Euler(0, 0, 90);
                timeSinceLastShot = shotDelay;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                GameObject newBullet = ShootBullet(Direction.Down);
                newBullet.transform.rotation = Quaternion.Euler(0, 0, 270);
                timeSinceLastShot = shotDelay;
            }
        }
        else
        {
            timeSinceLastShot -= Time.deltaTime;
        }

        // Check first bullet to see if deactivated, return to pool if so.
        LinkedListNode<GameObject> first = bullets.First;
        if (first!=null)
        {
            if(first.Value!=null && !first.Value.activeSelf)
            {
                bullets.RemoveFirst();
                ProjectilePool.projectilePool.returnPooledObject(PoolID.playerProjectile, first.Value);
            }
        }

        
    }

    Vector2 projectileSpawnLoc(Direction dir)
    {
        Vector2 location = Vector2.zero;
        float scale = 2f*gameObject.transform.localScale.x;
        switch (dir)
        {
            case Direction.Up:
                location = Vector2.up * scale;
                break;
            case Direction.UpRight:
                location = (Vector2.one).normalized * scale ;
                
                break;
            case Direction.Right:
                location = Vector2.right * scale;
                break;
            case Direction.DownRight:
                location = (new Vector2(1, -1)).normalized * scale;
                break;
            case Direction.Down:
                location = Vector2.down * scale;
                break;
            case Direction.DownLeft:
                location = (Vector2.one).normalized * -scale;
                break;
            case Direction.Left:
                location = Vector2.left * scale;
                break;
            case Direction.UpLeft:
                location = (new Vector2(-1, 1)).normalized * scale;
                break;
            default:
                location = Vector2.zero;
                break;
        }
        return location;
    }

    GameObject ShootBullet(Direction dir)
    {
        GameObject thisBullet = ProjectilePool.projectilePool.getPooledObject(PoolID.playerProjectile);
        Projectile bulletProperties = thisBullet.GetComponent<Projectile>();
        bullets.AddLast(thisBullet);
        thisBullet.transform.SetParent(gameObject.transform, false);
        thisBullet.transform.localPosition = projectileSpawnLoc(dir);
        thisBullet.transform.SetParent(null);
        thisBullet.transform.localScale = Vector3.one;
        bulletProperties.setDuration(bulletDuration);
        bulletProperties.speed = bulletSpeed;
        bulletProperties.damage = bulletDamage;
        bulletProperties.setDirection(dir);
        thisBullet.SetActive(true);
        return thisBullet;
    }
}
