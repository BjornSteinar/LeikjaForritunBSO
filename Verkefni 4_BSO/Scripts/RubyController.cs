using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RubyController : MonoBehaviour
{
    //speed settur sem hra�i character sem er jafnt og 3.0f
    public float speed = 3.0f;
    // maxHealth og maxAmmo set og timeInvicible set sem 2 sek�ndur
    public int maxHealth = 5;
    public int maxAmmo = 999;
    public float timeInvincible = 2.0f;
    //health og ammo set sem currentAmmo/Health
    public int health { get { return currentHealth; } }
    int currentHealth;
    public int ammo { get { return currentAmmo; } }
    int currentAmmo;
    //isInvicible set sem bool og invicibleTimer set sem float
    bool isInvincible;
    float invincibleTimer;
    //sett Rigidbody2D og horizontal og vertical sem float
    public Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    //Animator settur og �ttin sem Ruby er a� horfa
    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);
    //s�kt � projectilePrefab � unityEditor
    public GameObject projectilePrefab;
    //s�kt � hitEffect og launchEffect particle systemin
    public ParticleSystem hitEffect;
    public ParticleSystem launchEffect;
    //sett Audiosource og cogClip, hitClip s�kt � UnityEditor
    private AudioSource audioSource;
    public AudioClip cogClip;
    public AudioClip hitClip;



    // Start is called before the first frame update
    void Start()
    {
        //�egar sena byrjar er s�kt i Rigidbody2D, Animator og AudioSource fr� Ruby og currentHealth set sem maxHealth
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        currentHealth = maxHealth;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //horizontal og vertical input n�� � sem er left arrow og right arrow
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        //breytt er move � horizontal og vertical vector2
        Vector2 move = new Vector2(horizontal, vertical);
        //ef �tt er � upp e�a til hli�ar er l�ti� Ruby horfa � �� �tt 
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
        //og breytt er look x og look y � lookDirection x og y og speed set sem move.magnitude
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);
        //ef isInvicible er true
        if (isInvincible)
        {
            //er l�kka� timerin um sek�ndu og ef hann er minni en n�ll �� er hann settur sem false
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
        //ef �tt er � C �� er kalla� � Launch
        if (Input.GetKeyDown(KeyCode.C))
        {
            Launch();
        }
        //ef �tt er � X �� er kasta� Raycast
        if (Input.GetKeyDown(KeyCode.X))
        {
            //ef raycast hittir hlut me� layer npc ��
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
            if (hit.collider != null)
            {
                //er hveikt � DisplayDialog
             NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
                if (character != null)
                {
                    if (character != null)
                    {
                        character.DisplayDialog();
                    }
                }
            }
        }
    }

    void FixedUpdate()
    {
        //h�r er sett saman speed horizontal og time.deltatime til a� hreyfa karakter �egar �tt er vinstri h�gri e�a upp og ni�ur
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;
        //h�r er hreyft
        rigidbody2d.MovePosition(position);
    }
    //ChangeHealth() tekur inn t�lu
    public void ChangeHealth(int amount)
    {
        //ef talan er minni en n�ll er teki� fr� health
        if (amount < 0)
        {
            //spila� er hit animation
            animator.SetTrigger("Hit");
            //ef isInvicible er true
            if (isInvincible)
                return;
            //breytt er isInvicible � true og breytt timer � timeInvicible
            isInvincible = true;
            invincibleTimer = timeInvincible;
            //og Instantiatea� er hitteffect og spila� hitClip
            Instantiate(hitEffect, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
            PlaySound(hitClip);
        }
        //set er current health og breytt healthbar
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
        //ef currentHealth er 0 �� er sl�kkt � rigidbody og breytt yfir � menu
        if (currentHealth is 0)
        {
            GetComponent<Rigidbody2D>().isKinematic = true;
            Invoke("SceneChangeMenu", 2);
        }
    }
    //ChangeAmmo tekur inn t�lu
    public void ChangeAmmo(int amount)
    {
        //ef tala er meiri en 0 �� er kveikt � AddAmmo()
        if(amount > 0)
        {
            UIAmmo.instance.AddAmmo();
        }
        //ef tala er meiri en 0 �� er kveikt � SubstractAmmo()
        if (amount < 0)
        {
            UIAmmo.instance.SubtractAmmo();
        }
        //b�tt vi� er t�luna � currentammo
        currentAmmo = Mathf.Clamp(currentAmmo + amount, 0, maxAmmo);
        
    }

    public void Launch()
    {
        //ef currentAmmo er meira en 0
        if (currentAmmo > 0)
        {
            //�� er Instantiatea� projectili� og launchEffect particle systemi�
            GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
            Instantiate(launchEffect, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
            //s�kt er � Projectile component og Launch tekur inn lookDirection og afl
            Projectile projectile = projectileObject.GetComponent<Projectile>();
            projectile.Launch(lookDirection, 300);
            //kveikir � launch animation
            animator.SetTrigger("Launch");
            //spilar cogClip og ChangeAmmo tekur inn -1
            PlaySound(cogClip);
            ChangeAmmo(-1);
        }
    }
    //SceneChangeMenu hla�ar senu 0
    public void SceneChangeMenu()
    {
        SceneManager.LoadScene(0);
    }
    //spilar AudioClip
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
