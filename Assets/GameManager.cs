using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int numCoinsCollected = 0;
    public int numRubiesCollected = 0;
    public int numCoinsInLevel = 25;
    public ScoreBar scoreBar;
    public TextMeshProUGUI winMessage;
    public GameObject gameOverScreen;
    string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        numCoinsCollected = 0;
        numRubiesCollected = 0;
        // get the current scene so we can reload it when we want to
        sceneName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        // makes it so the user can restart the game whenever they want by pressing r
        if( Input.GetKeyDown("r") ){
            RestartGame();
        }
    }

    // Add coin value to score
    public void AddScore(int value) {
        score++;
        numCoinsCollected += 1;
        //scoreBar.UpdateScoreBar(numCoinsCollected);
        CheckEndGame();
    }

    // Ends game when all coins have been collected
    public void CheckEndGame() {
        if (numCoinsCollected == numCoinsInLevel) {
            EndGame();
        }
    }

    // Ends game
    public void EndGame() {
        if (numCoinsCollected == numCoinsInLevel) {
            winMessage.SetText("You Won");
        } else {
            winMessage.SetText("You Lost");
        }

        //GameObject.FindWithTag("Player").SetActive(false);
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }

    // Add coin value to score
    public void AddNumRubies() {
        Debug.Log(numRubiesCollected);
        numRubiesCollected += 1;
    }

    // get number of rubies collected
    public int GetRubies() {
        return numRubiesCollected;
    }

    // get number of coins collected
    public int GetCoins() {
        return numCoinsCollected;
    }

    // reload the scene to the original state
    public void RestartGame() {
        SceneManager.LoadScene( sceneName );
    }
}