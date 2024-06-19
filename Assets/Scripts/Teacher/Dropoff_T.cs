using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropoff_T : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        StoreFront_T.Instance.EndDelivery();
        gameObject.SetActive(false);
    }
}
