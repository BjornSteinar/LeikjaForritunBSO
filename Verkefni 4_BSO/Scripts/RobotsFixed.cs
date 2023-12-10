using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RobotsFixed : MonoBehaviour
{
    //skilgreint robotsFixed sem int =0 og text sem TMPGUI
    public int robotsFixed =0;
    public TextMeshProUGUI text;
    //b�i� til static instance af RobotsFixed
    public static RobotsFixed instance { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        //set instance sem �etta script og breytt text � "Robots fixed :" + robotsFixed sem er s�nt � leiknum
        instance = this;
        text.text = "Robots fixed :" + robotsFixed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddFixedRobot()
    {
        //h�r er b�tt vi� einum vi� robotsFixed og breytt text � "Robots fixed :" + robotsFixed; og ef robotsFixed er jafnt og fimm �� er leikur kl�ra�ur og sena 2 hla�in
        robotsFixed += 1;
        text.text = "Robots fixed :" + robotsFixed;
        if (robotsFixed is 5)
        {
            SceneManager.LoadScene(2);
        }
    }
}
