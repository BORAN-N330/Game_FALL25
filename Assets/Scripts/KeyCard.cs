using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyCard : MonoBehaviour
{

    public string cardText = "A";
    public int cardID = 0;

    //text
    TMP_Text textObj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textObj = GetComponentInChildren<TMP_Text>();
        textObj.text = cardText;
    }
}
