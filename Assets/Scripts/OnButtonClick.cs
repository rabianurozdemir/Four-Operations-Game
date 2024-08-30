using UnityEngine;
using UnityEngine.SceneManagement;

public class OnButtonClick : MonoBehaviour
{
    public void OnClickLevel1Button()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

    public void OnClickLevel2Button()
    {
        SceneManager.LoadScene("Level2", LoadSceneMode.Single);
    }

    public void OnClickLevel3Button()
    {
        SceneManager.LoadScene("Level3", LoadSceneMode.Single);
    }

    public void OnClickExitButton()
    {
        Application.Quit();
    }
}
