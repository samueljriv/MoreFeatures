using UnityEngine;

public class Pickup : MonoBehaviour
{
    // Config
    public int PointAward = 100;
    public bool DestroyOnTouch = false;
    public LayerMask TargetLayers;
    private GameObject GameManObject;
    private GameManager gameManager;

    void Start()
    {
        GameManObject = GameObject.Find("GameManager");
        gameManager = GameManObject.GetComponent<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        ProcessImpact(other.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        ProcessImpact(collision.gameObject);
    }

    private void ProcessImpact(GameObject hitObject)
    {
        // Check if the object we rammed into belongs to the correct layer
        if (((1 << hitObject.layer) & TargetLayers) != 0)
        {
            gameManager.addPoints(PointAward);
        }
    }
}
