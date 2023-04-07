using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    [SerializeField]
    GameObject gameName = default;

    [SerializeField]
    GameObject gameOver = default;

    [SerializeField]
    Text scoreText = default;

    [SerializeField]
    GameObject playButton = default;

    int score;

    // Start is called before the first frame update
    void Start()
    {
        gameOver.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
    }

    public void GameStarted()
    {
        score = 0;
        gameName.gameObject.SetActive(false);
        playButton.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);
        UpdateScore();
    }

    public void GameFinished() 
    {
        gameOver.gameObject.SetActive(true);
        playButton.gameObject.SetActive(true);
    }

    void UpdateScore ()
    {
        scoreText.text = "Score: " + score;
    }

    public void AsteroidDestroyed(GameObject asteroid)
    {
        if (asteroid.gameObject.name.Contains("Big_Asteroid")) 
        {
            score += 5;
            UpdateScore();
        } else if (asteroid.gameObject.name.Contains("Mid_Asteroid"))
        {
            score += 10;
            UpdateScore();

        }
        else
        {
            score += 15;
            UpdateScore();
        }
        
    }
}
