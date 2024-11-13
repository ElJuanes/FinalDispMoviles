using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public ObjectPool objectPool; // Referencia al ObjectPool
    public float spawnInterval = 2f; // Intervalo de tiempo para el spawn de los objetos
    private float timer;
    private float nextSpeedSpawnTime;
    private float nextGrowSpawnTime;
    public GameManager gameManager;

    void Start()
    {
        timer = spawnInterval;
        nextSpeedSpawnTime = Random.Range(20f, 30f); 
        nextGrowSpawnTime = Random.Range(40f, 60f);
    }

    void Update()
    {
        timer -= Time.deltaTime; // Reducir el temporizador cada cuadro

        if (timer <= 0f)
        {
            SpawnFallingObject(); // Cambiar de SpawnObject a SpawnFallingObject
            timer = spawnInterval; // Reiniciar el temporizador
        }

        nextSpeedSpawnTime -= Time.deltaTime; // Reducir el temporizador para Speed
        nextGrowSpawnTime -= Time.deltaTime;  // Reducir el temporizador para Grow

        // Si el temporizador de Speed llega a cero, spawn el objeto
        if (nextSpeedSpawnTime <= 0f)
        {
            SpawnSpeedObject();
            nextSpeedSpawnTime = Random.Range(20f, 30f); // Establecer un nuevo tiempo de spawn aleatorio
        }

        // Si el temporizador de Grow llega a cero, spawn el objeto
        if (nextGrowSpawnTime <= 0f)
        {
            SpawnGrowObject();
            nextGrowSpawnTime = Random.Range(20f, 30f); // Establecer un nuevo tiempo de spawn aleatorio
        }
    }
    void SpawnFallingObject()
    {
        // Obtener un objeto de cada pool
        GameObject fallingObject = objectPool.GetFallingObject();

        // Asegurarse de que el objeto esté inactivo al inicio
        fallingObject.SetActive(true);

        // Establecer una posición aleatoria para el objeto de zanahoria
        float xPos = Random.Range(-2.7f, 2.7f);
        fallingObject.transform.position = new Vector3(xPos, 5f, 0f);  // Posición aleatoria en X

        FallingObject fallingScript = fallingObject.GetComponent<FallingObject>();
        fallingScript.UpdateFallSpeed(gameManager.fallSpeed);
    }

    void SpawnSpeedObject()
    {
        GameObject speedObject = objectPool.GetSpeedObject();
        speedObject.SetActive(true);

        // Posición aleatoria para el objeto de Speed
        float xPos = Random.Range(-2.7f, 2.7f);
        speedObject.transform.position = new Vector3(xPos, 5f, 0f);  // Posición aleatoria en X
        FallingObject speedScript = speedObject.GetComponent<FallingObject>();
        speedScript.UpdateFallSpeed(gameManager.fallSpeed);
    }

    void SpawnGrowObject()
    {
        GameObject growObject = objectPool.GetGrowObject();
        growObject.SetActive(true);

        // Posición aleatoria para el objeto de Grow
        float xPos = Random.Range(-2.7f, 2.7f);
        growObject.transform.position = new Vector3(xPos, 5f, 0f);  // Posición aleatoria en X
        FallingObject growScript = growObject.GetComponent<FallingObject>();
        growScript.UpdateFallSpeed(gameManager.fallSpeed);
    }
}
