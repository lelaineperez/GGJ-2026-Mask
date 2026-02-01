using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //numbers
    public float speed = 5f;


    public Rigidbody2D rigidBody;
    public Camera cam;
    public GameObject DialogueCanvas;

    //bools
    private bool isTalkingToGuy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DialogueCanvas.SetActive(false);
        isTalkingToGuy = false;
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.linearVelocity = PlayerMovement();

        cam.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10);
    }


    private Vector2 PlayerMovement()
    {
        Vector2 vel = rigidBody.linearVelocity;

        if (Input.GetKey(KeyCode.W))
        {
            vel.y = speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            vel.y = -speed;
        }
        else
        {
            vel.y = 0;
        }


        if (Input.GetKey(KeyCode.D))
        {
            vel.x = speed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            vel.x = -speed;
        }
        else
        {
            vel.x = 0;
        }

        return vel;

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Guy_Trigger")
        {
            isTalkingToGuy = true;
        }
    }

    private void DialogueUI()
    {
        if (isTalkingToGuy == true)
        {
            DialogueCanvas.SetActive(true);
        }
    }


}
