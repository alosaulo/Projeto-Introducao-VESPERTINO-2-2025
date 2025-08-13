using UnityEngine;

public class QuadradoBehaviour : MonoBehaviour
{
    public GameObject tiroPrefab; // Prefab do tiro

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(tiroPrefab, transform.position, Quaternion.identity);
    }
}
