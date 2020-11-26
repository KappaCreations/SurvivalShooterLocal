using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth[] playerHealth;
    public float playerHealths;
	public float restartDelay = 5f;


    Animator anim;
	float restartTimer;


    void Awake()
    {
    playerHealth = GameObject.FindObjectsOfType<PlayerHealth>();
    anim = GetComponent<Animator>();
    }


    void Update()
    {
        int temp = 0;
        foreach(PlayerHealth i in playerHealth)
        {
            temp += i.currentHealth;
        }
        playerHealths = temp;
       
        Debug.Log(playerHealths);
        
        if (playerHealths <= 0)
        {
            anim.SetTrigger("GameOver");

			restartTimer += Time.deltaTime;

			/*if (restartTimer >= restartDelay) {
				Application.LoadLevel(Application.loadedLevel);
			}*/
        }
    }
}
