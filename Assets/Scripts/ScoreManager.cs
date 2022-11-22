using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text evilText;

    private const string InitialText = "Score: ";
    public static ScoreManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = InitialText + GameManager.Score;
    }

    // Update is called once per frame
    public void UpdateScore()
    {
        scoreText.text = InitialText + GameManager.Score;
    }

    public void UpdateCurrent(int points)
    {
        evilText.color = points < 0 ? Color.red : Color.green;
        evilText.text = points < 0 ? points.ToString() : "+" + points;
    }

    public void ActiveEvil(bool activeOrNot)
    {
        evilText.gameObject.SetActive(activeOrNot);
    }
}
