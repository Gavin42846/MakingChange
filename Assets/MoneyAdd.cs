using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class MoneyAdd : MonoBehaviour
{
    public AudioClip[] moneyClips;
    public AudioSource audioSource3, audioSource2;
    public TextMeshProUGUI textFieldChange;
    public double ChangeCounter = 0.00;
    double resetMem;
    string changeSwap, changeMem;
    char lastChar;

    // Start is called before the first frame update
    void Start()
    {
        textFieldChange = GameObject.Find("ChangeNum").GetComponent<TextMeshProUGUI>();
        textFieldChange.text = "0.00";
        audioSource3.loop = false;
        
    }
    //adds the money to the change counter/UI
    public void addPenny()
    {
        coinSound();
        ChangeCounter += 0.01;
        changeSwap = string.Format("{0:0.00}", ChangeCounter);
        textFieldChange.text = changeSwap;
        changeMem = changeMem + "p";
    }

    public void addNickle()
    {
        coinSound();
        ChangeCounter += 0.05;
        changeSwap = string.Format("{0:0.00}", ChangeCounter);
        textFieldChange.text = changeSwap;
        changeMem = changeMem + "n";
    }

    public void addDime()
    {
        coinSound();
        ChangeCounter += 0.10;
        changeSwap = string.Format("{0:0.00}", ChangeCounter);
        textFieldChange.text = changeSwap;
        changeMem = changeMem + "d";
    }
    public void addQuarter()
    {
        coinSound();
        ChangeCounter += 0.25;
        changeSwap = string.Format("{0:0.00}", ChangeCounter);
        textFieldChange.text = changeSwap;
        changeMem = changeMem + "q";
    }

    public void addDollar()
    {
        dollarSound();
        ChangeCounter += 1.00;
        changeSwap = string.Format("{0:0.00}", ChangeCounter);
        textFieldChange.text = changeSwap;
        changeMem = changeMem + "D";
    }
    public void addFive()
    {
        dollarSound();
        ChangeCounter += 5.00;
        changeSwap = string.Format("{0:0.00}", ChangeCounter);
        textFieldChange.text = changeSwap;
        changeMem = changeMem + "F";
    }
    public void addTen()
    {
        dollarSound();
        ChangeCounter += 10.00;
        changeSwap = string.Format("{0:0.00}", ChangeCounter);
        textFieldChange.text = changeSwap;
        changeMem = changeMem + "t";
    }
    public void addTwenty()
    {
        dollarSound();
        ChangeCounter += 20.00;
        changeSwap = string.Format("{0:0.00}", ChangeCounter);
        textFieldChange.text = changeSwap;
        changeMem = changeMem + "T";
    }
    //sets change to 0.00 and resets the float holding it's info
    public void reZero()
    {
        //Debug.Log("changeMem = " + changeMem);
        ChangeCounter = 0.00;
        changeSwap = string.Format("{0:0.00}", ChangeCounter);
        textFieldChange.text = changeSwap;
        changeMem = "";
    }
    //commands to undo any input
    public void undoButton()
    {
        resetButtonSound();
        //Debug.Log("changemem is: " + changeMem);
        lastChar = changeMem[changeMem.Length - 1];
        //Debug.Log("last button pressed was: " + lastChar);
        if(lastChar == 'p')
        {
            ChangeCounter -= 0.01;
            changeSwap = string.Format("{0:0.00}", ChangeCounter);
            textFieldChange.text = changeSwap;
            changeMem = changeMem.Remove(changeMem.Length - 1);
            lastChar = changeMem[changeMem.Length - 1];
        }
        else if(lastChar == 'n')
        {
            ChangeCounter -= 0.05;
            changeSwap = string.Format("{0:0.00}", ChangeCounter);
            textFieldChange.text = changeSwap;
            changeMem = changeMem.Remove(changeMem.Length - 1);
            lastChar = changeMem[changeMem.Length - 1];
        }
        else if(lastChar == 'd')
        {
            ChangeCounter -= 0.10;
            changeSwap = string.Format("{0:0.00}", ChangeCounter);
            textFieldChange.text = changeSwap;
            changeMem = changeMem.Remove(changeMem.Length - 1);
            lastChar = changeMem[changeMem.Length - 1];
        }
        else if(lastChar == 'q')
        {
            ChangeCounter -= 0.25;
            changeSwap = string.Format("{0:0.00}", ChangeCounter);
            textFieldChange.text = changeSwap;
            changeMem = changeMem.Remove(changeMem.Length - 1);
            lastChar = changeMem[changeMem.Length - 1];
        }
        else if(lastChar == 'D')
        {
            ChangeCounter -= 1.00;
            changeSwap = string.Format("{0:0.00}", ChangeCounter);
            textFieldChange.text = changeSwap;
            changeMem = changeMem.Remove(changeMem.Length - 1);
            lastChar = changeMem[changeMem.Length - 1];
        }
        else if(lastChar == 'F')
        {
            ChangeCounter -= 5.00;
            changeSwap = string.Format("{0:0.00}", ChangeCounter);
            textFieldChange.text = changeSwap;
            changeMem = changeMem.Remove(changeMem.Length - 1);
            lastChar = changeMem[changeMem.Length - 1];
        }
        else if(lastChar == 't')
        {
            ChangeCounter -= 10.00;
            changeSwap = string.Format("{0:0.00}", ChangeCounter);
            textFieldChange.text = changeSwap;
            changeMem = changeMem.Remove(changeMem.Length - 1);
            lastChar = changeMem[changeMem.Length - 1];
        }
        else if(lastChar == 'T')
        {
            ChangeCounter -= 20.00;
            changeSwap = string.Format("{0:0.00}", ChangeCounter);
            textFieldChange.text = changeSwap;
            changeMem = changeMem.Remove(changeMem.Length - 1);
            lastChar = changeMem[changeMem.Length - 1];
        }
        /*else if (lastChar == 'R')
        {
            ChangeCounter = resetMem;
            changeSwap = string.Format("{0:0.00}", ChangeCounter);
            textFieldChange.text = changeSwap;
            changeMem = changeMem.Remove(changeMem.Length - 1);
            lastChar = changeMem[changeMem.Length - 1];
        }*/
        //else make a deny sound cause aint nothing to undo
    }
    //sets change to 0.00
    public void resetButton()
    {
        resetButtonSound();
        //resetMem = ChangeCounter;
        ChangeCounter = 0.00;
        changeSwap = string.Format("{0:0.00}", ChangeCounter);
        textFieldChange.text = changeSwap;
        changeMem = "";
        lastChar = changeMem[changeMem.Length - 1];
    }
    //clears history
    public void resetHistory()
    {
        lastChar = 'C';
        changeMem = "";
    }
    public void coinSound()
    {
        Debug.Log("play coin sound");
        audioSource3.clip = moneyClips[0];
        audioSource3.Play();
        //play coin sound
    }
    public void dollarSound()
    {
        Debug.Log("play dollar sound");
        audioSource3.clip = moneyClips[1];
        audioSource3.Play();
        //play dollar sound
    }
    public void resetButtonSound()
    {
        Debug.Log("play reset sound");
        audioSource3.clip = moneyClips[2];
        audioSource3.Play();
        //plays reset button sound and undo button sound
    }

    // Update is called once per frame
    void Update()
    {
        audioSource3.volume = audioSource2.volume;
    }
}
