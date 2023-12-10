using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    //Gert er instance af UIHealthBar
    public static UIHealthBar instance { get; private set; }
    //teki� er inn Image sem mask og originalSize sem float
    public Image mask;
    float originalSize;

    void Awake()
    {
        //set er �etta sem instance
        instance = this;
    }
    void Start()
    {
        //breytt er � w�ddini � mask
        originalSize = mask.rectTransform.rect.width;
    }
    //SetValue tekur inn t�lu og tekur fr� horizontal st�r�inni af mask
    public void SetValue(float value)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }
}
