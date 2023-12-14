using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //skilgreint rigidbody2d sem Rigidbody2D
    Rigidbody2D rigidbody2d;

    //�egar prefabi� er kalla� � ��
    void Awake()
    {
        //er s�kt � Rigidbody af prefabinu
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //ef sta�setning � prefabinu er meira en 1000 �� er �v� eytt
        if (transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }
    //Launch tekur inn Vector 2 direction sem er �ttin sem spilari er a� sn�a og force sem er hve hart prefabinu er hent
    public void Launch(Vector2 direction, float force)
    {
        //svo er b�tt vi� afl � �� �tt sem veri� er a� horfa
        rigidbody2d.AddForce(direction * force);
    }
    //�egar prefabi� klessir � eitthva� me� collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            //og ey�ileggur projectile
            Destroy(gameObject);
        }
    }
}
