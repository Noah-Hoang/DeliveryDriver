using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoadDetector : MonoBehaviour
{
    public Driver driver;
    public float maxMoveSpeed;
    public bool onRoad;

    // Start is called before the first frame update
    void Start()
    {
        maxMoveSpeed = driver.moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    // if on road, 
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Road") && !driver.boostActivated)
        {
            driver.moveSpeed = maxMoveSpeed;           
        }       
    }

    // if off road,
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Road") && !driver.boostActivated)
        {
            driver.moveSpeed *= 0.75f;
        }

        if (collision.gameObject.tag.Equals("Road"))
        {
            onRoad = false;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Road"))
        {
            onRoad = true;
        }
    }
}
