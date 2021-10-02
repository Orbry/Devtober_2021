using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peddle : MonoBehaviour
{
    public float speed;
    [Range(0.0f, 1.0f)]
    public float inertia;

    private Rigidbody2D m_RB;
    private Vector2 m_MoveLeft;
    private Vector2 m_MoveRight;

    private void Awake()
    {
        m_RB = GetComponent<Rigidbody2D>();
        m_MoveLeft = new Vector2(-speed, 0);
        m_MoveRight = new Vector2(speed, 0);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            m_RB.velocity = m_MoveLeft;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            m_RB.velocity = m_MoveRight;
        }
    }

    // Applying constant *drag* to slow down peddle after user releases movement keys
    // Note - can cause slow down of peddle on very low FPS even while user holds movement key
    private void FixedUpdate()
    {
        m_RB.velocity *= inertia;
    }
}
