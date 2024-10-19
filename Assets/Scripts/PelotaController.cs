using UnityEngine;

public class PelotaController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float force;

    // Se invoca una vez, después de que se crea el MonoBehaviour, antes de la primera ejecución de Update 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(1, 1) * force, ForceMode2D.Impulse);    
    }

    // Se invoca una vez por frame
    void Update()
    {
        
    }
}
