using System.Collections;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject zanahoria;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        float fallSpeed = gameManager != null ? gameManager.fallSpeed : 2f; 
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        if (transform.position.y < -Camera.main.orthographicSize)
        {
            restartObj();
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();
            zanahoria.SetActive(false);
            GetComponent<Collider2D>().enabled = false;            
        }
    }
    private void restartObj()
    {
        zanahoria.SetActive(true);
        GetComponent<Collider2D>().enabled = true;
    }
}
