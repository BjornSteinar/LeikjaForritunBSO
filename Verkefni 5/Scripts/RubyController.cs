using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class RubyController : MonoBehaviour
{
    //speed settur sem hraði character sem er jafnt og 3.0f
    public float speed = 3.0f;
    public float jumpSpeed = 3.0f;
    //sett Rigidbody2D og horizontal og vertical sem float
    public Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    //Animator settur og áttin sem Ruby er að horfa
    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);
    //sækt í projectilePrefab í unityEditor
    public GameObject projectilePrefab;
    //sækt í hitEffect og launchEffect particle systemin
    public ParticleSystem hitEffect;
    public ParticleSystem launchEffect;
    //sett Audiosource og cogClip, hitClip sækt í UnityEditor
    private AudioSource audioSource;
    public AudioClip cogClip;
    public AudioClip hitClip;
    public TextMeshProUGUI scoreCount;
    int score = 0;

    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(true);
        //þegar sena byrjar er sækt i Rigidbody2D, Animator og AudioSource frá Ruby og currentHealth set sem maxHealth
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();
        scoreCount.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //horizontal og vertical input náð í sem er left arrow og right arrow
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Jump");
        //breytt er move í horizontal og vertical vector2
        Vector2 move = new Vector2(horizontal, vertical);
        //ef ýtt er á upp eða til hliðar er látið Ruby horfa í þá átt 
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
        //og breytt er look x og look y í lookDirection x og y og speed set sem move.magnitude
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        if (Input.GetKeyDown(KeyCode.C))
        {
            panel.SetActive(false);
            Launch();
        }
    }

    void FixedUpdate()
    {
        //hér er sett saman speed horizontal og time.deltatime til að hreyfa karakter þegar ýtt er vinstri hægri eða upp og niður
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        //hér er hreyft
        rigidbody2d.MovePosition(position);
    }

    //SceneChangeMenu hlaðar senu 0
    public void SceneChangeMenu()
    {
        SceneManager.LoadScene(0);
    }
    //SceneChangeMenu hlaðar senu 2
    public void SceneChangeEnd()
    {
        SceneManager.LoadScene(2);
    }
    //spilar AudioClip
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            score -= 1;
            scoreCount.text = "Score: " + score.ToString();
            if (score < 0)
            {
                SceneChangeMenu();
            }
        }
        if (other.gameObject.CompareTag("Collectable"))
        {
            score += 1;
            scoreCount.text = "Score: " + score.ToString();
            Destroy(other.gameObject);
            if (score >= 10)
            {
                SceneChangeEnd();
            }
        }
    }

    public void Launch()
    {
            //þá er Instantiateað projectilið og launchEffect particle systemið
            GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
            Instantiate(launchEffect, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
            //sækt er í Projectile component og Launch tekur inn lookDirection og afl
            Projectile projectile = projectileObject.GetComponent<Projectile>();
            projectile.Launch(lookDirection, 300);
            //kveikir á launch animation
            animator.SetTrigger("Launch");
            //spilar cogClip 
            PlaySound(cogClip);
    }

    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (ground.gameObject.CompareTag("Ground"))
    //    {
    //        grounded = true;
    //    }
    //}
    //private void OnCollisionExit2D(Collision2D other)
    //{
    //    if (ground.gameObject.CompareTag("Ground"))
    //    {
    //        grounded = false;
    //    }
    //}

    //public bool isGrounded()
    //{
    //    if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}
    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    //}
}
