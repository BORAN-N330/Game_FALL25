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

    void Start()
    {
        generateCard = cardHolder.GetComponent<GenerateCard>();
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
}
