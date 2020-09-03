using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Move : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI currentScore;
    public GameObject panel;
    public Rigidbody rb;
    private float MaxSpeed = 15f;
    public float currentSpeed;
    private float accel = 15f;
    private float jump = 4f;
    public bool isGrounded;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Podloga")
        {
            isGrounded = true;
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            panel.SetActive(true);
        }
    }


    void FixedUpdate()
    {
        Debug.Log(rb.velocity.magnitude);
        if (rb.velocity.magnitude <= MaxSpeed)
            rb.AddRelativeForce(Vector3.forward * accel);
        if(Input.GetKey(KeyCode.A))
        {
            rb.AddRelativeForce(Vector3.left * accel);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddRelativeForce(Vector3.right * accel);
        }
        score++;
        currentScore.text = score.ToString();
        
     }
    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            isGrounded = false;
        }
        if(this.transform.position.y < 0)
        {
            Destroy(this.gameObject);
            panel.SetActive(true);
        }
    }
}

