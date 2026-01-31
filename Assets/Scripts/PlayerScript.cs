using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody2D RB;
    public float speed = 5f;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // HORIZONTAL + VERTICAL MOVEMENT works both WASD + Arrows
        Vector2 vel = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            vel.x = speed;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            vel.x = -speed;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            vel.y = speed;

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            vel.y = -speed;

        RB.linearVelocity = vel;
    }
    
    
}

