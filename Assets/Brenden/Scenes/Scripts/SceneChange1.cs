﻿using System.Collections;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }


}

