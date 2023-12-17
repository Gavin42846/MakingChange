using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class MoneyCalc : MonoBehaviour
{
    public AudioClip[] moneyClips;
    public AudioSource audioSource2, audioSource;

    public TextMeshProUGUI textFieldGiven, textFieldDue, textFieldChange, textFieldPeople;
    string dueString, givenString;
    float dueFloat, givenFloat, changeFloat, calcFloat, diffFloat;
    int randomInt;
    public int PeopleLeftNum;

    // Start is called before the first frame update
    void Start()
    {
        //audioSource = FindObjectOfType<AudioSource>();
        textFieldDue = GameObject.Find("AmountDueNum").GetComponent<TextMeshProUGUI>();
        textFieldGiven = GameObject.Find("AmountGivenNum").GetComponent<TextMeshProUGUI>();
        textFieldChange = GameObject.Find("ChangeNum").GetComponent<TextMeshProUGUI>();
        textFieldPeople = GameObject.Find("PeopleLeftNum").GetComponent<TextMeshProUGUI>();
        textFieldPeople.text = "" + PeopleLeftNum;
        updateDue();
        updateGiven();
        audioSource2.loop = false;
        audioSource2.volume = audioSource.volume * 1.5f;



    }


    public void updateDue()
    {
        dueFloat = Random.Range(0.00f, 20.00f);
        dueFloat = 0.01f * (Mathf.RoundToInt(dueFloat * 100f));
        dueString = string.Format("{0:0.00}", dueFloat);      
        textFieldDue.text = dueString;
    }
    public void updateGiven()
    {

        randomInt = Random.Range(1, 100);
        //Debug.Log("random range = " + randomInt);

        if(randomInt <= 10)
        {
            Debug.Log("got to 1");
            givenFloat = Mathf.Ceil(dueFloat);
        }
        else if(randomInt <= 45)
        {
            Debug.Log("got to 5");
            givenFloat = (Mathf.Ceil(dueFloat / 5) * 5);
        }
        else if(randomInt <= 95)
        {
            Debug.Log("got to 10");
            givenFloat = (Mathf.Ceil(dueFloat / 10) * 10);
        }
        else if(randomInt <= 100)
        {
            Debug.Log("got to 100");
            givenFloat = (Mathf.Ceil(dueFloat / 100) * 100);
        }


        //givenFloat = Random.Range(10.00f, 20.00f);
        //givenFloat = 0.01f * (Mathf.RoundToInt(givenFloat * 100f));
        givenString = string.Format("{0:0.00}", givenFloat);
        textFieldGiven.text = givenString;

    }
    public void resetAmounts()
    {
        Debug.Log("got to reset amounts");
        if(PeopleLeftNum <= 1)
        {
            //Debug.Log("should go to score screen");
            SceneManager.LoadScene("ScoreScreen");        
            return;
        }
        //Debug.Log("Change float should be " + textFieldChange.text);
        changeFloat = float.Parse(textFieldChange.text);
        //Debug.Log("Change float is " + changeFloat.ToString());
        changeFloat = 0.01f * (Mathf.RoundToInt(changeFloat * 100f));
        //Debug.Log("Change float is " + changeFloat.ToString());
        //Debug.Log("Given float is " + givenFloat.ToString());
        //Debug.Log("Due float is " + dueFloat.ToString());
        //Debug.Log("The amount of the calc is: " + ((givenFloat - dueFloat)).ToString());
        calcFloat = givenFloat - dueFloat;
        calcFloat = 0.01f * (Mathf.RoundToInt(calcFloat * 100f));
        Debug.Log("calc float is: " + calcFloat.ToString());
        diffFloat = calcFloat - changeFloat;       
        Debug.Log("diff float is: " + diffFloat.ToString());
        if((diffFloat < 0.001f) && (diffFloat >= 0f))
        {
            Debug.Log("shouldve played success beep");
            PeopleLeftNum -= 1;
            textFieldPeople.text = "" + PeopleLeftNum;
            //Debug.Log("shouldve zero'd change");
            FindObjectOfType<MoneyAdd>().reZero();
            sellSuccess();
            updateDue();
            //Debug.Log("shouldve reset due");
            updateGiven();
            //Debug.Log("shouldve reset given");
            diffFloat = 0;
        }
        else sellFailure();
    }

    public void sellSuccess()
    {
        //play chaching
        //Debug.Log("play chaching");
        audioSource2.clip = moneyClips[0];
        audioSource2.Play();
    }
    public void sellFailure()
    {
        //Debug.Log("play deny beep");
        audioSource2.clip = moneyClips[1];
        audioSource2.Play();
        //play deny beep
    }
    



    // Update is called once per frame
    void Update()
    {

        
    }
}
