using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int Points = 0;

    void Start()
    {
        Points = 0;    
    }

    public virtual void addPoints(int NewPoints)
    {
        Points += NewPoints;
    }
}
