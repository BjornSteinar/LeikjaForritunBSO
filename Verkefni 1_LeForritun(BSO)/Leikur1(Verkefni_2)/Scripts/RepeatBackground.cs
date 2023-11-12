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
        //startPos er sett sem sta�setning bakgrunnins
        startPos = transform.position;
        //repeatWidth er sett sem helmingur af v�dd bakgrunnins
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        //ef x � bakgrunni ver�ur minna en byrjunar punktur m�nus helmingur v�dd bakgrunns �� ver�ur bakgrunnur sentur til baka
        if (transform.position.x < startPos.x - repeatWidth)
        {

            transform.position = startPos;
        }
    }
}
