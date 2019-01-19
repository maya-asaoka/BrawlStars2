using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Game is over when hp = 0
// Game is won when currentCoins = coinsToWin

public class GameController : MonoBehaviour {

    // singleton class
    public static GameController instance;

    public GameObject player;

    public Text coinText;
    public Text hpText;
    public Text scoreText;

    // game over and game won popup windows
    public GameObject gameOverText;
    public GameObject gameWonText;

    public int coinsToWin;
    public int startHP;

    private int currentCoins;
    private int hp;
    private bool gameOver = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            currentCoins = 0;
            hp = startHP;
            coinText.text = "Coins: 0/" + coinsToWin;
            hpText.text = "HP: " + startHP;

            gameOverText.SetActive(false);
            gameWonText.SetActive(false);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (gameOver == true && Input.anyKeyDown)
        {
            // reload game
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}

    // Called from PlayerController when Player collies with a coin 
    public void CollectCoin()
    {
        currentCoins++;
        coinText.text = "Coins: " + currentCoins + "/" + coinsToWin;
        if (currentCoins == coinsToWin)
        {
            GameWon();
            gameOver = true;
        }
    }

    public void PlayerHit()
    {
        hp--;
        hpText.text = "HP: " + hp;
        if (hp == 0)
        {
            GameOver();
        }
    }

    void GameWon()
    {
        // time in seconds since game start rounded to nearest int
        float time = Mathf.Round(Time.realtimeSinceStartup);
        scoreText.text = "Your time: " + time + " seconds";
        gameWonText.SetActive(true);
        gameOver = true;
    }

    void GameOver()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }

}
