using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public TMP_Text scoreText;

    private int score = 0;
    public int nextLevelScore = 10;

    void Start()
    {
        UpdateScore();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Voodoo"))
        {
            Destroy(other.gameObject);

            score++;
            UpdateScore();

            if (score >= nextLevelScore)
            {
                NextLevel();
            }
        }
    }

    void UpdateScore()
    {
        scoreText.text = score + " / " + nextLevelScore;
    }

    void NextLevel()
    {
        int current = SceneManager.GetActiveScene().buildIndex;

        if (current + 1 < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(current + 1);
        }
    }
}
