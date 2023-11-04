using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // B�um til GameObject sem leitar af objectinu "player" og tengjum "Player Vehicle" vi� player variablei� � Unity
    public GameObject player;
    // offset mun vera lagt � sta�setningu b�lsins og mun �� myndav�lin vera fyrir ofan b�lin svo h�gt er a� sj� betur
    private Vector3 offset = new Vector3(0, 8, -13);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Og svo breytum vi� sta�setningu myndav�larinnar � s�mu st��u og "player"
        transform.position = player.transform.position + offset; 
    }
}
