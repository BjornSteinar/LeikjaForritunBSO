using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCollectible : MonoBehaviour
{
    public AudioClip collectedClip;
    //Þegar er snert Trigger sem í þessu tilfelli er Ammo safngripurinn
    void OnTriggerEnter2D(Collider2D other)
    {
        //Þá er sækt í Rubycontroller
        RubyController controller = other.GetComponent<RubyController>();

        //ef controller er ekki "null"
        if (controller != null)
        {
            //ef ammo er ekki meira enn max ammo
            if (controller.ammo < controller.maxAmmo)
            {
                //bætir við 10 ammo
                controller.ChangeAmmo(10);
                //eyðir safngripinum
                Destroy(gameObject);
                //og spilar svo "CollectedClip"
                controller.PlaySound(collectedClip);
            }
        }
    }
}
