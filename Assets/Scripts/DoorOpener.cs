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

    public string doorText = "A";
    public int id = 0;
    
    bool isOpen = false;

    private void Start() {
        animator = GetComponent<Animator>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        text = GetComponentInChildren<TMP_Text>();
        text.text = doorText;
    }

    public void OpenDoor() {
        //check with gamemanager
        if (gameManager.hasKeyCard(id)) {
            if (isOpen == false) {
                animator.SetTrigger("isOpen");
                isOpen = true;
            }
        }
    }
}
