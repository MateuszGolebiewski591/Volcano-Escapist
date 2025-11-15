using UnityEngine;

public class RisingLava : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;


    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * Time.deltaTime * speed;
    }
}
