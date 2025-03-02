using Unity.VisualScripting;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    void Start(){
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void QuitGame(){
        Application.Quit();
        Debug.Log("QuitGame");
    }




}
