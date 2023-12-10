using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    //ef labba� er inn� Trigger sem � �essu tilfelli er ska�asv��i�
    void OnTriggerStay2D(Collider2D other)
    {
        //�� er s�kt � RubyController
        RubyController controller = other.GetComponent<RubyController>();
        //og k�kt hvort a� RubyController se nokku� ekki "null"
        if (controller != null)
        {
            //og kalla� � ChangeHealth() til a� breyta "currentHealth" breytuni � Rubycontroller
            controller.ChangeHealth(-1);
        }
    }
}
