using Unity.VisualScripting;
using UnityEngine;

public class PelotaController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float force;

    const float MIN_ANG = 30f;
    const float MAX_ANG = 50f;

    // Se invoca una vez, después de que se crea el MonoBehaviour, antes de la primera ejecución de Update 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        // Lanzamiento de la pelota
        //rb.AddForce(new Vector2(1, 1) * force, ForceMode2D.Impulse);    
        int direccionX = Random.Range(0, 2) == 0 ? -1 : 1;
        LanzarPelota(direccionX);
    }

    // Se invoca en el momento en que el objeto colisiona con otro objeto con un Collider
    void OnCollisionEnter2D(Collision2D other)
    {
        string tag = other.gameObject.tag;

        if (tag == "Pala1" || tag == "Pala2")
        {
            Debug.Log($"Colisión con {tag}");
        }
    }

    // Se invoca en el momento en que el objeto atrviesa un Collider de tipo Trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Gol en {other.gameObject.tag}!!");
    }

    void LanzarPelota(int direccionX)
    {
        // obtenemos un ángulo aleatorio entre 30 y 50 grados
        float angulo = Random.Range(MIN_ANG, MAX_ANG);

        // tenemos que convertir el ángulo obtenido a radianes para calcular el coseno y seno
        angulo *= Mathf.Deg2Rad;

        // coordenada x del vector de impulso
        float x = Mathf.Cos(angulo) * direccionX; 

        // coordenada y del vector de impulso
        int direccionY = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Mathf.Sin(angulo) * direccionY;
        
        Vector2 impulso = new Vector2(x, y);
        rb.AddForce(impulso * force, ForceMode2D.Impulse);
    }
}
