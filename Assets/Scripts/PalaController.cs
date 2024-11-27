using UnityEngine;

public class PalaController : MonoBehaviour
{
    const float MAX_Y = 4.2f;
    const float MIN_Y = -4.2f;

    [SerializeField] float speed = 7f;

    // Se invoca una vez por frame
    void Update()
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
}
