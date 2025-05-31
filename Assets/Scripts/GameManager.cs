using System.Threading;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject gameUI;
    public GameObject gameOverUI;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesRemainingText;
    public TextMeshProUGUI timerText;
    public Button retryButton;
    public Button quitButton;

    public int score = 0;
    public int livesRemaining = 999;
    public bool isGameOver = false;

    private float elapsedTime;
    private bool isRunning = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
        livesRemainingText.text = "Lives Remaining " + livesRemaining;

        GameOver(livesRemaining);

        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(elapsedTime / 60f);
            int seconds = Mathf.FloorToInt(elapsedTime % 60f);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }


    void ResetTimer()
    {
        elapsedTime = 0f;
        isRunning = true;
    }

    void StopTimer()
    {
        isRunning = false;
    }

    void GameOver(int livesRemaining)
    {
        if (livesRemaining <= 0)
        {
            isGameOver = true;
            gameUI.SetActive(false);
            gameOverUI.SetActive(true);

            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }

    public void StartGame()
    {
        if (isGameOver)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else 
        Application.Quit();
#endif
    }

}
