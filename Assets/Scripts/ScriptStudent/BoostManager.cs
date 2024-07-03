using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoostManager : MonoBehaviour
{
    public List<GameObject> boostList;
    public float remainingTime = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        boostList = GameObject.FindGameObjectsWithTag("Boost").ToList();
        DeactivateAllBoosts();
        ActivateRandomBoost();
        
    }

    // Update is called once per frame
    void Update()
    {
        Countdown();
    }

    public void ActivateRandomBoost()
    {
        int index = UnityEngine.Random.Range(0, boostList.Count);
        GameObject boostLocation = boostList[index];
        boostLocation.SetActive(true);
        remainingTime = 10.0f;
    }

    public void DeactivateAllBoosts()
    {
        for (int i = 0; i < boostList.Count; i++)
        {
            boostList[i].SetActive(false);
        }
    }

    public void Countdown()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else 
        {
            DeactivateAllBoosts();
            ActivateRandomBoost();
        }
    }
}

