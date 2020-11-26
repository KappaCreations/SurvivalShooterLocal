using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    GameObject[] player;
    Transform[] moves;
    //PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;
    public int target;
    

    void Awake ()
    {
        
        player = GameObject.FindGameObjectsWithTag ("Player");
        target = Random.Range(0,player.Length);
        //playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
        
    }


    void Update ()
    {
       


        if(enemyHealth.currentHealth > 0 && player[target].GetComponent<PlayerHealth>().currentHealth > 0)
        {
            nav.SetDestination (player[target].transform.position);
        }
        else
        {
            nav.enabled = false;
        }
    }
}
