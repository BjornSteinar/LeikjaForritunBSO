using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    //sett up eru variables
    private Vector3 startPos;
    private float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        //startPos er sett sem staðsetning bakgrunnins
        startPos = transform.position;
        //repeatWidth er sett sem helmingur af vídd bakgrunnins
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        //ef x á bakgrunni verður minna en byrjunar punktur mínus helmingur vídd bakgrunns þá verður bakgrunnur sentur til baka
        if (transform.position.x < startPos.x - repeatWidth)
        {

            transform.position = startPos;
        }
    }
}
