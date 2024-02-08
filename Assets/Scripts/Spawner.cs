using UnityEngine;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    public struct SpawnableObject
    {
        public GameObject prefab;
        [Range(0f, 1f)]
        public float spawnChance;
    }

    public SpawnableObject[] objects;

    public float minSpawnrate = 1f;
    public float maxSpawnrate = 2f;

    private void Enable()
    {
        Invoke(nameof(Spawn), Random.Range(minSpawnrate, maxSpawnrate));
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        float SpawnChance = Random.value;

        foreach(var obj in objects)
        {
            if (SpawnChance < obj.spawnChance)
            {
                GameObject obstacle = Instantiate(obj.prefab);
                obstacle.transform.position += transform.position;
                break;
            }

            SpawnChance -= obj.spawnChance;
        }

        Invoke(nameof(Spawn), Random.Range(minSpawnrate, maxSpawnrate));
    }
}
