using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneChange : MonoBehaviour
{
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //if (collision.tag == "Player")
    //{
    //Debug.Log("Switch scene");
    //SceneManager.LoadScene("MainMenuScene");
    //}
    //}

    public void BackMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }

}


