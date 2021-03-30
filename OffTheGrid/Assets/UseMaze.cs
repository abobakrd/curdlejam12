using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseMaze : MonoBehaviour
{
    BoxCollider2D coll;
    // var maze = transform ..
    
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" /* && !maze.isSolved #1#)
        {
            Camera.main.gameObject.SetActive(false);
            // maze.gameObject.setActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Camera.main.gameObject.SetActive(true);
            // maze.gameObject.setActive(false);
        }
    }*/
}
