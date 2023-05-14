using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public abstract class Heroes : MonoBehaviour
{
private Rigidbody2D rb;

    public static float speed;

    public static float health;

    public static int strength;

    public static string hero;

    public GameObject gameManager;

    public GameObject weapon;

    public static bool reload = false;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        Hero();
    }

    void Update()
    {
        //WASD controller. Adds force to corresponding vector with the speed of the hero
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(speed * Vector2.up);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(speed * Vector2.down);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(speed * Vector2.left);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(speed * Vector2.right);
        }

        rb.velocity *= 0.09f; //will slow down the velocity so it doesn't go on forever

        if (Input.GetMouseButtonDown(0) && reload == false) //when pressing the left mouse button and if reload is false
        {
            reload = true; //will set reload to true, not allowing this to be done again
            Attack(); //will call the attack function
        }

    }
    
    protected abstract void Hero();

    private void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.gameObject.tag == "Door") //if it collides with the door
        {
            Debug.Log("Hit level change");
            gameManager.GetComponent<ASCIILevelLoader>().LevelChange(); //calls the ASCII level loader and changes the level
            
        }
    }

    public void Attack()
    {
        GameObject newWeapon = Instantiate(weapon); //instantiates a new game object

        
        newWeapon.transform.position = gameObject.transform.position; //instantiates it on the location of the player
        newWeapon.transform.rotation = new Quaternion(Input.mousePosition.x, Input.mousePosition.y, 0, 0).normalized; 
        //rotation will change depending on the mouse position

    }
}
