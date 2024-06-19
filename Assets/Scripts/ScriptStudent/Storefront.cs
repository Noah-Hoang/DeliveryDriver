using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storefront : MonoBehaviour
{
    public static Storefront Instance { get; private set; }
    public Transform pickupLocation;
    public Transform[] dropoffLocationsArray;
    public List<Transform> dropoffLocationsList;
    public GameObject packagePrefab;
    

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
        //dropoffLocationsArray = new Transform[4];
        //dropoffLocationsList = new List<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreatePackage()
    {
        Debug.Log("Creating Package");
        Instantiate(packagePrefab, pickupLocation.position, pickupLocation.rotation);
    }

    public void StartDelivery()
    {
        Debug.Log("Delivering Package");
        int index = Random.Range(0, dropoffLocationsArray.Length);
        dropoffLocationsList[index].gameObject.SetActive(true);
        //start timer
    }

    public void EndDelivery()
    {
        Debug.Log("Delivered Package");
        CreatePackage();
        //End timer
        //Give money
    }
}

// Location of delivery
//Location of pick up
//Packages need to be specific
//Time limit per job
//Pay for job