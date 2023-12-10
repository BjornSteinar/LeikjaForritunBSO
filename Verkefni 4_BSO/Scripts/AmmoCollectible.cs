using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCollectible : MonoBehaviour
{
    public AudioClip collectedClip;
    //�egar er snert Trigger sem � �essu tilfelli er Ammo safngripurinn
    void OnTriggerEnter2D(Collider2D other)
    {
        //�� er s�kt � Rubycontroller
        RubyController controller = other.GetComponent<RubyController>();

        //ef controller er ekki "null"
        if (controller != null)
        {
            //ef ammo er ekki meira enn max ammo
            if (controller.ammo < controller.maxAmmo)
            {
                //b�tir vi� 10 ammo
                controller.ChangeAmmo(10);
                //ey�ir safngripinum
                Destroy(gameObject);
                //og spilar svo "CollectedClip"
                controller.PlaySound(collectedClip);
            }
        }
    }
}
