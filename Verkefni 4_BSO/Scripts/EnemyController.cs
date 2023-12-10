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
    //hér er skilgreint animator sem Animator og broken sem bool = true.
    Animator animator;
    bool broken = true;
    //hér er public ParticleSystem smokeEffect og hitEffect sem kalla á tvö particle systems sem eru sett í unity editor
    public ParticleSystem smokeEffect;
    public ParticleSystem hitEffect;
    //hér er skilgreint audioSource sem AudioSource
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        //hér er sækt í Rigidbody2D, Animator og AudioSource frá Óvin prefabinu og breytt timer í changeTime.
        timer = changeTime;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //ef broken er ekki jafnt og false þá er farið út úr "If" yfirlýsinguni
        if (!broken)
        {
            return;
        }
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
        //ef broken er ekki jafnt og false þá er farið út úr "If" yfirlýsinguni
        if (!broken)
        {
            return;
        }
        //Position skilgreint sem staðsetning Óvin
        Vector2 position = rigidbody2d.position;
        //ef vertical er jafnt og True þá hreyfist Óvinurinn upp og niður
        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;

            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        //ef annars þá fer hann vinstri og hægri
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;

            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }
        //og breytt er staðsetningu Óvins
        rigidbody2d.MovePosition(position);
    }
    //ef klesst er á annan collider
    void OnCollisionEnter2D(Collision2D other)
    {
        //Sækt er í RubyController
        RubyController player = other.gameObject.GetComponent<RubyController>();
        //og ef RubyController er ekki jafnt og "null"
        if (player != null)
        {
            //Þá er dregið frá 1 frá currentHealth
            player.ChangeHealth(-1);
        }
    }

    
    public void Fix()
    { 
        //Stoppar hljóðið frá Óvininum
        audioSource.Stop();
        //býr til hitEffect particle systemið
        Instantiate(hitEffect, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
        //skilgreinir broken sem false
        broken = false;
        //slekkur á rigidbody2d
        rigidbody2d.simulated = false;
        //byrjar Fixed animationið
        animator.SetTrigger("Fixed");
        //stoppar smokeEffect particle systemið
        smokeEffect.Stop();
        //og bætir við fixedRobots tölunni
        RobotsFixed.instance.AddFixedRobot();
    }
}
