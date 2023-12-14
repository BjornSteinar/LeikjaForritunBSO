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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            //og eyðileggur projectile
            Destroy(gameObject);
        }
    }
}
