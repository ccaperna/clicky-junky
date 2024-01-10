using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> target;
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI volumeText;
    public TextMeshProUGUI pauseText;

    public Button restartButt;
    public GameObject mainMenu;

    public bool gameActive;
    public bool gamePaused;
    private float spawnRate = 1.5f;
    private int score;
    public int lives;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
     if (Input.GetKey(KeyCode.Space))
        {
            pauseGame();
        }
    }

    public void startGame(int difficulty)
    {
        gameActive = true;
        gamePaused = false;
        score = 0;
        lives = 3;
        spawnRate /= difficulty;
        StartCoroutine("spawnTarget");
        updateScore(0);
        livesText.text = "Lives: " + lives;
        mainMenu.gameObject.SetActive(false);
    }

    public void gameIsOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButt.gameObject.SetActive(true);
        gameActive = false;
    }

    public void updateScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator spawnTarget()
    {
        while(gameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, target.Count);
            Instantiate(target[index]);
        }
    }

    public void pauseGame()
    {
        if (!gamePaused)
        {
            gamePaused = true;
            Time.timeScale = 0f;
            pauseText.gameObject.SetActive(true);
            Debug.Log("Game paused");
            //gameActive = false;
        }
        else
        {
            gamePaused = false;
            pauseText.gameObject.SetActive(false);
            //gameActive = true;
            Time.timeScale = 1f;
            Debug.Log("Game resumed");
        }
    }
}
