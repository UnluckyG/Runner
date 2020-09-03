using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void Update()
    {
        

        if (transform.position.z < Camera.main.transform.position.z - 50f)
        {
            Destroy(this.gameObject);
        }
    }
}
