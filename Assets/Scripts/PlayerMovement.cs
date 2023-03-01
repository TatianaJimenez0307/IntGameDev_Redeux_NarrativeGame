using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CSharp class name depending what you named it in unity
public class PlayerMovement : MonoBehaviour
{

    //VARIABLES GO HERE


    //Tuning Game Vars
    public float speed = 2f;

    bool haveKey = false; // collecting wands, it's a boolean variable

    public GameObject NPC1Text; //setting NPC1text var

    // Vector3 is for x, y, z coordinates
    Vector3 thisPos;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //storing current camera position as new Vector3 variable
        Vector3 newPos = transform.position;

        //If Statements for ArrowKeys camera movement 
        if (Input.GetKey(KeyCode.W))
        {
            //change y position by 1 AKA MOVE UP
            //delta time is the time in seconds btw the last and current frame. This standardizes movement, always use it w/ speed
            newPos.y += speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //change x position by -1 AKA MOVE LEFT 
            newPos.y -= speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            //change y position by -1 AKA MOVE DOWN 
            newPos.x -= speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            //change x position by 1 AKA MOVE RIGHT 
            newPos.x += speed * Time.deltaTime;
        }

        //set the players position to its new position, so its always updating
        transform.position = newPos;

    }

    //detects if we're colliding with another object. 

    void OnCollisionEnter2D(Collision2D other) //void means empty. This function doesn't return a value
    {
        // Debug.Log(other.gameObject.name);

    }

    //detects if we're overlaping with another object
    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log(other.gameObject.name);

        if (other.gameObject.name == "Key") //if we overlap with the wand, you collect it and the wand disapears
        {
            haveKey = true; //collect wand
            Destroy(other.gameObject); //wand disapears
        }

        if (haveKey && other.gameObject.name == "NPC1") //if we overlap with chicken, our player dies
        {
            Destroy(gameObject); //player disapears 
        }
        else if (!haveKey && other.gameObject.name == "NPC1") //if player doesn't have wand, chicken says something
        {
            NPC1Text.SetActive(true);

        }

    }
}

