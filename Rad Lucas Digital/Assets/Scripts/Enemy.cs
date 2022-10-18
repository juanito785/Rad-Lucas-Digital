using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public Quaternion Rotate;
    public Transform EnemyFirePoint;
    public GameObject EnemyBulletPrefab;
    //make enemy drop keys in future
  //public GameObject KeyPrefab;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookVector = player.transform.position - transform.position;
        lookVector.y = player.transform.position.y;
        Rotate = Quaternion.LookRotation(lookVector);
        transform.rotation = Quaternion.Slerp(transform.rotation, Rotate, 1);

        if(Input.GetButtonDown("Fire1"))
        {
            shoot();
        }

    }

    public void shoot()
    {
        Instantiate(EnemyBulletPrefab, EnemyFirePoint.position, EnemyFirePoint.rotation);
    }
}
