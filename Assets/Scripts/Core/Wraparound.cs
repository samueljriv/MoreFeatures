using UnityEngine;

public class Wraparound : MonoBehaviour
{
    private Transform tf;

    void Start()
    {
        tf = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        if (tf != null && tf.position.y > LevelConfig.CurrentYLimit)
        {
            tf.position = new Vector3(tf.position.x, LevelConfig.CurrentYLimit, tf.position.z);
        }
    }
}
