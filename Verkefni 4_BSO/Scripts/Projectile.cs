using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //skilgreint rigidbody2d sem Rigidbody2D
    Rigidbody2D rigidbody2d;

    //þegar prefabið er kallað á þá
    void Awake()
    {
        //er sækt í Rigidbody af prefabinu
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //ef staðsetning á prefabinu er meira en 1000 þá er því eytt
        if (transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }
    //Launch tekur inn Vector 2 direction sem er áttin sem spilari er að snúa og force sem er hve hart prefabinu er hent
    public void Launch(Vector2 direction, float force)
    {
        //svo er bætt við afl í þá átt sem verið er að horfa
        rigidbody2d.AddForce(direction * force);
    }
    //þegar prefabið klessir á eitthvað með collider
    void OnCollisionEnter2D(Collision2D other)
    {
        //þá er kíkt hvort það sem það klessti á var Óvinur og ef svo er þá er kallað á Fix()
        EnemyController e = other.collider.GetComponent<EnemyController>();
        if (e != null)
        {
            e.Fix();
        }
        //og hvort sem það var Óvinur eða ekki þá er prefabið eytt
        Destroy(gameObject);
    }
}
