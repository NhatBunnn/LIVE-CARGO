using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float gravity = -9.81f;
    public InputAction moveAction;

    public Vector3 velocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        //Gravity(); Tàu đng trên vũ trụ nên k cần ok
    }

    //void Move()
    //{
    //    Vector2 input = moveAction.ReadValue<Vector2>();

    //    Vector3 move = transform.right * input.x + transform.forward * input.y;

    //    transform.Translate(move * speed * Time.deltaTime);
    //}

    void Move()
    {
        Vector2 input = moveAction.ReadValue<Vector2>();

        Vector3 move = transform.right * input.x
                     + transform.forward * input.y;

        transform.position += move * speed * Time.deltaTime;
    }

    void Gravity()
    {
        velocity.y += gravity * Time.deltaTime;
        transform.Translate(velocity * Time.deltaTime);
    }

    void OnDestroy()
    {
        moveAction.Disable();
    }
}
