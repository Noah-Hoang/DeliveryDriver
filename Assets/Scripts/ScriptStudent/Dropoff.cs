using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropoff : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Storefront.Instance.EndDelivery();
        gameObject.SetActive(false);
    }
}
