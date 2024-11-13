using UnityEngine;
using System.Collections;

public class FallingObject : MonoBehaviour
{
    public enum ObjectType { Zanahoria, Speed, Grow }
    public ObjectType objectType;
    public float fallSpeed = 2f;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

        if (transform.position.y < -5f) 
        {
            gameObject.SetActive(false);
        }
    }
    public void UpdateFallSpeed(float newFallSpeed)
    {
        fallSpeed = newFallSpeed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            PlayerMovement player = collision.GetComponent<PlayerMovement>();

            switch (objectType)
            {
                case ObjectType.Zanahoria:
                    //player.gameManager.Punto(); // Otorga el punto al jugador
                    player.PlayCollectSound();   // Reproduce el sonido
                    break;
                case ObjectType.Speed:
                    player.ApplySpeedEffect();
                    player.PlayCollectSound();
                    break;
                case ObjectType.Grow:
                    player.ApplyGrowEffect();
                    player.PlayCollectSound();
                    break;
            }

            gameObject.SetActive(false); 
        }
    }
}
