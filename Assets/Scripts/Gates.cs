using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates : MonoBehaviour
{
    private Collider2D myCollider;

    [SerializeField]
    Transform player;
    [SerializeField]
    Movement movement;

    //public int hierachyCount;
    void Start()
    {

        //Taylor added in something to save your asses.
        //This should be able to work when disabling your movement 
        player = this.transform.parent.parent.parent.Find("Player").transform;
        movement = player.GetComponent<Movement>();
        movement.enabled = false;



        // Get the collider component of this gate
        myCollider = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //This  function is called when a trigger collider enters the gate's trigger collider.
        // Check if the other collider is also a gate

        //Your trigger scripts work thanks to me (Taylor). You owe me a chocolate.
        Debug.Log("triggered something");
        if (other.CompareTag("Gate"))
        {
            // Disable the collider of both gates
            myCollider.enabled = false;
            other.GetComponent<Collider2D>().enabled = false;
            movement.enabled = true;
            Debug.Log("Gate works");

            //After you move into the next block, I think (from your movement script) you should disable your movement again, unless gates meet up.
        }
    }
}
