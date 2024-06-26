using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionIndicator : MonoBehaviour
{
    public Transform player; // Reference to the player's transform (car)
    public Transform targetHouse; // Reference to the target house's transform
    public Transform arrow; // Reference to the arrow UI element
    public GameObject image;

    public void Start()
    {
        Storefront.Instance.onPackagePickedUp.AddListener(PackagePickedUp);
        Storefront.Instance.onPackageDeliverySuccessful.AddListener(PackageDeliverySuccessful);
        Storefront.Instance.onPackageDeliveryUnsuccessful.AddListener(PackageDeliveryUnsuccessful);
    }

    public void OnDisable()
    {
        Storefront.Instance.onPackagePickedUp.RemoveListener(PackagePickedUp);
        Storefront.Instance.onPackageDeliverySuccessful.RemoveListener(PackageDeliverySuccessful);
        Storefront.Instance.onPackageDeliveryUnsuccessful.RemoveListener(PackageDeliveryUnsuccessful);
    }

    public void Update()
    {
        if (targetHouse != null)
        {
            // Calculate the direction from the player to the target house
            Vector2 direction = (targetHouse.position - player.position).normalized;

            // Calculate the angle between the player's forward direction and the target direction
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Rotate the arrow to point towards the target direction
            arrow.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }       
    }

    public void PackagePickedUp(Transform dropoffPoint)
    {
        targetHouse = dropoffPoint;
        image.SetActive(true);
    }

    public void PackageDeliverySuccessful()
    {
        targetHouse = null;
        image.SetActive(false);

    }

    public void PackageDeliveryUnsuccessful()
    {
        targetHouse = null;
        image.SetActive(false);
    }

}
