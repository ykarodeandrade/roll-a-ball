using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public Text pointsText;


    public void PlayAgin()
    {
        SceneManager.LoadScene("minigame");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + "POINTS";
    }
}
