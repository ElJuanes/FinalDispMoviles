using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public float fallSpeed = 2f;

    private void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        if (transform.position.y < -Camera.main.orthographicSize)
        {
            gameObject.SetActive(false);
        }
    }
}
