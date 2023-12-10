using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    //sækt er i Audioclip í unity editor
    public AudioClip collectedClip;

    //ef trigger er snert
    void OnTriggerEnter2D(Collider2D other)
    {
        //þá er sækt í RubyController
        RubyController controller = other.GetComponent<RubyController>();
        //og ef RubyController er ekki jafnt og "null"
        if (controller != null)
        {
            //er kíkt hvort health er minna en maxHealth
            if(controller.health < controller.maxHealth)
            {
                //og ef svo er þá er bætti við 1 við currentHealth
                controller.ChangeHealth(1);
                //eytt verður safngripinum
                Destroy(gameObject);
                //og spilað verður "collectedClip"
                controller.PlaySound(collectedClip);
            }
        }
    }
}
