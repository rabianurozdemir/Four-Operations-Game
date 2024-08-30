using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class RandomNumberGenerator : MonoBehaviour
{
    public TextMeshProUGUI firstNumberText;
    public TextMeshProUGUI operatorText;
    public TextMeshProUGUI secondNumberText;
    public TextMeshProUGUI thirdNumberText;

    public int firstNumber;
    public int secondNumber;
    public int thirdNumber;
    public string selectedOperator;

    void Start()
    {
        GenerateRandomNumber();
    }


    public void GenerateRandomNumber()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            string[] operators = new string[] { "+", "-" };
            selectedOperator = operators[Random.Range(0, operators.Length)];

            firstNumber = Random.Range(1, 10);
            firstNumberText.text = firstNumber.ToString();

            secondNumber = Random.Range(1, 10);

            while (selectedOperator == "-" && firstNumber < secondNumber)
            {
                secondNumber = Random.Range(1, 10);

            }

            secondNumberText.text = secondNumber.ToString();

            operatorText.text = selectedOperator;
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            string[] operators = new string[] { "x", "/" };
            selectedOperator = operators[Random.Range(0, operators.Length)];

            firstNumber = Random.Range(1, 10);
            firstNumberText.text = firstNumber.ToString();

            secondNumber = Random.Range(1, 10);

            while (selectedOperator == "/" && firstNumber % secondNumber != 0)
            {
                secondNumber = Random.Range(1, 10);
            }

            secondNumberText.text = secondNumber.ToString();

            operatorText.text = selectedOperator;
        }
        else if (SceneManager.GetActiveScene().name == "Level3")
        {
            string[] operators = new string[] { "+", "-", "x", "/" };
            selectedOperator = operators[Random.Range(0, operators.Length)];

            firstNumber = Random.Range(1, 10);


            secondNumber = Random.Range(1, 10);

            while (selectedOperator == "-" && firstNumber < secondNumber)
            {
                secondNumber = Random.Range(1, 10);
            }

            while (selectedOperator == "/" && firstNumber % secondNumber != 0)
            {
                secondNumber = Random.Range(1, 10);
            }




        }
    }
}

