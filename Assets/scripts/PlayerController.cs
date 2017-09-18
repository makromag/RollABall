using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour{

    public float speed;
    private Vector3 position;

    private Rigidbody rb;
    private int count;
    public Text countText;
    public Text winText;

    private void Start()
    {
        position = new Vector3(0.04f, 0.5f, -2.81f);
        rb = GetComponent<Rigidbody>();
        count = 0;
        setCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            setCountText();
        }

        if (other.gameObject.CompareTag("Death"))
        {
            gameObject.transform.position = position;
            rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        }

        if (other.gameObject.CompareTag("Checkpoint"))
        {
            position = other.gameObject.transform.position + new Vector3(0.0f, 0.5f, 0.0f);
        }
    }

    void setCountText()
    {
        countText.text = "Count:" + count.ToString();
        if (count >= 10)
        {
            winText.text = "YOU WIN!!";
        }
    }
}