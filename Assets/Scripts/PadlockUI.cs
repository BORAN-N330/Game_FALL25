using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.AI;
using System.Xml;
using System.Text.RegularExpressions;

public class PadlockUI : MonoBehaviour
{

    public int[] code = {4, 4, 4};
    int[] currentCode = {};

    public TMP_Text[] digits;

    //for checking
    public bool isCorrect;

    [Header("Don't Touch This")]
    public int matchPair = 0;

    void Start()
    {
        Debug.Log("MatchPair: " + matchPair.ToString());
        currentCode = new int[] {0,0,0};
        SetCurrentCodes();
    }

    private void SetCurrentCodes() {
        for (int i = 0; i < currentCode.Length; i++) {
            digits[i].text = currentCode[i].ToString();
        }
    }

    public void AddCode(int digitNum) {
        digitNum -= 1;
        //starts counting at 0

        currentCode[digitNum] += 1;
        if (currentCode[digitNum] >= 10) {
            currentCode[digitNum] = 0;
        }

        SetCurrentCodes();
    }

    public void SubCode(int digitNum) {
        digitNum -= 1;
        //starts counting at 0

        currentCode[digitNum] -= 1;
        if(currentCode[digitNum] < 0) {
            currentCode[digitNum] = 9;
        }

        SetCurrentCodes();
    }

    public void ExitMenu() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Destroy(gameObject);
    }

    public void TryCombo() {

        Debug.Log("Code: " + code);
        Debug.Log("Current Code: " + currentCode);

        bool output = true;

        for (int i = 0; i < code.Length; i++) {
            if (code[i] != currentCode[i]) {
                output = false;
            }
        }

        if (output == true) {
            isCorrect = true;

            GameObject[] desks = GameObject.FindGameObjectsWithTag("Desk");
            for (int i = 0; i < desks.Length; i++) {
                GameObject tempDesk = desks[i].transform.parent.gameObject;

                if (tempDesk.GetComponent<Desk>().matchPairCurrent == matchPair) {
                    tempDesk.GetComponent<Desk>().RemoveLock();
                    ExitMenu();
                }
            }
        }
    }

    
}
