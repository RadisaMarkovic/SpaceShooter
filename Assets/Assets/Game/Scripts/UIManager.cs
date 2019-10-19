using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Sprite[] _lives = new Sprite[4];

    [SerializeField]
    private Image _spriteLives;

    [SerializeField]
    private Text scoreText;

    public int score;


    [SerializeField]
    private Text _startTitleText;

    
    public void UpdateLives(int currentLife)
    {
        _spriteLives.sprite = _lives[currentLife];
    }

    public void UpdateScore()
    {
        score += 10;
        scoreText.text = "Score: " + score;

    }

    public void ShowTitleScreen()
    {
        _startTitleText.enabled = true;
    }

    public void HideTitleScreen()
    {
        _startTitleText.enabled = false;
        score = 0;
        scoreText.text = "Score: ";
        
    }
    
}
