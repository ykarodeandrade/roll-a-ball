using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour //classe base da unity
{
    // variavel
    public float speed = 1;

    public TextMeshProUGUI pointsText;
    public GameObject winText;
    public int totalPoints;

    private int points = 0;

    private Rigidbody rb; // como é private essa variavel é só dessa classe
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        points = 0;
        SetPointsText();
        winText.SetActive(false);
    }

    private void FixedUpdate() // função chamada em um intervalo fixo
    {
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
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
            winText.SetActive(true);
        }
    }
}
