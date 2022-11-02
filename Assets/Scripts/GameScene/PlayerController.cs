using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private float _horizontalMove;

    private Rigidbody2D _rigidbody2D;
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _horizontalMove = Input.GetAxisRaw("Horizontal");

        LookAtDirection();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(_horizontalMove * speed * Time.deltaTime, _rigidbody2D.velocity.y);
    }

    void LookAtDirection()
    {
        Vector2 newScale = transform.localScale;

        if (_horizontalMove > 0)
        {
            newScale.x = 1;
        }
        else if (_horizontalMove < 0)
        {
            newScale.x = -1;
        }

        transform.localScale = newScale;
    }
}
