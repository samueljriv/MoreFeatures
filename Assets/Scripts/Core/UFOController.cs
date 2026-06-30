using UnityEngine;

public class UFOController : Pawn
{
    private GameObject playerTarget;
    private Transform plrTf;
    private Transform tf;
    private Vector3 DesiredDirection;

    void Start()
    {
        playerTarget = GameObject.Find("Player");
        tf = GetComponent<Transform>();
        if (playerTarget == null || tf == null)
        {
            Destroy(gameObject); // No reason to keep if we cannot find the player or our transform. So we just delete it.
        }
    }

    void Update()
    {
        if (playerTarget != null)
        {
            plrTf = playerTarget.GetComponent<Transform>();
            if (plrTf == null)
            {
                Destroy(gameObject); // Ditto previous
            }
            DesiredDirection = (plrTf.position - tf.position).normalized;
            base.MoveDirectly(DesiredDirection);
        }   
        else
        {
            Destroy(gameObject); 
        }     
    }
}
