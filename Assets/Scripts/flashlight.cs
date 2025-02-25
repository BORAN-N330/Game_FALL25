using UnityEngine;
using System.Collections;
using UnityEngine.Experimental.GlobalIllumination;

public class FlashLight : MonoBehaviour {
    private Light myLight;
      
    void Start ()
    {
        //light is a child of flashlight
        myLight = GetComponentInChildren<Light>();
    }
      
    void Update ()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            myLight.enabled = !myLight.enabled;
        }
    }
}
