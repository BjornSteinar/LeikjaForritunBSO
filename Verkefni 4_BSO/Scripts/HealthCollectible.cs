using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    //s�kt er i Audioclip � unity editor
    public AudioClip collectedClip;

    //ef trigger er snert
    void OnTriggerEnter2D(Collider2D other)
    {
        //�� er s�kt � RubyController
        RubyController controller = other.GetComponent<RubyController>();
        //og ef RubyController er ekki jafnt og "null"
        if (controller != null)
        {
            //er k�kt hvort health er minna en maxHealth
            if(controller.health < controller.maxHealth)
            {
                //og ef svo er �� er b�tti vi� 1 vi� currentHealth
                controller.ChangeHealth(1);
                //eytt ver�ur safngripinum
                Destroy(gameObject);
                //og spila� ver�ur "collectedClip"
                controller.PlaySound(collectedClip);
            }
        }
    }
}
