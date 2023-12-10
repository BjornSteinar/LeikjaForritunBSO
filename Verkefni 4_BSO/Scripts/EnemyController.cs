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
    //h�r er skilgreint animator sem Animator og broken sem bool = true.
    Animator animator;
    bool broken = true;
    //h�r er public ParticleSystem smokeEffect og hitEffect sem kalla � tv� particle systems sem eru sett � unity editor
    public ParticleSystem smokeEffect;
    public ParticleSystem hitEffect;
    //h�r er skilgreint audioSource sem AudioSource
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        //h�r er s�kt � Rigidbody2D, Animator og AudioSource fr� �vin prefabinu og breytt timer � changeTime.
        timer = changeTime;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //ef broken er ekki jafnt og false �� er fari� �t �r "If" yfirl�singuni
        if (!broken)
        {
            return;
        }
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
        //ef broken er ekki jafnt og false �� er fari� �t �r "If" yfirl�singuni
        if (!broken)
        {
            return;
        }
        //Position skilgreint sem sta�setning �vin
        Vector2 position = rigidbody2d.position;
        //ef vertical er jafnt og True �� hreyfist �vinurinn upp og ni�ur
        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;

            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        //ef annars �� fer hann vinstri og h�gri
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;

            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }
        //og breytt er sta�setningu �vins
        rigidbody2d.MovePosition(position);
    }
    //ef klesst er � annan collider
    void OnCollisionEnter2D(Collision2D other)
    {
        //S�kt er � RubyController
        RubyController player = other.gameObject.GetComponent<RubyController>();
        //og ef RubyController er ekki jafnt og "null"
        if (player != null)
        {
            //�� er dregi� fr� 1 fr� currentHealth
            player.ChangeHealth(-1);
        }
    }

    
    public void Fix()
    { 
        //Stoppar hlj��i� fr� �vininum
        audioSource.Stop();
        //b�r til hitEffect particle systemi�
        Instantiate(hitEffect, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
        //skilgreinir broken sem false
        broken = false;
        //slekkur � rigidbody2d
        rigidbody2d.simulated = false;
        //byrjar Fixed animationi�
        animator.SetTrigger("Fixed");
        //stoppar smokeEffect particle systemi�
        smokeEffect.Stop();
        //og b�tir vi� fixedRobots t�lunni
        RobotsFixed.instance.AddFixedRobot();
    }
}
