using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Rigidbody Rigidbody;
    public float speed = 4;

    void Start()
    {
        Rigidbody.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Terrain")
        {
            Destroy(gameObject);
        }
    }
}
