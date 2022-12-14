using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRestartButton : Player
{
    //Set Start position
    private Vector3 startPos;




    // Start is called before the first frame update
    void Start()
    {
        startPos = GameObject.FindGameObjectWithTag("Player").transform.position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            Respawn();
        }

        if (health <= 0)
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        transform.position = startPos;
        health = 5;
    }
}
