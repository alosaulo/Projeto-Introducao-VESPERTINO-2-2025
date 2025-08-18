using UnityEngine;

public class QuadradoBehaviour : MonoBehaviour
{
    public AudioClip[] audioTiros; // Array de clipes de áudio para os tiros
    private AudioSource audioSource; //Componente de áudio para tocar os sons

    public GameObject tiroPrefab; // Prefab do tiro
    public float tiroSpeed; // Velocidade do tiro
    public float tiroInterval = 0.5f; // Intervalo entre tiros em segundos
    float timerTiro; // Temporizador para controlar o intervalo de tiro

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Obtém o componente AudioSource
    }

    // Update is called once per frame
    void Update()
    {
        if(timerTiro >= tiroInterval) 
        {
            int randomIndice = Random.Range(0, audioTiros.Length);

            audioSource.PlayOneShot(audioTiros[randomIndice]);

            GameObject tiro = Instantiate
                                (tiroPrefab, transform.position, Quaternion.identity);
            
            Rigidbody2D tiroRb = tiro.GetComponent<Rigidbody2D>();
            
            Transform playerPosition = 
                GameObject.FindGameObjectWithTag("Player").transform;
            
            Vector3 direcaoTiro = playerPosition.position - transform.position;

            tiroRb.linearVelocity = direcaoTiro.normalized * tiroSpeed;
            
            timerTiro = 0; // Reseta o temporizador após disparar
        }
        // Incrementa o temporizador com o tempo desde o último frame
        timerTiro += Time.deltaTime; 
    }
}
