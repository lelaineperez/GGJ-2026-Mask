using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D RB;
    public float speed = 5f;

    public bool canMove;
    public bool isTalkingToNPC;
    public bool isTalkingToDeputy;


    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        canMove = true;
        isTalkingToNPC = false;
    }

    void Update()
    {
        // HORIZONTAL + VERTICAL MOVEMENT works both WASD + Arrows

        if (canMove == true)
        {
            RB.linearVelocity = PlayerMovement();
        }

        // Vector2 vel = Vector2.zero;
        //
        // if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        //     vel.x = speed;
        //
        // if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        //     vel.x = -speed;
        //
        // if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        //     vel.y = speed;
        //
        // if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        //     vel.y = -speed;
        //
        //
        // if (Mathf.Abs(vel.x) > Mathf.Abs(vel.y))
        //     vel.y = 0;
        // else
        //     vel.x = 0;
        //
        // RB.linearVelocity = vel;

        //     // Animator driving values: -1, 0, 1
        //     float moveX = Mathf.Sign(vel.x);
        //     float moveY = Mathf.Sign(vel.y);
        //
        //     animator.SetFloat("MoveX", moveX);
        //     animator.SetFloat("MoveY", moveY);
        //
        //     // Freeze animation when not moving (no idle)
        //     animator.speed = (moveX == 0 && moveY == 0) ? 0f : 1f;
        // }
    }

    private Vector2 PlayerMovement()
    {
        Vector2 vel = Vector2.zero;

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            vel.x = speed;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            vel.x = -speed;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            vel.y = speed;

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            vel.y = -speed;


        if (Mathf.Abs(vel.x) > Mathf.Abs(vel.y))
            vel.y = 0;
        else
            vel.x = 0;

        // RB.linearVelocity = vel;
        return vel;

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Guy")
        {
            isTalkingToNPC = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Deputy")
        {
            isTalkingToNPC = false;
            isTalkingToDeputy = false;
        }
    }
    


}

