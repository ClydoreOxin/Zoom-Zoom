using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMS : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartApp()
    {
        SceneManager.LoadScene(1);
    }
    public void MenuButton()
    {
        MainManager.Instance.SaveScore();
        SceneManager.LoadScene(0);
    }
}
