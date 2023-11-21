using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMoveable
{
    [field:SerializeField] public float Speed { get; set; }
    public Vector3 Direction { get; set; }

    private Rigidbody rb;

    void Awake()
    {
        TryGetComponent(out rb);
    }

    void Update()
    {
        Move(Direction);   
    }

    public void Move(Vector3 direction)
    {
        Vector3 dir = new Vector3(direction.x, 0, direction.y);
        rb.position += dir.normalized * Speed * Time.deltaTime;

        if (dir.magnitude > 0)
        {
            float turnSpeed = 0.2f;
            rb.rotation = Quaternion.Slerp(rb.rotation, Quaternion.LookRotation(dir), turnSpeed);
        }
    }

}
