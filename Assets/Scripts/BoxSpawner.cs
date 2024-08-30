using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoxSpawner : MonoBehaviour
{
    private RandomNumberGenerator randomNumberGeneratorScript;
    int firstNumber;
    int secondNumber;
    string selectedOperator;
    int result;

    public GameObject boxPrefab;
    int correctResult;
    int wrongResult1;
    int wrongResult2;

    void Start()
    {
        randomNumberGeneratorScript = GameObject.Find("RandomNumberGenerator").GetComponent<RandomNumberGenerator>();
        StartCoroutine(SpawnBoxRepeatedly());
    }

    void Update()
    {


    }

    IEnumerator SpawnBoxRepeatedly()
    {
        while (true)
        {
            SpawnBox();
            yield return new WaitForSeconds(4f);
        }
    }

    public int GenerateResult()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            firstNumber = int.Parse(randomNumberGeneratorScript.firstNumberText.text);
            secondNumber = int.Parse(randomNumberGeneratorScript.secondNumberText.text);
            selectedOperator = randomNumberGeneratorScript.operatorText.text;

            if (selectedOperator == "+")
            {
                result = firstNumber + secondNumber;
            }
            else if (selectedOperator == "-")
            {
                result = firstNumber - secondNumber;
            }
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            firstNumber = int.Parse(randomNumberGeneratorScript.firstNumberText.text);
            secondNumber = int.Parse(randomNumberGeneratorScript.secondNumberText.text);
            selectedOperator = randomNumberGeneratorScript.operatorText.text;

            if (selectedOperator == "x")
            {
                result = firstNumber * secondNumber;
            }
            else if (selectedOperator == "/")
            {
                result = firstNumber / secondNumber;
            }
        }
        else if (SceneManager.GetActiveScene().name == "Level3")
        {

            firstNumber = randomNumberGeneratorScript.firstNumber;
            secondNumber = randomNumberGeneratorScript.secondNumber;
            selectedOperator = randomNumberGeneratorScript.selectedOperator;

            // firstNumber = int.Parse(randomNumberGeneratorScript.firstNumberText.text);
            // secondNumber = int.Parse(randomNumberGeneratorScript.secondNumberText.text);
            // selectedOperator = randomNumberGeneratorScript.operatorText.text;

            if (selectedOperator == "+")
            {
                result = firstNumber + secondNumber;
            }
            else if (selectedOperator == "-")
            {
                result = firstNumber - secondNumber;
            }
            else if (selectedOperator == "x")
            {
                result = firstNumber * secondNumber;
            }
            else if (selectedOperator == "/")
            {
                result = firstNumber / secondNumber;
            }

            int random = Random.Range(1, 4);

            if (random == 1)
            {
                randomNumberGeneratorScript.firstNumberText.text = "?";
                randomNumberGeneratorScript.operatorText.text = selectedOperator;
                randomNumberGeneratorScript.secondNumberText.text = secondNumber.ToString();
                randomNumberGeneratorScript.thirdNumberText.text = result.ToString();
                return firstNumber;
            }
            else if (random == 2)
            {
                randomNumberGeneratorScript.firstNumberText.text = firstNumber.ToString();
                randomNumberGeneratorScript.operatorText.text = selectedOperator;
                randomNumberGeneratorScript.secondNumberText.text = "?";
                randomNumberGeneratorScript.thirdNumberText.text = result.ToString();
                return secondNumber;
            }
            else if (random == 3)
            {
                randomNumberGeneratorScript.firstNumberText.text = firstNumber.ToString();
                randomNumberGeneratorScript.operatorText.text = selectedOperator;
                randomNumberGeneratorScript.secondNumberText.text = secondNumber.ToString();
                randomNumberGeneratorScript.thirdNumberText.text = "?";
                return result;
            }
        }
        return result;
    }

    public void SpawnBox()
    {
        GameObject box1 = Instantiate(boxPrefab, transform.position, Quaternion.identity);
        GameObject box2 = Instantiate(boxPrefab, transform.position + new Vector3(1.7f, 0, 0), Quaternion.identity);
        GameObject box3 = Instantiate(boxPrefab, transform.position + new Vector3(3.4f, 0, 0), Quaternion.identity);

        int correctResult = GenerateResult();
        if (correctResult < 2)
        {
            wrongResult1 = 2;
            wrongResult2 = 3;
        }
        else
        {
            wrongResult1 = Random.Range(correctResult - 2, correctResult + 2);
            wrongResult2 = Random.Range(correctResult - 2, correctResult + 2);

            while (wrongResult1 == correctResult || wrongResult2 == correctResult || wrongResult1 == wrongResult2)
            {
                wrongResult1 = Random.Range(correctResult - 2, correctResult + 2);
                wrongResult2 = Random.Range(correctResult - 2, correctResult + 2);
            }
        }

        int correctBoxIndex = Random.Range(1, 4);
        if (correctBoxIndex == 1)
        {
            box1.GetComponent<BoxMovement>().isCorrectBox = true;
            box1.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = correctResult.ToString();
            box2.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = wrongResult1.ToString();
            box3.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = wrongResult2.ToString();
        }
        else if (correctBoxIndex == 2)
        {
            box2.GetComponent<BoxMovement>().isCorrectBox = true;
            box1.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = wrongResult1.ToString();
            box2.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = correctResult.ToString();
            box3.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = wrongResult2.ToString();
        }
        else if (correctBoxIndex == 3)
        {
            box3.GetComponent<BoxMovement>().isCorrectBox = true;
            box1.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = wrongResult1.ToString();
            box2.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = wrongResult2.ToString();
            box3.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = correctResult.ToString();
        }

    }
}
