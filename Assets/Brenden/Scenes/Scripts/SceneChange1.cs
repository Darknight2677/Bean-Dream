using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange1 : MonoBehaviour
{
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //if (collision.tag == "Player")
    //{
    //Debug.Log("Switch scene");
    //SceneManager.LoadScene("MainMenuScene");
    //}
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
        }
    }

}


