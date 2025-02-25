using UnityEngine;

public class Desk : MonoBehaviour
{
    Animator animator;
    public GameObject objectInDrawer;
    public bool isLocked;

    void Start()
    {
        isLocked = false;
        animator = GetComponent<Animator>();
    }

    public void ToggleDrawer() {
        if (!isLocked) {
            animator.SetTrigger("openDrawer");
        }
    }

    public void UnlockDesk() {
        isLocked = false;
    }
}
