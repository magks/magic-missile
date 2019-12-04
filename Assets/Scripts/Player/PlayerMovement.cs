using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    Animator animator;

    const int STATE_IDLE = 0;
    const int STATE_WALK = 1;
    const int STATE_JUMP = 2;
    int _currentAnimationState = STATE_IDLE;
    [HideInInspector]
    public bool facingRight = true;
    public GameObject gameObject;
    public float speed = 4;
    public float jumpHeight = 13;
    private Rigidbody2D rigid;
    private PlayerAudio audioPlayer;

    private bool falling = false;

    // Use this for initialization
    void Start()
    {
        //animator = this.GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        audioPlayer = GetComponent<PlayerAudio>();
    }

    // Update is called once per frame
    void Update()
    {

        float inputX = Input.GetAxis("Horizontal");

        Vector2 v2 = new Vector2(inputX * speed, rigid.velocity.y);

        rigid.velocity = v2;

        // If the input is moving the player right and the player is facing left...
        if (inputX > 0 && !facingRight)
        {
            // ... flip the player.
            Flip();
           // changeState(STATE_WALK);
        }

        // Otherwise if the input is moving the player left and the player is facing right...
        else if (inputX < 0 && facingRight)
        {
            // ... flip the player.
            Flip();
            //changeState(STATE_WALK);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
        {
            v2.y = jumpHeight;
            rigid.velocity = v2;
            // changeState(STATE_JUMP);
        }
        if (Input.GetKeyDown("s")) //&& (gameObject.layer == LayerMask.NameToLayer("Character")))
        {
            gameObject.layer = 0; //0 is the default layer
            falling = true;
        }
        
        if (Input.GetKeyUp("s") && falling)
        {
            gameObject.layer = 9; //9 is the character layer
            falling = false;
        }

        else
        {
            //changeState(STATE_IDLE);
        }
    }

    bool Grounded;

    void OnCollisionStay2D(Collision2D collider)
    {
        CheckIfGrounded();
    }

    void OnCollisionExit2D(Collision2D collider)
    {
        Grounded = false;
    }

    private void CheckIfGrounded()
    {
        RaycastHit2D[] hits;

        //We raycast down 1 pixel from this position to check for a collider
        Vector2 positionToCheck = transform.position;
        hits = Physics2D.RaycastAll(positionToCheck, new Vector2(0, -1), 0.01f);

        //if a collider was hit, we are grounded
        if (hits.Length > 0)
        {
            Grounded = true;
        }
    }

    void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


    void OnTriggerStay2D(Collider2D c1)
    {

        if (c1.gameObject.tag == "platform")
        {
            transform.parent = c1.transform;

        }
    }

    void OnTriggerExit2D(Collider2D c1)
    {
        if (c1.gameObject.tag == "platform")
        {
            transform.parent = null;

        }
    }
    void changeState(int state)
    {

        if (_currentAnimationState == state)
            return;

        switch (state)
        {
            case STATE_WALK:
                animator.SetInteger("state", STATE_WALK);
                break;

            case STATE_JUMP:
                animator.SetInteger("state", STATE_JUMP);
                break;

            case STATE_IDLE:
                animator.SetInteger("state", STATE_IDLE);
                break;
        }

        _currentAnimationState = state;
    }
}