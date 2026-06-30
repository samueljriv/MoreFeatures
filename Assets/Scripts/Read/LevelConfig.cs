using UnityEngine;

public class LevelConfig : MonoBehaviour
{
    // This shows up in the Unity Inspector for configuration
    [SerializeField] private float yAxisLimit = 10f;

    // This is the global tracker accessible by any script
    public static float CurrentYLimit { get; private set; }

    private void Awake()
    {
        // Copy the inspector value to the static variable when the scene loads
        CurrentYLimit = yAxisLimit;
    }
}
