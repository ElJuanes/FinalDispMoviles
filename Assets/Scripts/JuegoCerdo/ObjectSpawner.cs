using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public ObjectPool objectPool;
    public float spawnInterval = 1.5f;
    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0;
        }
    }

    private void SpawnObject()
    {
        GameObject obj = objectPool.GetPooledObject();

        if (obj != null)
        {
            float xPos = Random.Range(-2.7f, 2.7f);
            obj.transform.position = new Vector3(xPos, Camera.main.orthographicSize, 0);
            obj.SetActive(true);
        }
    }
}
