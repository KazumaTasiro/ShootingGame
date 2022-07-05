using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GManager : MonoBehaviour
{
    private GameObject[] enemy;

    public GameObject panel;

    public GameObject clearText;
    public GameObject nextButtun;
    private int Score;
    public Text textComponent;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, false);
        Application.targetFrameRate = 60;
        clearText.SetActive(false);
        nextButtun.SetActive(false);
        //panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemy.Length == 0)
        {
            //panel.SetActive(true);
            clearText.SetActive(true);
            nextButtun.SetActive(true);
        }
    }
    public void SceneReset()
    {
        string activeSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(activeSceneName);
    }

    public void ChangeScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }
    public void AddScoreCount()
    {
        Score += 1;
        //Debug.Log("CoinCount" + Score);
        textComponent.text = "score:" + Score;
    }
}
