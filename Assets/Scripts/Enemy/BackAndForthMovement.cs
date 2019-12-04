using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForthMovement : MonoBehaviour
{
    public float walkRadius;
    public float speed;
    float waitTime;
    float home;
    bool facingRight;
    int waitState;
    Rigidbody2D rigid;
    
    // Start is called before the first frame update
    private void Awake()
    {
        home = transform.position.x;
        rigid = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        if (transform.localScale.x > 0)
        {
            facingRight = true;
        }
        else if (transform.localScale.x < 0)
        {
            facingRight = false;
        }
        waitState = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (waitState==0)
        {
            if (facingRight)
            {
                if (transform.position.x > home + walkRadius)
                {
                    Flip();
                }
            }
            else
            {
                if (transform.position.x < home - walkRadius)
                {
                    Flip();
                }
            }
            int dir = facingRight ? 1 : -1;
            Vector2 newPos = new Vector2(transform.position.x + dir * speed * Time.deltaTime, transform.position.y);
            rigid.MovePosition(newPos);
        }
        else if(waitState == 2)
        {
            waitTime -= Time.deltaTime;
            if(waitTime < 0)
            {
                waitState = 0;
            }
        }
    }

    void Flip()
    {
        // Switch the way the enemy is labelled as facing.
        facingRight = !facingRight;

        // Multiply the enemy's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.tag == "Player")
        {
            waitState = 1;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            waitState = 2;
            waitTime = 3;
        }
    }
}
