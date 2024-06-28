using OpenCover.Framework.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

//Class types in variables are set to null by default
//Bool is set to false, int is set  to 0 and float is set to 0.0 by default

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
    public GameObject houseHolder;
    public List<Transform> dropoffList;
    
    [Header("Time Stuff")]
    public Text timerText;
    private float remainingTime;
    public float totalTime = 10.0f;
    public bool deliveryOngoing;

    //Event is like when something special happens
    //The transform inside the <> is to tell everything that is listening to the event where the dropoff point is and that the package was also picked up
    //The different events listed are to show when the pacakge is picked up and whether it was delivererd successfully or not
    [Header("Events")]
    public UnityEvent<Transform> onPackagePickedUp;
    public UnityEvent onPackageDeliverySuccessful;
    public UnityEvent onPackageDeliveryUnsuccessful;

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
        // houseHolder is referring to the houseHolder variable that was set at the top of the script.
        // GetComponentsInChildren gets the Dropoff component attached to the children of the GameObject that houseHolder refers to.
        // The <Dropoff> means that the script is specifically looking for the Dropoff class attached to the children of houseHolder.
        // The parameter 'true' indicates that the method should include inactive children in the search.
        // The method returns an array of Dropoff components.
        // The Select method is then used to change the return type from a list of Dropoff classes to a list of transforms of the Dropoff classes
        // Finally, the ToList() method converts the IEnumerable<Transform> into a List<Transform>, which is assigned to the dropoffList variable
        dropoffList = houseHolder.GetComponentsInChildren<Dropoff>(true).Select(dropOff => dropOff.transform).ToList();
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
            for (int i = 0; i < dropoffList.Count; i++)
            {
                dropoffList[i].gameObject.SetActive(false);
            }
            timerText.text = "Package Delivery Failed";

            onPackageDeliveryUnsuccessful.Invoke();
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
        int index = UnityEngine.Random.Range(0, dropoffList.Count);
        //gets the randomly selected dropoff location and turns it on so it can run the Dropoff script
        Transform dropoffLocation = dropoffList[index];
        dropoffLocation.gameObject.SetActive(true);
        //TODO: start timer
        remainingTime = totalTime;
        deliveryOngoing = true;

        onPackagePickedUp.Invoke(dropoffLocation);
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

        onPackageDeliverySuccessful.Invoke();        
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