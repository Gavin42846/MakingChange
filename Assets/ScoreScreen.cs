using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ScoreScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<Timer>().ScoreCalc();  

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
