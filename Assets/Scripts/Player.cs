using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    Rigidbody2D player;
    private string currentState;
    HelperScript helper;

    // Animation States
    const string IDLE = "idle";
    const string RUN = "run";
    const string JUMP = "jump";
    const string SLIDE = "slide";

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<Rigidbody2D>();
        helper = GetComponent<HelperScript>();
    }
    private void Update()
    {
        if (Input.GetKey("right"))
        {
            player.velocity = new Vector2(5, 0);
            ChangeAnimationState(RUN);
            helper.FlipObject(false);

        }
        // flips the player left, and moves the player left
        if (Input.GetKey("left"))
        {
            player.velocity = new Vector2(-5, 0);
            ChangeAnimationState(RUN);
            helper.FlipObject(true);
        }
        if (player.velocity == new Vector2(0, 0))
        {
            ChangeAnimationState(IDLE);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeAnimationState(JUMP);
            player.velocity = new Vector3(player.velocity.x, 4, 0);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            ChangeAnimationState(SLIDE);
        }
    }
    void ChangeAnimationState(string newState)
    {
        // Stops the same animation from playing again
        if (currentState == newState) return;

        //play the animation
        animator.Play(newState);

        //reassign the current state
        currentState = newState;
    }
}
