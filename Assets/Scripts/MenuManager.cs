using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Manager manager;
    public SpawnerObject spawn;
    public GameObject Canvas;
    public GameObject InGameCanvas;
    public TMP_Text scoreText;
    public TMP_Text highscoreText;
    private float hs;

    private void Start()
    {
        scoreText.text = "0";
        highscoreText.text = "0";
        hs = 0;
        InGameCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.gameover)
        { 
            GameOver();
            Debug.Log("gameover!");
        }
    }

    public void PlayButton()
    {
        StartCoroutine(Timer());
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    private void GameOver()
    {
        scoreText.text = manager.scoreText.text;
        manager.ResetGame();
        spawn.spawningBool = false;
        spawn.StopAllCoroutines();
        if(hs < float.Parse(scoreText.text)) 
        {
            hs = float.Parse(scoreText.text);
            highscoreText.text = hs.ToString();
        }
        Canvas.SetActive(true);
    }
    IEnumerator Timer()
    {
        Canvas.SetActive(false);
        InGameCanvas.SetActive(true);
        yield return new WaitForSeconds(1f);

        spawn.spawningBool = true;
        spawn.StartGame();
    }
}
