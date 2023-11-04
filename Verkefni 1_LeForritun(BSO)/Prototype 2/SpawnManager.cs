using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //h�r eru variables sett up
    public GameObject ObstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        //�egar leikur byrjar er s�kt � playerController Scripti� fr� "Player"
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        //og svo er byrja� "SpawnObstacle" k��inn
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObstacle()
    {
        //ef gameOver er false �� er spawna� hluti sem eru tengdir with "ObstaclePrefab" endalaust �anga� til a� gameOver ver�ur true
        if(playerControllerScript.gameOver == false)
        {
            Instantiate(ObstaclePrefab, spawnPos, ObstaclePrefab.transform.rotation);
        }
    }
}
