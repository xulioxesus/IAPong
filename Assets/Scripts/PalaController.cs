using UnityEngine;

public class PalaController : MonoBehaviour
{
    const float MAX_Y = 4.2f;
    const float MIN_Y = -4.2f;

    [SerializeField] float speed = 7f;

    // Se invoca una vez, después de que se crea el MonoBehaviour, antes de la primera ejecución de Update 
    void Start()
    {

    }

    // Se invoca una vez por frame
    void Update()
    {
        if (CompareTag("Pala 1"))
        {
            Player1Movement();
        }
        else if (CompareTag("Pala 2"))
        {
            Player2Movement();
        }
    }


    // Movimiento de la pala del jugador 1
    void Player1Movement()
    {
        if (Input.GetKey("w") && transform.position.y < MAX_Y)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }

        if (Input.GetKey("s") && transform.position.y > MIN_Y)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }

    
    // Movimiento de la pala del jugador 2
    void Player2Movement()
    {
        if (Input.GetKey("up") && transform.position.y < MAX_Y)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }

        if (Input.GetKey("down") && transform.position.y > MIN_Y)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }
}
