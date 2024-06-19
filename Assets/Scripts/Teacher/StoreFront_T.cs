using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreFront_T : MonoBehaviour
{
    public static StoreFront_T Instance { get; private set; }

    public GameObject packagePrefab;
    public Transform pickupLocation;

    public Transform[] dropOffLocationsArray;
    public List<Transform> dropOffLocationsList;

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        CreatePackage();
        //dropOffLocationsArray = new Transform[4];
        //dropOffLocationsList = new List<Transform>();
    }

    public void CreatePackage()
    {
        Debug.Log("Creaing package");

        Instantiate(packagePrefab, pickupLocation.position, pickupLocation.rotation);
    }

    public void StartDelivery()
    {
        Debug.Log("Start delivery");

        int index  = Random.Range(0, dropOffLocationsArray.Length);
        dropOffLocationsArray[index].gameObject.SetActive(true);
        //Start timer
    }

    public void EndDelivery()
    {
        Debug.Log("End delivery");

        //End Timer
        //Give money

        CreatePackage();
    }
}
//Go to the 
//location of delivery/pickup
//Packages need to be specific
//Time limit per job
//Pay per job