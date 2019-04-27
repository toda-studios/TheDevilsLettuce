using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_manager : MonoBehaviour
{
    public enum Direction
    {
        RIGHT, LEFT, UP, DOWN
    }


    public float playerSpeed = 1f;
    SelectorObject selector;
    Animator animator;
    SpriteRenderer renderer;

    private void Start()
    {
        selector = new SelectorObject(this.gameObject, 0.2f, 0.35f);
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
        
    }

    private void Update()
    {
        ManageAnimation();

        if (!Dialog.isVisible)
        {
            if (Input.GetButtonDown("Submit"))
            {
                selector.Interact();
            }
        }
    }

    private void FixedUpdate()
    {
        if (!Dialog.isVisible)
        {
            Movement();
        }
    }

    void OnDrawGizmos()
    {
        try{  
            selector.DrawGizmos();
        }
        catch { }
    }

    class SelectorObject
    {
        GameObject selector; //Actual gameObjet of the selector

        //Offset values
        float xOffset { get; }
        float yOffset { get; }


        Direction currentDirection = Direction.DOWN; //Direction selector is at


        public SelectorObject(GameObject parent, float colliderOffset, float yColliderOffset = 0)
        {
            selector = new GameObject();
            selector.transform.SetParent(parent.transform);
            //Create trigger component
            CircleCollider2D collider = selector.AddComponent<CircleCollider2D>();
            collider.isTrigger = true;
            collider.radius = 0.15f;
            selector.AddComponent<Selector_manager>();

            //Set selector offset values
            xOffset = colliderOffset;
            if(yColliderOffset == 0)
            {
                yOffset = xOffset;
            }
            else
            {
                yOffset = yColliderOffset;
            }
        }

        //Draw selector
        public void DrawGizmos()
        {
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(selector.transform.position, Radius);
        }

        public void Interact()
        {
            Interactable interactable = selector.GetComponent<Selector_manager>().GetInterable();

            //Exit if no interable is found
            if (interactable == null)
                return;

            //Interact with interactable
            interactable.OnInteract();
        }

        //Move selector location
        public void UpdateLocation()
        {
            switch (direction)
            {
                case Direction.UP:
                    selector.transform.localPosition = new Vector2(0, yOffset);
                    break;
                case Direction.RIGHT:
                    selector.transform.localPosition = new Vector2(xOffset, 0);
                    break;
                case Direction.LEFT:
                    selector.transform.localPosition = new Vector2(-xOffset, 0);
                    break;
                case Direction.DOWN:
                    selector.transform.localPosition = new Vector2(0, -yOffset);
                    break;
            }
        }

        //Update location when setting direction
        public Direction direction
        {
            get
            {
                return currentDirection;
            }
            set
            {
                currentDirection = value;
                UpdateLocation();
            }
        }

        //Get/set radius of collider
        public float Radius
        {
            get
            {
                return selector.GetComponent<CircleCollider2D>().radius;
            }
            set
            {
                selector.GetComponent<CircleCollider2D>().radius = value;
            }
        }

    }

    private void ManageAnimation()
    {
        string playAnimation = "Walk";
        if(GetComponent<Rigidbody2D>().velocity == new Vector2(0,0))
        {
            playAnimation = "Idle";
        }

        switch (selector.direction)
        {
            case Direction.RIGHT:
                animator.Play("DevilSide" + playAnimation);
                renderer.flipX = false;
                break;
            case Direction.UP:
                animator.Play("DevilForward" + playAnimation);
                renderer.flipX = false;
                break;
            case Direction.DOWN:
                animator.Play("DevilForward" + playAnimation);
                renderer.flipX = false;
                break;
            case Direction.LEFT:
                animator.Play("DevilSide" + playAnimation);
                renderer.flipX = true;
                break;
        }
    }


    private void Movement()
    {
        Vector3 movement = Vector3.zero;
        if (Input.GetAxis("Vertical") > 0)
        {
            selector.direction = Direction.UP;
            movement += new Vector3(0, playerSpeed, 0);
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            selector.direction = Direction.DOWN;
            movement -= new Vector3(0, playerSpeed, 0);
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            selector.direction = Direction.RIGHT;
            movement += new Vector3(playerSpeed, 0, 0);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            selector.direction = Direction.LEFT;
            movement -= new Vector3(playerSpeed, 0, 0);
        }
        GetComponent<Rigidbody2D>().velocity = movement;
    }
}
