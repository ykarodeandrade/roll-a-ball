using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour //classe base da unity
{
    int maxPlatform = 0;
    // variavel
    public float speed = 1;

    public TextMeshProUGUI pointsText;
    public GameObject winText;
    public int totalPoints;
    public float startTime = 100f;  // Starting time in seconds
    public TextMeshProUGUI timerText;

    private int points = 0;

    private Rigidbody rb; // como é private essa variavel é só dessa classe
    private float movementX;
    private float movementY;
    private float timeRemaining;

   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        points = 0;
        SetPointsText();
        winText.SetActive(false);
        timeRemaining = startTime;

    }

    private void FixedUpdate() // função chamada em um intervalo fixo
    {
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);

        timeRemaining -= Time.deltaTime;

        // Update the Text UI
        timerText.text = "Time Remaining: " + timeRemaining.ToString("F2");

        if (timeRemaining <= 0f)
        {
            SceneManager.LoadScene("gameover");  // Replace with your Dead-End Scene name
        }
    }

    void OnMove(InputValue movimentValue) // função chamada toda vez que o jogador apertar uma tecla de movimento
    {
        Vector2 movementVector = movimentValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            points = points + 1;
            SetPointsText();
            other.gameObject.SetActive(false);
            Debug.Log(points);
        }
    }

    void SetPointsText()
    {
        pointsText.text = "Points: " + points;
        if(points >= 10)
        {
            SceneManager.LoadScene("win");
            winText.SetActive(true);
        }
    }
}
