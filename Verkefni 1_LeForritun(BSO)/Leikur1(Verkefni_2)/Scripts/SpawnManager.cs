using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //hér eru variables sett up
    public GameObject ObstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        //þegar leikur byrjar er sækt í playerController Scriptið frá "Player"
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        //og svo er byrjað "SpawnObstacle" kóðinn
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObstacle()
    {
        //ef gameOver er false þá er spawnað hluti sem eru tengdir with "ObstaclePrefab" endalaust þangað til að gameOver verður true
        if(playerControllerScript.gameOver == false)
        {
            Instantiate(ObstaclePrefab, spawnPos, ObstaclePrefab.transform.rotation);
        }
    }
}
