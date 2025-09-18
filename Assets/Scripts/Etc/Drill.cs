using UnityEngine;

public class Drill : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
