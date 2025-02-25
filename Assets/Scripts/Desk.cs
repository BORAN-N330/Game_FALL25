using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Desk : MonoBehaviour
{
    Animator animator;

    public string keyCardText = "";
    public int keyCardCode = 0;
    public GameObject keyCardInDrawer;

    public GameObject spawnPoint;
    public GameObject padlock;
    public bool isLocked = true;
    bool isOpen;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ToggleDrawer() {
        if (!isLocked && !isOpen) {
            isOpen = true;
            animator.SetTrigger("openDrawer");

            //spawn in gameobject
            if (keyCardInDrawer != null) {
                StartCoroutine(Timer());
            }
        } else {
            //show LOCK UI
            RemoveLock();
        }
    }

    private void RemoveLock() {
        isLocked = false;
        padlock.GetComponent<Rigidbody>().isKinematic = false;
    }

    public void UnlockDesk() {
        isLocked = false;
    }

    //delay
    IEnumerator Timer() {
        yield return new WaitForSeconds(1);
        GameObject keycard = Instantiate(keyCardInDrawer, spawnPoint.transform.position, spawnPoint.transform.rotation);
        keycard.GetComponent<KeyCard>().cardText = keyCardText;
        keycard.GetComponent<KeyCard>().cardID = keyCardCode;
    }
}
