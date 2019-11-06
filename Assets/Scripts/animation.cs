using UnityEngine;
using System.Collections;

public class animation : MonoBehaviour
{
    Animator animator;

    const int STATE_IDLE = 0;
    const int STATE_WALK = 1;
    const int STATE_JUMP = 2;
    int _currentAnimationState = STATE_IDLE;
    // Use this for initialization
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("a"))
        {
            //animator.SetInteger("state", STATE_WALK);
            changeState(STATE_WALK);
        }
        else if (Input.GetKey("space"))
        {
            //animator.SetInteger("state", STATE_JUMP);
            changeState(STATE_JUMP);
        }
        else
        {
                changeState(STATE_IDLE);
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
