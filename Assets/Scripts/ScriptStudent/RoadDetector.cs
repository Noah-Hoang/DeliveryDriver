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
        HandleSpeed();
    }
    
    public void OnTriggerExit2D(Collider2D collision)
    {       
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

    public void HandleSpeed()
    {
        if (onRoad && !driver.boostActivated)
        {
            driver.moveSpeed = maxMoveSpeed;
        }
        else if (onRoad && driver.boostActivated)
        {
            driver.moveSpeed = maxMoveSpeed * 2;
        }
        else if (!onRoad && !driver.boostActivated)
        {
            driver.moveSpeed = maxMoveSpeed * 0.75f;
        }
    }
}
