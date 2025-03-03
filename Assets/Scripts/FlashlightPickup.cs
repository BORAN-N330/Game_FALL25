using UnityEngine;

public class FlashlightPickup : MonoBehaviour
{
    //the goal of this script is to tell the player to reveal their flashlight

    public void PickupFlashlight() {
        GameObject.Find("GameManager").GetComponent<GameManager>().SetFlashlightActive();
        Destroy(gameObject);
    }
}
