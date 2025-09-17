using UnityEngine;


public class Scrolling : MonoBehaviour
{
    [SerializeField]private float Speed = 2f;

    private void Update()
    {
        transform.Translate(Vector3.left * Speed * Time.deltaTime);
    }
}
