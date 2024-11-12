using System.Collections;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public float fallSpeed = 2f;
    public GameObject zanahoria;

    private void Update()
    {
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
