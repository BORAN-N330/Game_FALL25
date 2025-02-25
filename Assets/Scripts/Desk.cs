using System;
using System.Collections;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class Desk : MonoBehaviour
{
    Animator animator;

    [Header("Keycard")]
    public string keyCardText = "";
    public int keyCardCode = 0;
    public GameObject keyCardInDrawer;
    public GameObject spawnPoint;

    [Header("Padlock")]
    public GameObject padlock;
    public GameObject padlockUI;
    public int[] code = {0,0,0};
    public bool isLocked = true;
    bool isOpen;

    public static int matchPair = 0;
    [Header("Magic Stuff (Dont mess with)")]
    public int matchPairCurrent = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        matchPairCurrent = matchPair;
        Debug.Log("MathDeskPair: " + matchPairCurrent.ToString());
        matchPair += 1;
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
            GameObject canvas = GameObject.Find("Canvas");
            
            //add a new UI
            GameObject tempPadlockUI = Instantiate(padlockUI);

            tempPadlockUI.GetComponent<PadlockUI>().code = code;
            tempPadlockUI.GetComponent<PadlockUI>().matchPair = matchPairCurrent;

            tempPadlockUI.transform.SetParent(canvas.transform);
            tempPadlockUI.GetComponent<RectTransform>().anchoredPosition = Vector2.zero; //center it

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            //RemoveLock() --> in update;
        }
    }

    public void RemoveLock() {
        isLocked = false;
        padlock.GetComponent<Rigidbody>().isKinematic = false;

        //done in exit
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
