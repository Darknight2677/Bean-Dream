using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public bool runningTimer;
    public float currentTime;
    public float maxTime = 60;
    public GameObject spawnPoint;
    public GameObject mainPlayer;
    private Rigidbody2D rb2;

    public PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = maxTime;
        runningTimer = true;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        //Debug.Log(currentTime);
        if (currentTime <= 0)
        {
            runningTimer = false;
            rb2 = mainPlayer.GetComponent<Rigidbody2D>();
            rb2.velocity = new Vector2(0, 0);
            mainPlayer.transform.localPosition = spawnPoint.transform.localPosition;
            Restartlevel();
        }
    }

    public void Restartlevel()
    {
        currentTime = maxTime;
        runningTimer = true;
        player.healthBar.SetHealth(player.maxHealth);
        player.health = player.maxHealth;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
