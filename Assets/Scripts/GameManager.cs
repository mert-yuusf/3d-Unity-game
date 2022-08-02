using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameOver = false;
    public bool gameStarted = false;
    public float restartDelay = 2f;
    private int score = 0;
    // UI ELEMENTS
    public Text scoreText;
    public void GameOver()
    {
        if (gameOver == true)
        {
            //gameOver = true;
            Invoke("RestartGame", restartDelay);
        }
        
    }

    void RestartGame()
    {
        this.gameStarted = false;
        SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
    }

    void DisplayScore()
    {
        if(scoreText != null)
        {
            scoreText.text = "Score : " + this.score;
        }
    }
    public void StartGame()
    {
        gameStarted = true;
        SceneManager.LoadScene("Level-1");
    }
    public void IncreaseScore(int value)
    {
        this.score += value;
        this.DisplayScore();
        Debug.Log(value);
    }


}
