using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDeployer : MonoBehaviour
{
    public GameObject Moving_PlatformPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Deploy", 0f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Deploy()
    {
        Instantiate(Moving_PlatformPrefab, GetComponent<Transform>().position, GetComponent<Transform>().rotation);
    }
}
