using UnityEngine;

public class QuadradoBehaviour : MonoBehaviour
{
    public GameObject tiroPrefab; // Prefab do tiro

    public float tiroInterval = 0.5f; // Intervalo entre tiros em segundos
    float timerTiro; // Temporizador para controlar o intervalo de tiro

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timerTiro >= tiroInterval) 
        { 
            GameObject tiro = Instantiate
                                (tiroPrefab, transform.position, Quaternion.identity);
            
            Rigidbody2D tiroRb = tiro.GetComponent<Rigidbody2D>();
            
            Transform playerPosition = 
                GameObject.FindGameObjectWithTag("Player").transform;
            
            Vector3 direcaoTiro = playerPosition.position - transform.position;

            tiroRb.linearVelocity = direcaoTiro * 5f;
            
            timerTiro = 0; // Reseta o temporizador após disparar
        }
        // Incrementa o temporizador com o tempo desde o último frame
        timerTiro += Time.deltaTime; 
    }
}
