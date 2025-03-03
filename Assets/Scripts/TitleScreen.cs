using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;


public class TitleScreen : MonoBehaviour 
{
    public void PlayGame()
    {
        SceneManager.LoadScene("PuzzleScene");
    }
}
