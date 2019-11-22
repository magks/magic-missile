using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction {Up,UpRight,Right,DownRight,Down,DownLeft,Left,UpLeft,None};

public class Projectile : MonoBehaviour
{
    public bool playerProjectile;
    public int damage;
    public float speed;
    public float duration;
    public Direction moveDirection;
    Vector2 dirVector;
    Rigidbody2D myRigidbody;
    //int durationInUpdates;
    // Start is called before the first frame update
    private void Awake()
    {
        setDirection(moveDirection);
        setDuration(duration);
    }
    void Start()
    {
        myRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (duration > 0)
        {
            duration -= Time.deltaTime;
            myRigidbody.MovePosition(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y) + (dirVector * (speed * Time.deltaTime)));
        }
        else
        {
            gameObject.SetActive(false);
        }

    }

    public void setDuration(float dur)
    {
        duration = dur;
        //durationInUpdates = Mathf.CeilToInt(dur/Time.timeScale);
    }

    public void setDirection(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                dirVector = Vector2.up;
                break;
            case Direction.UpRight:
                dirVector = (new Vector2(1, 1)).normalized;
                break;
            case Direction.Right:
                dirVector = Vector2.right;
                break;
            case Direction.DownRight:
                dirVector = (new Vector2(1, -1)).normalized;
                break;
            case Direction.Down:
                dirVector = Vector2.down;
                break;
            case Direction.DownLeft:
                dirVector = (new Vector2(-1, -1)).normalized;
                break;
            case Direction.Left:
                dirVector = Vector2.left;
                break;
            case Direction.UpLeft:
                dirVector = (new Vector2(-1, 1)).normalized;
                break;
            default:
                dirVector = Vector2.zero;
                break;
        }
    }

    public void setDirection(Vector2 direction)
    {
        dirVector = direction.normalized;
        return;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Projectile>() == null)
        {
            if (playerProjectile && collision.gameObject.tag == "Enemy")
            {
                this.gameObject.SetActive(false);
            }
            else if (!playerProjectile && collision.gameObject.tag == "Player")
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
