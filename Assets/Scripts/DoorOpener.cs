using System.Data.Common;
using UnityEditor;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    Animator animator;

    GameManager gameManager;

    public int id = 0;
    bool isOpen = false;

    private void Start() {
        animator = GetComponent<Animator>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
