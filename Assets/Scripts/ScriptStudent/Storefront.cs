using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Storefront : MonoBehaviour
{
    // Singleton: A singleton is a design pattern that ensures a class only has one instance and provides a global point of access to it.
    // the keyword static means that a variable or method belongs to the class, rather than instances of the class, allowing it to be accessed directly from the class level without creating an object.
    //Singleton makes a specific instance of a class "special" and allows for global acess to that class
    //Static makes a variable or method shared between all instances of the class
    //Instance example: Storefront class on multiple game objects. Each game object has its own instance(not the variable in this code) of the class
    public static Storefront Instance { get; private set; }

    [Header("General")]
    public GameObject packagePrefab;
    public int money;

    [Header("Important Locations")]
    public Transform pickupLocation;
    public Transform[] dropoffLocationsArray;
    public List<Transform> dropoffLocationsList;
    
    [Header("Time Stuff")]
    public Text timerText;
    private float remainingTime;
    public float totalTime = 10.0f;
    public bool deliveryOngoing;

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

    void Update()
    {
        if (deliveryOngoing && (remainingTime > 0))
        {
            remainingTime -= Time.deltaTime;
            UpdateTimerUI();
        }
        else if (deliveryOngoing)
        {
            money -= 5;
            CreatePackage();
            deliveryOngoing = false;
            for (int i = 0; i < dropoffLocationsList.Count; i++)
            {
                dropoffLocationsList[i].gameObject.SetActive(false);
            }
            timerText.text = "Package Delivery Failed";
        }
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
        //gets the randomly selected dropoff location and turns it on so it can run the Dropoff script
        dropoffLocationsList[index].gameObject.SetActive(true);
        //TODO: start timer
        remainingTime = totalTime;
        deliveryOngoing = true;
    }

    public void EndDelivery()
    {
        Debug.Log("Delivered Package");
        CreatePackage();
        //TODO: End timer
        deliveryOngoing = false;
        timerText.text = "Package Delivery Successful";
        //Gives money
        money = money + 10;
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

// Location of delivery
//Location of pick up
//Packages need to be specific
//Time limit per job
//Pay for job