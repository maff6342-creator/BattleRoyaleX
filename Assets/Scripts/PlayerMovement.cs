
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 180f;

    void Update()
    {
        float move = Input.GetAxis("Vertical");
        float turn = Input.GetAxis("Horizontal");

        transform.Rotate(
            0,
            turn * rotationSpeed * Time.deltaTime,
            0
        );

        transform.Translate(
            Vector3.forward * move * speed * Time.deltaTime
        );
    }
}
