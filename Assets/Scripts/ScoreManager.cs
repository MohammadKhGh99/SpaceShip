using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    public static ScoreManager instance;
    private string _initialText = "Score: ";


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = _initialText + GameManager.Score;
    }

    // public void AddPoints(int points)
    // {
    //     GameManager.Score += points;
    //     scoreText.text = _initialText + GameManager.Score;
    // }
    //
    // public void Reduce5Points()
    // {
    //     GameManager.Score -= 5;
    //     scoreText.text = _initialText + GameManager.Score;
    // }
    
    // Update is called once per frame
    void Update()
    {
        scoreText.text = _initialText + GameManager.Score;
    }
}
