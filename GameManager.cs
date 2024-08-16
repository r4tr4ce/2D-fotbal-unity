using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject resetButton;
    public Transform player1StartPosition;
    public Transform player2StartPosition;

    private int scorePlayer1 = 0;
    private int scorePlayer2 = 0;

    private bool gameEnded = false;

    private GameObject player1;
    private GameObject player2;

    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");

        if (player1 == null || player2 == null)
        {
            Debug.LogError("Player GameObjects not found or tagged correctly.");
        }

        UpdateScoreText();
        resetButton.SetActive(false);
    }

    public void UpdateScore(string goalName)
    {
        if (gameEnded)
            return;

        if (goalName == "Net1")
        {
            scorePlayer2++;
        }
        else if (goalName == "Net2")
        {
            scorePlayer1++;
        }

        if (scorePlayer1 >= 10 || scorePlayer2 >= 10)
        {
            EndGame();
        }
        else
        {
            UpdateScoreText(); // Only update score if game is not ended
            ResetPlayerPositions();
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = $"{scorePlayer1} : {scorePlayer2}";
    }

    private void EndGame()
    {
        gameEnded = true;

        string winnerText = (scorePlayer1 >= 10) ? "Player 1 wins!" : "Player 2 wins!";
        scoreText.text = winnerText;

        ResetPlayerPositions();
        resetButton.SetActive(true);

        Time.timeScale = 0f;
    }

    private void ResetPlayerPositions()
    {
        player1.transform.position = player1StartPosition.position;
        player2.transform.position = player2StartPosition.position;
    }

    public void ResetGame()
    {
        scorePlayer1 = 0;
        scorePlayer2 = 0;
        UpdateScoreText();

        resetButton.SetActive(false);
        gameEnded = false;

        Time.timeScale = 1f;

        ResetPlayerPositions();
    }
}
