using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package_T : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        StoreFront_T.Instance.StartDelivery();

        Destroy(this.gameObject);
    }
}
