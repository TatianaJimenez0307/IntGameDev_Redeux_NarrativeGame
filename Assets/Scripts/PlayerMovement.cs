using System.Collections;
using System.Collections.Generic;
using UnityEngine;


///CSharp class name depending what you named it in unity
public class PlayerMovement : MonoBehaviour
{

    //VARIABLES GO HERE

    Animator myAnim; //setting up animations

    //Tuning Game Vars
    public float speed = 2f;

    bool haveKey = false; // collecting wands, it's a boolean variable

    public GameObject NPC1Text; //setting NPC1text var

    public GameObject NPC2Text; //setting NPC2text var

    public GameObject Player; //Setting uo player var

    // Vector3 is for x, y, z coordinates
    Vector3 thisPos;



    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator> (); 
    }

    // Update is called once per frame
    void Update()
    {

        //storing current camera position as new Vector3 variable
        Vector3 newPos = transform.position;

        //camera follows player 
        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, transform.position.z);


        //WASD MOVEMENT
        if (Input.GetKey(KeyCode.W))
        {
            //change y position by 1 AKA MOVE UP
            //delta time is the time in seconds btw the last and current frame. This standardizes movement, always use it w/ speed
            newPos.y += speed * Time.deltaTime;
            myAnim.SetBool("isWalkingHorizontally", false); //stops horizontal animation
            myAnim.SetBool("isWalkingVertically", true); //triggers animation 
        }
        if (Input.GetKey(KeyCode.S))
        {
            //change x position by -1 AKA MOVE DOWN 
            newPos.y -= speed * Time.deltaTime;

            myAnim.SetBool("isWalkingVertically", true); //triggers animation
            myAnim.SetBool("isWalkingHorizontally", false); //stops horizontal animation
        } 
        if (Input.GetKey(KeyCode.A))
        {
            //change y position by -1 AKA MOVE LEFT 
            newPos.x -= speed * Time.deltaTime;
            myAnim.SetBool("isWalkingHorizontally", true); //triggers animation
            myAnim.SetBool("isWalkingVertically", false); //triggers animation
        }
        if (Input.GetKey(KeyCode.D))
        {
            //change x position by 1 AKA MOVE RIGHT 
            newPos.x += speed * Time.deltaTime;
            myAnim.SetBool("isWalkingHorizontally", true); //triggers animation
            myAnim.SetBool("isWalkingVertically", false); //triggers animation
        }

        //set the players position to its new position, so its always updating
        transform.position = newPos;

    }

    //detects if we're colliding with another object. 

   

    void OnTriggerStay2D(Collider2D other) 
    {

        //interacting with NPCS

        if (Input.GetKey(KeyCode.Space) && other.gameObject.name == "NPC1") //if we overlap with NPC1, and press SPACE, NPC1 textbox shows up
        {
            NPC1Text.SetActive(true);  //textbox 1 appears
            Debug.Log("hi");
        }
        if (Input.GetKey(KeyCode.Space) && other.gameObject.name == "NPC2") //if we overlap with NPC1, and press SPACE, NPC1 textbox shows up
        {
            NPC2Text.SetActive(true); //textbox 2 appears

        }
    }

    //making NPC textboxes dissapear

    private void OnTriggerExit2D(Collider2D other) //if we stop overlapping with NPCs
    {
        if (other.gameObject.name == "NPC1")
            
        {
            //hides textbox
            NPC1Text.SetActive(false);
            
        }

        if(other.gameObject.name == "NPC2")
        {
            //hides textbox
            NPC2Text.SetActive(false);
        }
    }

    //touching door 
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (haveKey == true && other.gameObject.name == "Door") //if we have key and are colliding with door, door destroys
        {

            Destroy(other.gameObject); //door disapears
        }
    }

    //detects if we're overlaping with another object
    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log(other.gameObject.name);

        if (other.gameObject.name == "Key") //if we overlap with the wand, you collect it and the wand disapears
        {
            haveKey = true; //collect key
            Destroy(other.gameObject); //key disapears
        }

       
    
      

        

        

    }
}

