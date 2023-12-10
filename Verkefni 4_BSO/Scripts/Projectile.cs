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
    void OnCollisionEnter2D(Collision2D other)
    {
        //�� er k�kt hvort �a� sem �a� klessti � var �vinur og ef svo er �� er kalla� � Fix()
        EnemyController e = other.collider.GetComponent<EnemyController>();
        if (e != null)
        {
            e.Fix();
        }
        //og hvort sem �a� var �vinur e�a ekki �� er prefabi� eytt
        Destroy(gameObject);
    }
}
