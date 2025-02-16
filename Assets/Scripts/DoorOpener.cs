using UnityEditor;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public Animator animator;
    bool isOpen = false;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E) && isOpen == false) {
            animator.SetTrigger("isOpen");
            isOpen = true;
        }
    }
}
