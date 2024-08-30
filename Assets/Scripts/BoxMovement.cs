using System;
using UnityEngine;
using UnityEngine.UI;

public class BoxMovement : MonoBehaviour
{
    private BoxSpawner boxSpawnerScript;
    private RandomNumberGenerator randomNumberGeneratorScript;
    private ScoreManager scoreManagerScript;
    private float moveSpeed = 2f;
    public Boolean isCorrectBox = false;


    void Start()
    {
        boxSpawnerScript = GameObject.Find("BoxSpawner").GetComponent<BoxSpawner>();
        randomNumberGeneratorScript = GameObject.Find("RandomNumberGenerator").GetComponent<RandomNumberGenerator>();
        scoreManagerScript = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();

    }

    void Update()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (isCorrectBox)
            {
                scoreManagerScript.IncreaseScore();
            }
            else
            {
                scoreManagerScript.wrongCount++;
                if (scoreManagerScript.wrongCount == 1)
                {
                    scoreManagerScript.healthIconImage3.enabled = false;
                }
                else if (scoreManagerScript.wrongCount == 2)
                {
                    scoreManagerScript.healthIconImage2.enabled = false;
                }
                else if (scoreManagerScript.wrongCount == 3)
                {
                    scoreManagerScript.healthIconImage1.enabled = false;
                    scoreManagerScript.GameOver();
                    scoreManagerScript.wrongCount = 0;
                    scoreManagerScript.healthIconImage1.enabled = true;
                    scoreManagerScript.healthIconImage2.enabled = true;
                    scoreManagerScript.healthIconImage3.enabled = true;
                }
            }
            Destroy(gameObject);
            randomNumberGeneratorScript.GenerateRandomNumber();
        }
        else if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }

}
