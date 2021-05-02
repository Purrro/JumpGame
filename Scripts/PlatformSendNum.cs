using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSendNum : MonoBehaviour
{
    private TextMesh platformNum;
    UIScript uis;

   void Start()
    {
        platformNum = transform.parent.GetComponentInChildren<TextMesh>();
        uis = FindObjectOfType<UIScript>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            uis.SetNum(int.Parse(platformNum.text));
        }
    }
}
