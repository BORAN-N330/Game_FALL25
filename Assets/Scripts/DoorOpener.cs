using UnityEditor;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    Animator animator;
    bool isOpen = false;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            OpenDoor();
        }
    }

    public void OpenDoor() {
        if (isOpen == false) {
            animator.SetTrigger("isOpen");
            isOpen = true;
        }
    }
}
