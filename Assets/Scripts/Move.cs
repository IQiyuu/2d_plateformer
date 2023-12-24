using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 5f;

    [SerializeField] KeyManager km;

    void FixedUpdate()
    {
        float horizontalMove = 0;
        if (Input.GetKey(km.getKey("Left")))
            horizontalMove = -1f;
        if (Input.GetKey(km.getKey("Right")))
            horizontalMove = 1f;
        Vector2 move = new Vector2(horizontalMove, 0f);
        move *= speed * Time.deltaTime;

        GetComponent<Rigidbody2D>().MovePosition((Vector2)transform.position + move);
    }
}