using System.Data.Common;
using UnityEditor;
using UnityEngine;
using TMPro;

public class DoorOpener : MonoBehaviour
{
    Animator animator;

    GameManager gameManager;

    //text on door
    TMP_Text text;

    [Header("Door Properties")]
    public string doorText = "A";
    public int id = 0;
    public bool requiresKey = true;
    
    bool isOpen = false;

    private void Start() {

        text = GetComponentInChildren<TMP_Text>();
        animator = GetComponent<Animator>();

        if (requiresKey == true) {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

            text.text = doorText;
        } else {
            text.text = "";
        }
    }

    public void OpenDoor() {
        //check with gamemanager
        if (requiresKey) {
            if (gameManager.hasKeyCard(id)) {
                if (isOpen == false) {
                    animator.SetTrigger("isOpen");
                    isOpen = true;
                }
            }
        } else {
            //does not require key
            if(isOpen == false) {
                animator.SetTrigger("isOpen");
                isOpen = true;

            } else if (isOpen == true) {
                //close the door
                animator.SetTrigger("isClosed");
                isOpen = false;
            }
        }
    }
}
