using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Storefront.Instance.StartDelivery();
        Destroy(this.gameObject);
    }
}
