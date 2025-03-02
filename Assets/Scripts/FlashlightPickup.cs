using UnityEngine;

public class FlashlightPickup : MonoBehaviour
{
    //the goal of this script is to tell the player to reveal their flashlight

    public void PickupFlashlight() {
        Destroy(gameObject);
    }
}
