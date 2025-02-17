using UnityEngine;

public class CamHolder : MonoBehaviour
{
    public Transform camPos;

    void Update()
    {
        transform.position = camPos.position;
    }
}
