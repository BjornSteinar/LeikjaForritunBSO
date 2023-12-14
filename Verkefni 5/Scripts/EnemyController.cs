using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //H�r er skilgreint hra�i, vertical sem bool og changetime sem float = 3.0f.
    public float speed = 3.0f;
    public bool vertical;
    public float changeTime = 3.0f;
    //h�r er skilgreint rigidbody2d sem Rigidbody2D, timer sem float og direction sem int = 1.
    Rigidbody2D rigidbody2d;
    float timer;
    int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        //h�r er s�kt � Rigidbody2D, Animator og AudioSource fr� �vin prefabinu og breytt timer � changeTime.
        timer = changeTime;
    }

    private void Update()
    {
        //timer er minnka�ur hvert frame
        timer -= Time.deltaTime;
        //ef timer ver�ur minna en 0 er breytt um �tt og endurstilla Timer
        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }

    private void FixedUpdate()
    {
        //Position skilgreint sem sta�setning �vin
        Vector2 position = rigidbody2d.position;
        //ef vertical er jafnt og True �� hreyfist �vinurinn upp og ni�ur
        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
        }
        //ef annars �� fer hann vinstri og h�gri
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
        }
        //og breytt er sta�setningu �vins
        rigidbody2d.MovePosition(position);
    }

}
