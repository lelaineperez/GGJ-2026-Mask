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
    private bool canMove;
    private bool dialogueActive;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DialogueCanvas.SetActive(false);
        isTalkingToGuy = false;
        canMove = true;
        dialogueActive = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            rigidBody.linearVelocity = PlayerMovement();
        }
        

        cam.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10);

        DialogueUI();

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
        if (collider.gameObject.name == "GuyTrigger")
        {
            isTalkingToGuy = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider){
        if (collider.gameObject.name == "GuyTrigger")
        {
            isTalkingToGuy = false;
        }
    }

    private void DialogueUI() //fx that handles dialogue ui 
    {
        if (isTalkingToGuy == true && Input.GetKeyDown(KeyCode.Space)) //if you are within guy's collider & presses space
        {
            DialogueCanvas.SetActive(true); //dialogue ui will pop up
            canMove = false;
            dialogueActive = true;
            
        }
        if (dialogueActive == true && Input.GetMouseButtonDown(0)) // if you are within guy's collider & press left mouse button
        {
            DialogueCanvas.SetActive(false); //dialogue will disappear
            canMove = true; //you can move again
            dialogueActive = false;
        }
    }


}
