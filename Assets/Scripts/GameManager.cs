using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<int> ids;
    public List<string> cards;

    public void addKeyCard(int id, string text) {
        ids.Add(id);
        cards.Add(text);
        //show on screen? (id collected)

        Debug.Log(ids[0]);
        Debug.Log(cards[0]);
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
