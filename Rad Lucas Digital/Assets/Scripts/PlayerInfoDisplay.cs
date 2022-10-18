using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoDisplay : Player
{
    public Text scoreText;
    public Text healthText;
    public Text strengthText;
    public Text VideoGameDisk;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
        healthText.text = "Health: " + health;
        strengthText.text = "Strength: " + strength;
        VideoGameDisk.text = "Video Game Disks Aquired: " + VideoGameDiskCount;
        if (health <= 0)
        {
            health = health + 5;
        }
    }
}
