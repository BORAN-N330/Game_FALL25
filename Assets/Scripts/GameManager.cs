using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<int> ids;
    public List<string> cards;

    public GameObject cardHolder;
    GenerateCard generateCard;

    [Header("Add Player's Flashlight (in orientation) Here")]
    public GameObject playersFlashlight;
    public bool keepFlashlight = false; 

    void Start()
    {
        generateCard = cardHolder.GetComponent<GenerateCard>();

        //make players flashlight invisible until collected
        playersFlashlight.SetActive(keepFlashlight);
    }

    public void addKeyCard(int id, string text) {
        ids.Add(id);
        cards.Add(text);

        //add card to UI
        generateCard.CreateCard(text);
    }

    public bool hasKeyCard(int id) {
        bool output = false;

        //check if the player has an id
        foreach (int card in ids) {
            if (card == id) {
                output = true;
            }
        }

        return output;
    }

    public void SetFlashlightActive() {
        playersFlashlight.SetActive(true);
    }
}
