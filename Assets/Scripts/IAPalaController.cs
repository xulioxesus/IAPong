using UnityEngine;

public class IAPalaController : MonoBehaviour
{
    const float MAX_Y = 4.2f;
    const float MIN_Y = -4.2f;
    [SerializeField] GameObject pelota;

    [SerializeField] float speed = 7f;

    // Se invoca una vez por frame
    void Update()
    {
        if(pelota.activeSelf){
            if(pelota.transform.position.y > transform.position.y)
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            else if (pelota.transform.position.y < transform.position.y)
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            else{
                Debug.Log("Non mover");
                transform.Translate(Vector3.down * 0);
            }
            
        }
    }
}
