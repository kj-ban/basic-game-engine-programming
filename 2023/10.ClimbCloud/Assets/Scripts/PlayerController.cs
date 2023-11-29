using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private float _jumpForce = 680f;
    private Rigidbody2D _rigidbody;

    [SerializeField] private float _walkForce = 30f;
    [SerializeField] private float maxWalkSpeed = 2f;

    [SerializeField] private Rigidbody2D _rigidbodyTest;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(transform.up * _jumpForce);
        }

        int dir = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dir = -1;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            dir = 1;
        }

        float speedX = Mathf.Abs(_rigidbody.velocity.x);
        if (speedX < maxWalkSpeed)
        {
            _rigidbody.AddForce(transform.right * dir * _walkForce);
        }

        if (dir != 0)
        {
            transform.localScale = new Vector3(dir, 1, 1);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // _rigidbodyTest.AddForce(_rigidbodyTest.transform.up * _jumpForce);
            _rigidbodyTest.velocity = new Vector2(0f, 10f);
        }
    }
}
