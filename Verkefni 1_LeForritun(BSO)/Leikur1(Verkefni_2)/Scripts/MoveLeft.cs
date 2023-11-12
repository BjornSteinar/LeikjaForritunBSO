using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveLeft : MonoBehaviour
{
    //Variables sett up
    private float speed = 30;
    private PlayerController playerControllerScript;
    private float leftBound = -15;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerController scripti� er s�kt fr� "Player"
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //ef gameOver fr� playerControllerScript er false �� hreyfist hluturinn sem �etta script er � til vinstri
        if(playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        //og �egar hluturinn fer yfir x:-15 �� ey�ileggst hann
        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
