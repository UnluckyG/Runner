using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject score;
    void Start()
    {
        Time.timeScale = 0;
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            score.SetActive(true);
            Time.timeScale = 1;
            this.gameObject.SetActive(false);
        }
    }
    
}
