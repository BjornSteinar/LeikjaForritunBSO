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
        //þegar leikur byrjar er sækt í playerController Scriptið frá "Player"
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        //svo er sett cameraSound sem AudioSource frá "Main Camera"
        cameraSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //ef gameover er true þá er tónlistin hætt
        if (playerControllerScript.gameOver == true)
        {
            cameraSound.Stop();
        }
    }
}
