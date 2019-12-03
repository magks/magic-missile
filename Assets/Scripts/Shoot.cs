using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float bulletSpeed;
    public int bulletDamage;
    public float bulletDuration;
    public float shotDelay;
    protected float timeSinceLastShot;
    protected LinkedList<GameObject> bullets;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        bullets = new LinkedList<GameObject>();
        timeSinceLastShot = 0;
    }

    // Update is called once per frame
    protected virtual void Update()
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

    protected Vector2 projectileSpawnLoc(Direction dir)
    {
        int reflection = gameObject.transform.localScale.x >= 0 ? 1 : -1;
        Vector2 location = reflection >=0?new Vector3(1.1f,.45f,0): new Vector3(1f,.45f,0);
        

        switch (dir)
        {
            case Direction.Up:
                location.y += 1f;
                break;
            case Direction.UpRight:
                location += (new Vector2(1 * reflection, 1)).normalized;
                
                break;
            case Direction.Right:
                location.x += 1 * reflection;
                break;
            case Direction.DownRight:
                location += (new Vector2(1 * reflection, -1)).normalized;
                break;
            case Direction.Down:
                location.y += -1;
                break;
            case Direction.DownLeft:
                location += (new Vector2(-1 * reflection, -1)).normalized;
                break;
            case Direction.Left:
                location.x += -1 * reflection;
                break;
            case Direction.UpLeft:
                location += (new Vector2(-1 * reflection, 1)).normalized;
                break;
            default:
                location = Vector2.zero;
                break;
        }
        
        return location;
    }

    protected virtual GameObject ShootBullet(Direction dir)
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
