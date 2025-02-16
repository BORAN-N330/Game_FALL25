using UnityEngine;

//https://www.youtube.com/watch?v=b7Yf6BFx6js

public class PlayerInteractable : MonoBehaviour
{
    public float playerReach = 3f;
    Interactable currentInteractable;

    private void Update() {
        CheckInteract();
        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null) {
            currentInteractable.Interact();
        }
    }

    void CheckInteract() {
        //raycast from screen
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if (Physics.Raycast(ray, out hit, playerReach)) {
            if (hit.collider.tag == "Interactable") {
                Interactable newInteractable = hit.collider.GetComponent<Interactable>();

                if (newInteractable.enabled) {
                    SetNewCurrentInteractable(newInteractable);
                }
                else
                {
                    DisableCurrentInteractable();
                }
            }
            else
            {
                DisableCurrentInteractable();
            }
        }
        else
        {
            DisableCurrentInteractable();
        }
    }

    void SetNewCurrentInteractable(Interactable newInteractable) {
        currentInteractable = newInteractable;
    }

    void DisableCurrentInteractable() {
        if (currentInteractable != null) {
            currentInteractable = null;
        }
    }
}
