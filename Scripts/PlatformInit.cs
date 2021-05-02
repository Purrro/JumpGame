using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformInit : MonoBehaviour
{
    [SerializeField] GameObject orange, purple, red, yellow;

    GameObject[] platformColor = new GameObject[4];
    
    void Start()
    {
        platformColor[0] = orange;
        platformColor[1] = purple;
        platformColor[2] = red;
        platformColor[3] = yellow;

        int rnd = Random.Range(0, 4);
        Instantiate(platformColor[rnd], transform.position + new Vector3(0f, 0.84f, 0f), transform.rotation, gameObject.transform);
    }

}
