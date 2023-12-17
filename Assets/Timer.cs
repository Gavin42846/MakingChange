using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI textFieldTimer, textFieldPeople, textFieldScore, textFieldScoreTimer;
    private float secondCounter, minCounter, ScoreCounter;
    string secondSwap;
    static int totalPeople;
    static float totalTime;
    static string scoreTime, scoreString;
    // Start is called before the first frame update
    void Start()
    {       
        textFieldPeople = GameObject.Find("PeopleLeftNum").GetComponent<TextMeshProUGUI>();
        totalPeople = int.Parse(textFieldPeople.text);
        //Debug.Log("total people = " + totalPeople);
    }

    // Update is called once per frame
    void Update()
    {
        textFieldTimer = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
        timerUI();
    }

    public void timerUI()
    {
        secondCounter += Time.deltaTime;
        secondSwap = string.Format("{0:00}", secondCounter);
        textFieldTimer.text = minCounter + ":" + secondSwap;
        scoreTime = minCounter + ":" + secondSwap;
        if(secondCounter >= 60)
        {
            minCounter++;
            secondCounter = 0;
        }
        totalTime = (minCounter * 60) + secondCounter;
    }

    public void resetTimer()
    {
        secondCounter = 0;
        minCounter = 0;
    }

    public void ScoreCalc()
    {
        enabled = false;
        ScoreCounter = (totalPeople * (100000/totalTime));
        textFieldScore = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();   
        textFieldScoreTimer = GameObject.Find("TimeText").GetComponent<TextMeshProUGUI>();
        textFieldScoreTimer.text = "Time: " + scoreTime;
        scoreString = ScoreCounter.ToString();
        scoreString = string.Format("{0:00000}", ScoreCounter);
        textFieldScore.text = "Score: " + scoreString;
    }

}
