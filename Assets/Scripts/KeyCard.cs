using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class KeyCard : MonoBehaviour
{

    public string cardText = "A";
    public int cardID = 0;

    //gamemanager
    GameManager gameManager;

    //text
    TMP_Text textObj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        textObj = GetComponentInChildren<TMP_Text>();
        textObj.text = cardText;
    }

    //onCollision with player
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            PickupCard();
        }
    }

    private void PickupCard() {
        //deativate collider
        this.GetComponent<BoxCollider>().enabled = false;
        //deativate mesh
        this.gameObject.SetActive(false);
        //(optional) play sound
        //add to gamemanager ids
        gameManager.addKeyCard(cardID, cardText);

        //delete
        Destroy(this.gameObject);
    }
}
