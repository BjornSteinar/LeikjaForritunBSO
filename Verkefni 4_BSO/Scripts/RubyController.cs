using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RubyController : MonoBehaviour
{
    //speed settur sem hraði character sem er jafnt og 3.0f
    public float speed = 3.0f;
    // maxHealth og maxAmmo set og timeInvicible set sem 2 sekóndur
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



    // Start is called before the first frame update
    void Start()
    {
        //þegar sena byrjar er sækt i Rigidbody2D, Animator og AudioSource frá Ruby og currentHealth set sem maxHealth
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        currentHealth = maxHealth;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //horizontal og vertical input náð í sem er left arrow og right arrow
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
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
        //ef isInvicible er true
        if (isInvincible)
        {
            //er lækkað timerin um sekóndu og ef hann er minni en núll þá er hann settur sem false
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
        //ef ýtt er á C þá er kallað á Launch
        if (Input.GetKeyDown(KeyCode.C))
        {
            Launch();
        }
        //ef ýtt er á X þá er kastað Raycast
        if (Input.GetKeyDown(KeyCode.X))
        {
            //ef raycast hittir hlut með layer npc þá
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
            if (hit.collider != null)
            {
                //er hveikt á DisplayDialog
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
        //hér er sett saman speed horizontal og time.deltatime til að hreyfa karakter þegar ýtt er vinstri hægri eða upp og niður
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;
        //hér er hreyft
        rigidbody2d.MovePosition(position);
    }
    //ChangeHealth() tekur inn tölu
    public void ChangeHealth(int amount)
    {
        //ef talan er minni en núll er tekið frá health
        if (amount < 0)
        {
            //spilað er hit animation
            animator.SetTrigger("Hit");
            //ef isInvicible er true
            if (isInvincible)
                return;
            //breytt er isInvicible í true og breytt timer í timeInvicible
            isInvincible = true;
            invincibleTimer = timeInvincible;
            //og Instantiateað er hitteffect og spilað hitClip
            Instantiate(hitEffect, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
            PlaySound(hitClip);
        }
        //set er current health og breytt healthbar
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
        //ef currentHealth er 0 þá er slökkt á rigidbody og breytt yfir í menu
        if (currentHealth is 0)
        {
            GetComponent<Rigidbody2D>().isKinematic = true;
            Invoke("SceneChangeMenu", 2);
        }
    }
    //ChangeAmmo tekur inn tölu
    public void ChangeAmmo(int amount)
    {
        //ef tala er meiri en 0 þá er kveikt á AddAmmo()
        if(amount > 0)
        {
            UIAmmo.instance.AddAmmo();
        }
        //ef tala er meiri en 0 þá er kveikt á SubstractAmmo()
        if (amount < 0)
        {
            UIAmmo.instance.SubtractAmmo();
        }
        //bætt við er töluna í currentammo
        currentAmmo = Mathf.Clamp(currentAmmo + amount, 0, maxAmmo);
        
    }

    public void Launch()
    {
        //ef currentAmmo er meira en 0
        if (currentAmmo > 0)
        {
            //þá er Instantiateað projectilið og launchEffect particle systemið
            GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
            Instantiate(launchEffect, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
            //sækt er í Projectile component og Launch tekur inn lookDirection og afl
            Projectile projectile = projectileObject.GetComponent<Projectile>();
            projectile.Launch(lookDirection, 300);
            //kveikir á launch animation
            animator.SetTrigger("Launch");
            //spilar cogClip og ChangeAmmo tekur inn -1
            PlaySound(cogClip);
            ChangeAmmo(-1);
        }
    }
    //SceneChangeMenu hlaðar senu 0
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
