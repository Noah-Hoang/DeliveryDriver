using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropoff : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Storefront.Instance.EndDelivery();
        gameObject.SetActive(false);
    }
}
