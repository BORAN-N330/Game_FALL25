using System.Collections;
using UnityEngine;

public class CellOpener : MonoBehaviour
{

    Animator animator;

    //time to wake
    public float openDelaySeconds = 3f;

    void Start()
    {
        //get animator
        animator = GetComponent<Animator>();

        //set delay
        StartCoroutine(WaitTime());
    }

    //delay
    IEnumerator WaitTime() {
        yield return new WaitForSeconds(openDelaySeconds);

        //after delay, play animation
        animator.SetTrigger("isOpening");
    }
}
