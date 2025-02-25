using System.Collections;
using UnityEngine;

public class Desk : MonoBehaviour
{
    Animator animator;
    public GameObject objectInDrawer;
    public GameObject spawnPoint;
    public bool isLocked;
    bool isOpen;

    void Start()
    {
        isLocked = false;
        animator = GetComponent<Animator>();
    }

    public void ToggleDrawer() {
        if (!isLocked && !isOpen) {
            isOpen = true;
            animator.SetTrigger("openDrawer");

            //spawn in gameobject
            if (objectInDrawer != null) {
                StartCoroutine(Timer());
            }
        }
    }

    public void UnlockDesk() {
        isLocked = false;
    }

    //delay
    IEnumerator Timer() {
        yield return new WaitForSeconds(1);
        Instantiate(objectInDrawer, spawnPoint.transform.position, Quaternion.identity);
    }
}
