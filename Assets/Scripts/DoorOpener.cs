using System.Data.Common;
using UnityEditor;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    Animator animator;
    public int id = 0;
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
