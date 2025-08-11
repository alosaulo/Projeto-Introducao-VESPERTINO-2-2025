using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Determinar controle do player
    //Pegar o rigidbody do player
    //Usar o rigidbody para controlar o player

    /*
     * W - para cima
     * S - para baixo
     * A - para esquerda
     * D - para direita
     */

    public float speed = 5.2f; // Velocidade do player

    public KeyCode upKey = KeyCode.W; // Tecla para mover para cima
    public KeyCode downKey = KeyCode.S; // Tecla para mover para baixo
    public KeyCode leftKey = KeyCode.A; // Tecla para mover para esquerda
    public KeyCode rightKey = KeyCode.D; // Tecla para mover para direita

    private Rigidbody2D rb; // Referência ao Rigidbody2D do player

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtém o Rigidbody2D do player
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = 0f; // Inicializa o movimento no eixo X
        float moveY = 0f; // Inicializa o movimento no eixo Y

        if (Input.GetKey(upKey)) 
        { 
            moveY = 1f; // Move para cima se a tecla de cima for pressionada
        }
        else if (Input.GetKey(downKey)) 
        { 
            moveY = -1f; // Move para baixo se a tecla de baixo for pressionada
        }

        if (Input.GetKey(rightKey))
        {
            moveX = 1f; // Move para direita se a tecla de direita for pressionada
        }
        else if (Input.GetKey(leftKey)) 
        { 
            moveX = -1f; // Move para esquerda se a tecla de esquerda for pressionada
        }

        Vector2 movement = new Vector2(moveX, moveY).normalized; 
        // Normaliza o vetor de movimento para evitar movimento
        // mais rápido na diagonal

        /*Vector2 movement;
        movement.x = moveX * speed;
        movement.y = moveY * speed;*/

        rb.linearVelocity = movement * speed; // Aplica a velocidade ao Rigidbody2D do player

        Debug.Log("Movement: " + movement); // Log do movimento para
                                            // depuração
    }
}
