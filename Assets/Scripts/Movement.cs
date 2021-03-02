using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public Rigidbody rb;
    public float forwardForce = 10;
    public float initialVelocity = 10;
    public float impactForce = 1.2f;
    private Vector3 defaultPos;
    private Vector3 defaultEuler;

    public UIMenu UI;
    private void Awake()
    {
        defaultPos = transform.position;
        defaultEuler = transform.eulerAngles;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grounded") && GameManager.gameState == GameState.Playing)
        {
            GameManager.gameState = GameState.Over;
            UI.LostText();
            UI.Restart();
            UI.winText.SetActive(false);
        }
    }
    private void Update()
    {

        if (rb.position.y > 0 && GameManager.gameState == GameState.Playing)
        {
            rb.AddForce(transform.forward * Time.deltaTime * initialVelocity);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Agent"))
        {
            collision.rigidbody.AddForce(0, 0, transform.position.z * impactForce, ForceMode.Impulse);

        }
    }
    public void ResetPlayer()
    {
        transform.position = defaultPos;
        transform.eulerAngles = defaultEuler;
        GameManager.gameState = GameState.Playing;
    }

}
