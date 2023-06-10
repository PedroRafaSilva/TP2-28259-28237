using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierController : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidade de movimento das barreiras
    public float upperLimit = 1f; // Limite superior de movimento das barreiras
    public float lowerLimit = -1f; // Limite inferior de movimento das barreiras

    private bool movingUp = true; // Indica se a barreira está se movendo para cima ou para baixo

     private void Start()
    {
        // Define a direção inicial aleatoriamente
        movingUp = (Random.value > 0.5f);
    }

    private void Update()
    {

        // Verifica se a barreira está se movendo para cima ou para baixo
        if (movingUp)
        {
            // Move a barreira para cima
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            // Verifica se atingiu o limite superior
            if (transform.position.z >= upperLimit)
            {
                // Inverte a direção para baixo
                movingUp = false;
            }
        }
        else
        {
            // Move a barreira para baixo
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
            // Verifica se atingiu o limite inferior
            if (transform.position.z <= lowerLimit)
            {
                // Inverte a direção para cima
                movingUp = true;
            }
        }
    }
}
