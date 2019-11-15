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

        // Check all bullets to see if deactivated, return to pool if there are.
        LinkedListNode<GameObject> current = bullets.First;
        List<LinkedListNode<GameObject>> delete = new List<LinkedListNode<GameObject>>();
        while(current != null)
        {
            if (!current.Value.activeSelf)
            {
                delete.Add(current);
                ProjectilePool.projectilePool.returnPooledObject(PoolID.playerProjectile, current.Value);
            }
            current = current.Next;
        }
        // Then remove nodes for returned bullets.
        foreach(LinkedListNode<GameObject> node in delete)
        {
            bullets.Remove(node);
        }
        
    }

    GameObject ShootBullet(Direction dir)
    {
        GameObject thisBullet = ProjectilePool.projectilePool.getPooledObject(PoolID.playerProjectile);
        Projectile bulletProperties = thisBullet.GetComponent<Projectile>();
        bullets.AddLast(thisBullet);
        thisBullet.transform.SetParent(gameObject.transform, false);
        thisBullet.transform.localPosition = Vector2.zero;
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
