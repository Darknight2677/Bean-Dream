using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //This is for the box collider to flip
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.active = true;
        }
        if (Input.GetMouseButtonDown(1))
        {
            gameObject.active = false;
        }
    }
}
