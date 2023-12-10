using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour
{
    //skilgreint displayTime sem float = 16.0f, dialogBox sem GameObject � unityEditor, og timerDisplay sem float
    public float displayTime = 16.0f;
    public GameObject dialogBox;
    float timerDisplay;



    // Start is called before the first frame update
    void Start()
    {
        //sl�kkt er � dialogBox og timerDisplay er jafnt og -1.0f 
        dialogBox.SetActive(false);
        timerDisplay = -1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //ef timerDisplay st�rri e�a jafnt og 0 er teki� fr� ein sek fr� timerDisplay
        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;
            //ef timerDisplay er minna en n�ll er sl�kkt � dialogBox
            if (timerDisplay < 0)
            {
                dialogBox.SetActive(false);
            }
        }
    }
    //h�r er set timerDisplay � 16 sek og dialogBox kveikt �
    public void DisplayDialog()
    {
        timerDisplay = displayTime;
        dialogBox.SetActive(true);
    }
}
