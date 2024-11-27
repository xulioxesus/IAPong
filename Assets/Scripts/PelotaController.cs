using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PelotaController : MonoBehaviour
{
    [SerializeField] float force;
    [SerializeField] float delay;
    [SerializeField] GameManager manager;

    const float MIN_ANG = 30f;
    const float MAX_ANG = 50f;
    const float MAX_Y = 2.5f;
    const float MIN_Y = -2.5f;

    Rigidbody2D rb;
    
    // Se invoca una vez, después de que se crea el MonoBehaviour, antes de la primera ejecución de Update 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        // Lanzamiento de la pelota
        //rb.AddForce(new Vector2(1, 1) * force, ForceMode2D.Impulse);    
        int direccionX = Random.Range(0, 2) == 0 ? -1 : 1;
        StartCoroutine(LanzarPelota(direccionX));
    }

    void Update() 
    {

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

        // Actualizamos el marcador y reiniciamos la pelota
        if (other.gameObject.tag == "Porteria2")
        {
            manager.AddPointP1();
            transform.position = new Vector3(0, 0, 0);
            rb.linearVelocity = Vector2.zero;
            StartCoroutine(LanzarPelota(1));
        }
        else if (other.gameObject.tag == "Porteria1")
        {
            manager.AddPointP2();
            transform.position = new Vector3(0, 0, 0);
            rb.linearVelocity = Vector2.zero;
            StartCoroutine(LanzarPelota(-1));
        }
    }

    // Corrutina que lanza la pelota hacia la dirección (X) indicada
    IEnumerator LanzarPelota(int direccionX)
    {
        // Esperamos un tiempo (delay) antes de lanzar la pelota
        yield return new WaitForSeconds(delay);

        // Cálculo de la posición vertical inicial
        float posY = Random.Range(MIN_Y, MAX_Y);
        transform.position = new Vector3(0, posY, 0);

        // Cálculo del ángulo de lanzamiento
        
        // Obtenemos un ángulo aleatorio entre MIN_ANG y MAX_ANG en grados
        float angulo = Random.Range(MIN_ANG, MAX_ANG);

        // Tenemos que convertir el ángulo obtenido a radianes para calcular el coseno y seno
        angulo *= Mathf.Deg2Rad;

        // Coordenada x del vector de impulso
        float x = Mathf.Cos(angulo) * direccionX; 

        // Coordenada y del vector de impulso
        int direccionY = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Mathf.Sin(angulo) * direccionY;
        
        // Aplicamos el impulso a la pelota
        Vector2 impulso = new Vector2(x, y);
        //rb.velocity = Vector2.zero;  // obsoleto desde Unity 6
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(impulso * force, ForceMode2D.Impulse);
    }
}
