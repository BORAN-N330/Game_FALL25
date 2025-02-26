using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    public Color color;

    //light
    Light light1;

    void Start()
    {
        light1 = GetComponentInChildren<Light>();
        light1.color = color;
    }
}
