using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    private string _initialText = "Score: ";
    public static ScoreManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = _initialText + GameManager.Score;
    }

    // Update is called once per frame
    public void UpdateScore()
    {
        scoreText.text = _initialText + GameManager.Score;
    }
}
