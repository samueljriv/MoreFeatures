using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Pawn : MonoBehaviour
{
    public float ThrustForce = 500.0f;
    public float PitchSpeed = 15.0f;
    public float YawSpeed = 15.0f;
    public float RollSpeed = 20.0f;

    public GameObject ProjectilePrefab;
    public Transform MuzzlePoint;

    protected Rigidbody Rigid;
    protected GameManager gameManager; 
    
    protected virtual void Start()
    {
        Rigid = GetComponent<Rigidbody>();
        gameManager = GameObject.FindFirstObjectByType<GameManager>();
        Rigid.useGravity = false;
    }

    protected virtual void Update()
    {
        
    }

    protected void MoveShip(float driving, float pitching, float yawing, float rolling)
    {
        Vector3 thrustDirection = transform.forward * driving * ThrustForce;
        Rigid.AddForce(thrustDirection, ForceMode.Force);

        Vector3 torqueDelta = new Vector3(pitching * PitchSpeed, yawing * YawSpeed, rolling * RollSpeed);
        Rigid.AddRelativeTorque(torqueDelta, ForceMode.Acceleration);
    }

    protected void MoveDirectly(Vector3 Direction)
    {
        Transform MovePoint = MuzzlePoint != null ? MuzzlePoint : transform;
        MovePoint.position = MovePoint.position + (Direction * ThrustForce * Time.deltaTime);
    }

    public virtual void Shoot()
    {
        if (ProjectilePrefab != null)
        {
            Transform spawnPoint = MuzzlePoint != null ? MuzzlePoint : transform;
            Instantiate(ProjectilePrefab, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Debug.LogWarning($"[Pawn] Cannot shoot because ProjectilePrefab is missing on {gameObject.name}!");
        }
    }
}
