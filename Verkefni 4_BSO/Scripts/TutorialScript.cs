using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    //teki� er inn dialogBox
    public GameObject dialogBox;

    // Start is called before the first frame update
    void Start()
    {
        //kveikt er � �v�
        dialogBox.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //og ef �tt er � "X" �� er dialogBox set sem false
        if (Input.GetKeyDown("x"))
        {
            dialogBox.SetActive(false);
        }
    }
}
