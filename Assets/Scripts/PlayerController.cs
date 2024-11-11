using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float[] yPositions = { -4f, -3f, -2f };
    private int currentPositionIndex = 1;
    private int lives = 2; // Inicializamos el jugador con 2 vidas

    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.W) && currentPositionIndex < yPositions.Length - 1)
        {
            currentPositionIndex++;
            MoveToPosition();
        }
        else if (Input.GetKeyDown(KeyCode.S) && currentPositionIndex > 0)
        {
            currentPositionIndex--;
            MoveToPosition();
        }
    }

    void MoveToPosition()
    {
        Vector3 newPosition = transform.position;
        newPosition.y = yPositions[currentPositionIndex];
        transform.position = newPosition;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            lives--; 

            if (lives <= 0)
            {
                Debug.Log("Game Over");
                // Holder de game over
            }
            else
            {
                Debug.Log("Vida restante: " + lives);
            }

        
            other.gameObject.SetActive(false);
        }
    }
}
