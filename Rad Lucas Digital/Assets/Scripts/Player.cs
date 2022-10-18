using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Orb Counts For Each Color
    private int orb_green_count = 0;
    private int orb_blue_count = 0;
    private int orb_red_count = 0;
    private int orb_gold_count = 0;
    private int orb_cyan_count = 0;
    private int orb_purple_count = 0;

    public int game_disk_count = 0;
    public int score = 0;
    public int health = 5;
    public int strength = 5;


    //Add score of +5 if player opens a door

    //COLLIDER
    private void OnTriggerEnter(Collider other)
    {   //Gold orb
        if(other.gameObject.tag == "Orb Gold")
        {
            print("Gold Key, used to open doors");
            other.gameObject.SetActive(false);
            orb_gold_count++;
            score++;
            print("Gold key count is " + orb_gold_count);
        }
        //Purple orb
        if (other.gameObject.tag == "Orb Purple")
        {
            print("Purple Key, used to open doors");
            other.gameObject.SetActive(false);
            orb_purple_count++;
            score++;
            print("purple key count is " + orb_purple_count);
        }
        //Cyan orb
        if (other.gameObject.tag == "Orb Cyan")
        {
            print("Cyan Key, used to open doors");
            other.gameObject.SetActive(false);
            orb_cyan_count++;
            score++;
            print("Cyan key count is " + orb_cyan_count);
        }

        //GameDisk Collision: Gain 50 points
        if(other.gameObject.tag == "VideoGameDisk")
        {
            print("Game Disk found! Ready for next level.");
            other.gameObject.SetActive(false);
            game_disk_count++;
            score = score + 50;
        }



        //Green Orb(key)
        if (other.gameObject.tag == "Orb Green")
        {
            print("Green key(orb), used to open green doors");
            other.gameObject.SetActive(false);
            orb_green_count++;
            score++;
            print("Green key count is "+ orb_green_count);
        }
        //Green Door multi-locks
        if (other.gameObject.tag == "Door Green")
        {
            //print to let player know what is required
            print("Green Door, requires 3 green 1 gold, and 1 cyan keys(orb) to open");
            //check if players meets requirement
            if(orb_green_count >= other.gameObject.GetComponent<Door>().number_of_green_locks)
            {
                if(orb_gold_count >= other.gameObject.GetComponent<Door>().number_of_gold_locks)
                {
                    if(orb_cyan_count >= other.gameObject.GetComponent<Door>().number_of_cyan_locks)
                    {
                        orb_green_count -= other.gameObject.GetComponent<Door>().number_of_green_locks;
                        orb_gold_count -= other.gameObject.GetComponent<Door>().number_of_gold_locks;
                        orb_cyan_count -= other.gameObject.GetComponent<Door>().number_of_cyan_locks;
                        other.gameObject.SetActive(false);
                        print("Green door opened");
                        score = score + 10;

                    }
                    

                }
                
            }
            //if requirment not met, tell them what they still need
            else
            {
                print("Require "+ other.gameObject.GetComponent<Door>().number_of_green_locks + " green key to open this green door, "+ orb_green_count  +" green keys have been picked up");
            }
        }







        //Blue Orb
        if (other.gameObject.tag == "Orb Blue")
        {
            print("Blue key(orb), used to open blue doors");
            other.gameObject.SetActive(false);
            orb_blue_count++;
            score++;
            print("Blue key count is " + orb_blue_count);
        }
        //Blue Door
        if (other.gameObject.tag == "Door Blue")
        {
            print("Blue Door, requires 2 blue keys(orb) to open");
            if (orb_blue_count >= other.gameObject.GetComponent<Door>().number_of_locks)
            {
                if (orb_red_count >= other.gameObject.GetComponent<Door>().number_of_red_locks)
                {
                    if (orb_purple_count >= other.gameObject.GetComponent<Door>().number_of_purple_locks)
                    {
                        orb_blue_count -= other.gameObject.GetComponent<Door>().number_of_locks;
                        other.gameObject.SetActive(false);
                        print("Blue door opened");
                        score = score + 10;
                    }
                        
                }
                    
            }
            else
            {
                print("Require " + other.gameObject.GetComponent<Door>().number_of_locks + " blue key to open this blue door, " + orb_blue_count + " blue keys have been picked up");
            }
        }








        //Red Orb
        if (other.gameObject.tag == "Orb Red")
        {
            print("Red key(orb), used to open red doors");
            other.gameObject.SetActive(false);
            orb_red_count++;
            score++;
            print("Red key count is " + orb_red_count);
        }
        //Red Door
        if (other.gameObject.tag == "Door Red")
        {
            print("Red Door, requires 1 red 1 gold keys(orb) to open");
            if (orb_red_count >= other.gameObject.GetComponent<Door>().number_of_red_locks)
            {
                if (orb_gold_count >= other.gameObject.GetComponent<Door>().number_of_gold_locks)
                {
                    orb_red_count -= other.gameObject.GetComponent<Door>().number_of_red_locks;
                    orb_gold_count -= other.gameObject.GetComponent<Door>().number_of_gold_locks;
                    other.gameObject.SetActive(false);
                    print("Red door opened");
                    score = score + 10;
                }
                    
            }
            else
            {
                print("Require " + other.gameObject.GetComponent<Door>().number_of_red_locks + " red key and "+other.gameObject.GetComponent<Door>().number_of_gold_locks +" gold key "+"to open this red door, " + orb_red_count + " red keys have been picked up, "+orb_gold_count+" gold key have been picked up." );
            }
        }

        if(other.gameObject.tag == "EnemyBullet")
        {
            other.gameObject.SetActive(false);
            health--;
        }
    
    }
}  // end of Player Script