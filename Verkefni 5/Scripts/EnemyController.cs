using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Hér er skilgreint hraði, vertical sem bool og changetime sem float = 3.0f.
    public float speed = 3.0f;
    public bool vertical;
    public float changeTime = 3.0f;
    //hér er skilgreint rigidbody2d sem Rigidbody2D, timer sem float og direction sem int = 1.
    Rigidbody2D rigidbody2d;
    float timer;
    int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        //hér er sækt í Rigidbody2D, Animator og AudioSource frá Óvin prefabinu og breytt timer í changeTime.
        timer = changeTime;
    }

    private void Update()
    {
        //timer er minnkaður hvert frame
        timer -= Time.deltaTime;
        //ef timer verður minna en 0 er breytt um átt og endurstilla Timer
        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }

    private void FixedUpdate()
    {
        //Position skilgreint sem staðsetning Óvin
        Vector2 position = rigidbody2d.position;
        //ef vertical er jafnt og True þá hreyfist Óvinurinn upp og niður
        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
        }
        //ef annars þá fer hann vinstri og hægri
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
        }
        //og breytt er staðsetningu Óvins
        rigidbody2d.MovePosition(position);
    }

}
