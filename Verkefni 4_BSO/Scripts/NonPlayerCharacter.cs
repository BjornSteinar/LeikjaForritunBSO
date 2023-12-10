using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour
{
    //skilgreint displayTime sem float = 16.0f, dialogBox sem GameObject í unityEditor, og timerDisplay sem float
    public float displayTime = 16.0f;
    public GameObject dialogBox;
    float timerDisplay;



    // Start is called before the first frame update
    void Start()
    {
        //slökkt er á dialogBox og timerDisplay er jafnt og -1.0f 
        dialogBox.SetActive(false);
        timerDisplay = -1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //ef timerDisplay stærri eða jafnt og 0 er tekið frá ein sek frá timerDisplay
        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;
            //ef timerDisplay er minna en núll er slökkt á dialogBox
            if (timerDisplay < 0)
            {
                dialogBox.SetActive(false);
            }
        }
    }
    //hér er set timerDisplay á 16 sek og dialogBox kveikt á
    public void DisplayDialog()
    {
        timerDisplay = displayTime;
        dialogBox.SetActive(true);
    }
}
