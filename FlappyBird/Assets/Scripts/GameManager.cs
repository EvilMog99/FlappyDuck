using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;

    public GameUtilities utilities;

    private bool gameRunning = true; public void setGameRunning(bool b) { gameRunning = b; }
    public bool isGameRunning() { return gameRunning; }

    private int playerScore = 0; public int getPlayerScore() { return playerScore; }

    // Start is called before the first frame update
    void Start()
    {
        utilities = gameObject.GetComponent<GameUtilities>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + playerScore;
    }

    public void addToScore(int val)
    {
        playerScore += val;
    }

    public bool testScore()
    {
        if (utilities.getHighScore() < playerScore)
        {
            utilities.saveHighScore(playerScore);
            return true;
        }
        return false;
    }
}
