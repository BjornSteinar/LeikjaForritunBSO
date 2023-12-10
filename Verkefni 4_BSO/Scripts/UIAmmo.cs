using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIAmmo : MonoBehaviour
{
    //teki� er inn ammoCount TMPGUI og set ammo sem int = 0 og set instance of UIAmmo
    public TextMeshProUGUI ammoCount;
    int ammo = 0;
    public static UIAmmo instance { get; private set; }

    void Awake()
    {
        //set er �etta sem instance
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //breytt er ammoCount � ": " + ammo.ToString();
        ammoCount.text = ": " + ammo.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddAmmo()
    {
        //b�tt er vi� 10 vi� ammo og breytt er ammoCount � ": " + ammo.ToString();
        ammo += 10;
        ammoCount.text = ": " + ammo.ToString();
    }
    //teki� fr� 1 fr� ammo og breytt er ammoCount � ": " + ammo.ToString();
    public void SubtractAmmo()
    {
        ammo -= 1;
        ammoCount.text = ": " + ammo.ToString();
    }

}
