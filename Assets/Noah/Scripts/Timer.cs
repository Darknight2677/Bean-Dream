using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public bool runningTimer;
    public float currentTime;
    public float maxTime = 60;
    public GameObject spawnPoint;
    public GameObject mainPlayer;
    private Rigidbody2D rb2;

    public PlayerMovementCopy player;
    public EvanMovementScript evan;

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
        Debug.Log(currentTime);
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
        evan.healthBar.SetHealth(evan.maxHealth);
        evan.health = evan.maxHealth;
    }
}
