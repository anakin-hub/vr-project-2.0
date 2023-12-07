using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    public int lifes;
    public float points;
    public bool combo;
    public float comboSequence;
    public bool gameover;
    public TMP_Text livesText;
    public TMP_Text scoreText;
    public TMP_Text comboText;

    // Start is called before the first frame update
    void Start()
    {
        ResetGame();
    }

    public void AddPoints()
    {
        if (combo)
        {
            comboSequence += .1f;
            points += (10 * comboSequence);
        }
        else
        {
            combo = true;
            points += 10;
            comboSequence = 1;
        }

        scoreText.text = points.ToString();
        comboText.text = comboSequence.ToString();
    }

    public void MissTarget()
    {
        if (combo)
        {
            combo = false;
        }
        if (comboSequence > 0)
        {
            comboSequence = 0;
        }
        lifes--;

        livesText.text = lifes.ToString();
        scoreText.text = points.ToString();
        comboText.text = comboSequence.ToString();
        if (lifes < 0)
        {
            gameover = true;
        }
    }

    public void Heal()
    {
        lifes++;
        livesText.text = lifes.ToString();
    }

    public void ResetGame()
    {
        gameover = false;
        lifes = 3;
        points = 0;
        combo = false;
        comboSequence = 0;

        livesText.text = lifes.ToString();
        scoreText.text = points.ToString();
        comboText.text = comboSequence.ToString();
    }
}
