using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    //ef labbað er inní Trigger sem í þessu tilfelli er skaðasvæðið
    void OnTriggerStay2D(Collider2D other)
    {
        //þá er sækt í RubyController
        RubyController controller = other.GetComponent<RubyController>();
        //og kíkt hvort að RubyController se nokkuð ekki "null"
        if (controller != null)
        {
            //og kallað á ChangeHealth() til að breyta "currentHealth" breytuni í Rubycontroller
            controller.ChangeHealth(-1);
        }
    }
}
