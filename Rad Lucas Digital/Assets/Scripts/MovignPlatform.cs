using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovignPlatform : MonoBehaviour
{
    public GameObject Moving_PlatformPrefab;
    public Rigidbody Rigidbody;
    public float speed = 8;

    void Start()
    {
        Rigidbody.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody.velocity = transform.forward * speed;
    }
    // Don't want this part for now. Decide after playtest tmr
    /**private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Terrain")
        {
            Destroy(gameObject);
        }
    }**/
}
