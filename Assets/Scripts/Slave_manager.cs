using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slave_manager : Interactable
{
    static Transform player = null;

    Transform target;


    float speed = 1f;

    public static float distanceFromPlayer = 1f;

    Rigidbody2D ridge;
    SpriteRenderer renderer;
    Animator animator;

    string[] lines = { "Please kill me.", "I will work.", "Why can't I die?", "Life is a waste.", "Am I alive or am I dead?", "That kills...", "Where is my child?", "I think I ate it.", "Anything seems to pass as food nowadays.", "I need food. Please!", "This is hell." };

    bool isMoving = false;

    public enum SlaveCommands
    {
        FOLLOW
    }


    SlaveCommands command = SlaveCommands.FOLLOW;



    public override void OnInteract()
    {
        Dialog.DisplayDialog("Slave", lines[Random.Range(0, lines.Length)]);
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
        ridge = GetComponent<Rigidbody2D>();
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        target = player;
    }

    private void Update()
    {
        Vector2 val = transform.position - target.position;
        float xStrength = val.x / val.y;
        float yStrength = val.y / val.x;
        string animation = "Idle";
        if (isMoving)
            animation = "Walk";


        if(xStrength > yStrength)
        {
            animator.Play("SlaveSide" + animation);
            if(val.x < 0)
            {
                renderer.flipX = false;
            }
            else
            {
                renderer.flipX = true;
            }
        }
        else
        {
            renderer.flipX = false;
            if(val.y > 0)
            {
                animator.Play("SlaveForward" + animation);
            }
            else
            {
                animator.Play("SlaveBack" + animation);
            }
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (command == SlaveCommands.FOLLOW)
        {
            if (Vector2.Distance(transform.position, target.position) >= distanceFromPlayer)
            {
                isMoving = true;
                Vector3 relativePos = target.position - transform.position;
                ridge.AddForce(speed * relativePos);
            }
            else
            {
                isMoving = false;
                ridge.velocity = Vector3.zero;
            }
        }
    }
}
