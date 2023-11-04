using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Búum til GameObject sem leitar af objectinu "player" og tengjum "Player Vehicle" við player variableið í Unity
    public GameObject player;
    // offset mun vera lagt á staðsetningu bílsins og mun þá myndavélin vera fyrir ofan bílin svo hægt er að sjá betur
    private Vector3 offset = new Vector3(0, 8, -13);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Og svo breytum við staðsetningu myndavélarinnar í sömu stöðu og "player"
        transform.position = player.transform.position + offset; 
    }
}
