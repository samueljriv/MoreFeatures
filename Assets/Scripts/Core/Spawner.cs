using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public int MinSpawns = 0;
    public int MaxSpawns = 1;
    private int SpawnsToUse;
    public Vector3 RandomPoint()
    {
        if (gameObject == null) return Vector3.zero;
        Vector3 localRandomPoint = new Vector3(
            Random.Range(-0.5f, 0.5f),
            Random.Range(-0.5f, 0.5f),
            Random.Range(-0.5f, 0.5f)
        );

        Vector3 worldRandomPoint = gameObject.transform.TransformPoint(localRandomPoint);

        return worldRandomPoint;
    }

    
    void Start()
    {
        SpawnsToUse = Random.Range(MinSpawns, MaxSpawns);
        if (SpawnsToUse > 0)
        {
            for (int i = 1; i <= SpawnsToUse; i++) 
            {
                GameObject NewObject = Instantiate(ObjectToSpawn, RandomPoint(), Quaternion.identity);

            }
        }
        gameObject.SetActive(false); 
    }
}
