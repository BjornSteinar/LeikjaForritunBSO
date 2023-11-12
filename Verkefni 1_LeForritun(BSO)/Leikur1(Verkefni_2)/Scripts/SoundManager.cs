using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //Variables sett up
    private PlayerController playerControllerScript;
    private AudioSource cameraSound;

    // Start is called before the first frame update
    void Start()
    {
        //�egar leikur byrjar er s�kt � playerController Scripti� fr� "Player"
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        //svo er sett cameraSound sem AudioSource fr� "Main Camera"
        cameraSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //ef gameover er true �� er t�nlistin h�tt
        if (playerControllerScript.gameOver == true)
        {
            cameraSound.Stop();
        }
    }
}
