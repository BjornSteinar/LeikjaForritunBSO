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
    //búið til static instance af RobotsFixed
    public static RobotsFixed instance { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        //set instance sem þetta script og breytt text í "Robots fixed :" + robotsFixed sem er sýnt í leiknum
        instance = this;
        text.text = "Robots fixed :" + robotsFixed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddFixedRobot()
    {
        //hér er bætt við einum við robotsFixed og breytt text í "Robots fixed :" + robotsFixed; og ef robotsFixed er jafnt og fimm þá er leikur kláraður og sena 2 hlaðin
        robotsFixed += 1;
        text.text = "Robots fixed :" + robotsFixed;
        if (robotsFixed is 5)
        {
            SceneManager.LoadScene(2);
        }
    }
}
