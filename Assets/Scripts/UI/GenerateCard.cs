using UnityEngine;
using TMPro;

public class GenerateCard : MonoBehaviour
{
    public GameObject card; //prefab

    public void CreateCard(string text) {
        GameObject tempCard = Instantiate(card, new UnityEngine.Vector3(0,0,0), Quaternion.identity);
        tempCard.GetComponentInChildren<TMP_Text>().text = text;
        tempCard.transform.SetParent(transform);
    }
}
