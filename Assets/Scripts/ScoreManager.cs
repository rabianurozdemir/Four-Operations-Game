using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public int wrongCount = 0;

    public UnityEngine.UI.Image healthIconImage1;
    public UnityEngine.UI.Image healthIconImage2;
    public UnityEngine.UI.Image healthIconImage3;

    void Start()
    {

    }

    void Update()
    {

    }

    public void IncreaseScore()
    {
        score += 2;
        scoreText.text = "Score: " + score;

        if (score == 10)
        {
            NextLevel();
        }
    }

    public void GameOver()
    {
        score = 0;
        scoreText.text = "Score: " + score;
    }

    public void NextLevel()
    {

        if (SceneManager.GetActiveScene().name == "Level1")
        {
            scoreText.text = "Yeni bölüme geçiliyor...";
            StartCoroutine(WaitCoroutine());
            SceneManager.LoadScene("Level2", LoadSceneMode.Single);
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            scoreText.text = "Yeni bölüme geçiliyor...";
            StartCoroutine(WaitCoroutine());
            SceneManager.LoadScene("Level3", LoadSceneMode.Single);
        }
        else if (SceneManager.GetActiveScene().name == "Level3")
        {
            scoreText.text = "Oyun bitti!";
            StartCoroutine(WaitCoroutine());
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
        healthIconImage1.enabled = true;
        healthIconImage2.enabled = true;
        healthIconImage3.enabled = true;

    }
    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(5f);
    }
}
