using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Button : MonoBehaviour
{
    private void Update()
    {

    }
    //ef ýtt er á takka með þenna kóða í mun það byrja senu 1
    public void Byrja()
    {
        SceneManager.LoadScene(1);
    }
    //ef ýtt er á takka með þenna kóða í mun það byrja senu 0
    public void Endir()
    {
        SceneManager.LoadScene(0);
    }
}
