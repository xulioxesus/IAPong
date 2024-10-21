using UnityEngine;

public class GameManager : MonoBehaviour
{
    int p1Score;
    int p2Score;

    public void AddPointP1()
    {
        p1Score++;
    }

    public void AddPointP2()
    {
        p2Score++;
    }

    // Se invoca una vez, después de que se crea el MonoBehaviour, antes de la primera ejecución de Update 
    void Start()
    {
        
    }

    // Se invoca una vez por frame
    void Update()
    {
        
    }
}
