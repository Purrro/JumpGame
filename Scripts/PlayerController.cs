using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] LineRenderer lr;
    [SerializeField] GameObject panel;

    [SerializeField] private GameObject touchToMoveText;

    private Transform localTrans;
    private Touch touch;
    UIScript uis;

    private bool isOnFinish = false;

    void Start()
    {
        touchToMoveText.SetActive(true);

        rb = FindObjectOfType<Rigidbody>();
        localTrans = GetComponent<Transform>();
        uis = FindObjectOfType<UIScript>();
    }
   
    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down),out hit) && !isOnFinish)
        {
            lr.positionCount = 2;
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, new Vector3(transform.position.x, hit.transform.position.y, transform.position.z));
            if(hit.transform.tag == "Platforms" || hit.transform.tag == "BluePlatform" || hit.transform.tag == "Finish")
            {
                lr.material.color = Color.green;
            }
            else lr.material.color = Color.red;
        }

        //if (Input.GetMouseButton(0))
        //{
        //    localTrans.position += localTrans.forward * 10 * Time.deltaTime;
        //    float rotX = Input.GetAxis("Mouse X") * 10;
        //    transform.eulerAngles += new Vector3(0f, rotX, 0f);
        //}

        if (Input.touchCount > 0 && !isOnFinish)
        {
            localTrans.position += localTrans.forward * 8 * Time.deltaTime;

            touchToMoveText.SetActive(false);
            
            touch = Input.GetTouch(0);
            
            if (touch.phase == TouchPhase.Moved)
            {
                transform.eulerAngles += new Vector3(0f, touch.deltaPosition.x * 0.3f, 0f);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Platforms")
        {
            rb.AddForce(Vector3.up * 10f, ForceMode.Impulse);
            
        }

        if (collision.transform.tag == "BluePlatform")
        {
            rb.AddForce(Vector3.up * 25f, ForceMode.Impulse);

        }

        if (collision.transform.tag == "Finish")
        {
            uis.SetNum(0);
            isOnFinish = true;
            panel.SetActive(true);
        }

        if(collision.transform.tag == "Respawn")
        {
            transform.position = new Vector3(-30f, 33f, 21f);
            touchToMoveText.SetActive(true);
        }
        
    }
}
