using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    //Gert er instance af UIHealthBar
    public static UIHealthBar instance { get; private set; }
    //tekið er inn Image sem mask og originalSize sem float
    public Image mask;
    float originalSize;

    void Awake()
    {
        //set er þetta sem instance
        instance = this;
    }
    void Start()
    {
        //breytt er í wíddini á mask
        originalSize = mask.rectTransform.rect.width;
    }
    //SetValue tekur inn tölu og tekur frá horizontal stærðinni af mask
    public void SetValue(float value)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }
}
