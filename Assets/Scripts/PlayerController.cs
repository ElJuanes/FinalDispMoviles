using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Posiciones fijas en el eje Y
    private float[] yPositions = { -4f, -3f, -2f };
    private int currentPositionIndex = 1;

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
}
