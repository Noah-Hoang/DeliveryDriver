using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0.0f;
    [SerializeField]
    private float steering = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        //moveSpeed = 0.0f;
        //steering = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Steer();
    }

    public void Steer()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steering * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
        //if (Input.GetKeyDown(KeyCode.W)) 
        //{
        //    moveSpeed = 0.1f;
        //}
        //else if (Input.GetKeyUp(KeyCode.W)) 
        //{
        //    moveSpeed = 0.0f;
        //}

        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    steering = 0.5f;
        //}
        //else if (Input.GetKeyUp(KeyCode.A))
        //{
        //    steering = 0.0f;
        //}

        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    moveSpeed = -0.1f;
        //}
        //else if (Input.GetKeyUp(KeyCode.S))
        //{
        //    moveSpeed = 0.0f;
        //}

        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    steering = -0.5f;
        //}
        //else if (Input.GetKeyUp(KeyCode.D))
        //{
        //    steering = 0.0f;


        //}
        //transform.Rotate(0, 0, steerAmount);
        //transform.Translate(0, moveAmount, 0);
    }
}
