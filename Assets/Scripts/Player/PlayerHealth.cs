using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    public dramaticZoom dramaticZoom;

    public cameraShake cameraShake;
    
    Animator anim;
    AudioSource playerAudio;
    PlayerMovement playerMovement;
    PlayerShooting playerShooting;
    bool isDead;
    bool damaged;
    
    [SerializeField]
    public float slowdownFactor;
    
    [SerializeField]
    public float slowdownTime;

    [SerializeField]
    public float zoomIntensity;

    void Awake ()
    {
        anim = GetComponent <Animator> ();
        playerAudio = GetComponent <AudioSource> ();
        playerMovement = GetComponent <PlayerMovement> ();
        playerShooting = GetComponentInChildren <PlayerShooting> ();
        currentHealth = startingHealth;
    }


    void Update ()
    {
        if(damaged)
        {
            
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }


    public void TakeDamage (int amount)
    {
        damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;

        playerAudio.Play ();
        
        StartCoroutine(cameraShake.Shake(.15f, .6f));
        
        if (currentHealth <= 0 && !isDead)
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;
        StartCoroutine(BulletTime());
        
        StartCoroutine(dramaticZoom.DramaticZoom(slowdownTime,zoomIntensity));
        
        playerShooting.DisableEffects ();

       // anim.SetTrigger ("Die");

        playerAudio.clip = deathClip;
        playerAudio.Play ();

        playerMovement.enabled = false;
        playerShooting.enabled = false;
    }


   /* public void RestartLevel ()
    {
        SceneManager.LoadScene (0);
    }*/

    private IEnumerator BulletTime()
    {
        Time.timeScale = slowdownFactor;
        yield return new WaitForSecondsRealtime(slowdownTime);
        Time.timeScale = 1f;
    }

   



}
