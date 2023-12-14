using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    //teki� er inn ammoCount TMPGUI og set ammo sem int = 0 og set instance of UIAmmo
    public TextMeshProUGUI scoreCount;
    int score = 0;
    public static ScoreManager instance { get; private set; }

    void Awake()
    {
        //set er �etta sem instance
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //breytt er ammoCount � ": " + ammo.ToString();
        scoreCount.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddScore(int number)
    {
        score += number;
        scoreCount.text = "Score: " + score.ToString();
    }
}
