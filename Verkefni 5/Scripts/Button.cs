using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Button : MonoBehaviour
{
    private void Update()
    {

    }
    //ef �tt er � takka me� �enna k��a � mun �a� byrja senu 1
    public void Byrja()
    {
        SceneManager.LoadScene(1);
    }
    //ef �tt er � takka me� �enna k��a � mun �a� byrja senu 0
    public void Endir()
    {
        SceneManager.LoadScene(0);
    }
}
