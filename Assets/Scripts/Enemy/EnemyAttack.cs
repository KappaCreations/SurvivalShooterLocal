using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;


    Animator anim;
    GameObject[] player;
   // PlayerHealth[] playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;
    public int target;

    void Awake ()
    {
        player = GameObject.FindGameObjectsWithTag("Player");

        /*foreach (GameObject i in player)
        {
            i.GetComponent<PlayerHealth>();
        }*/


        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent <Animator> ();
    }


    void OnTriggerEnter (Collider other)
    {
       
        if(other.gameObject == player[0])
        {
            playerInRange = true;
            target = 0;
        }
        
        if(player.Length>1)
        { 
            if (other.gameObject == player[1])
            {
            playerInRange = true;
            target = 1;
            }
        }
    }


    void OnTriggerExit (Collider other)
    {
        if(other.gameObject == player[target] )
        {
            playerInRange = false;
        }
    }


    void Update ()
    {
        timer += Time.deltaTime;

        if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            Attack ();
        }

        if(player[target].GetComponent<PlayerHealth>().currentHealth <= 0)
        {
            anim.SetTrigger ("PlayerDead");
        }
    }


    void Attack ()
    {
        timer = 0f;

        if(player[target].GetComponent<PlayerHealth>().currentHealth > 0)
        {
            player[target].GetComponent<PlayerHealth>().TakeDamage (attackDamage);
        }
    }
}
