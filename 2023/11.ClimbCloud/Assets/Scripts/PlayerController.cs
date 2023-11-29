using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    private float _jumpForce = 680f;
    private Rigidbody2D _rigidbody;

    [SerializeField] private float _walkForce = 30f;
    [SerializeField] private float maxWalkSpeed = 2f;

    [SerializeField] private Rigidbody2D _rigidbodyTest;

    private Animator _animator; 

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private float threshold = 0.2f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            _rigidbody.AddForce(transform.up * _jumpForce);
            _animator.SetTrigger("jumpTrigger");
        }
  
        int dir = 0;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.acceleration.x < -threshold)
        {
            dir = -1;
        }

        if (Input.GetKey(KeyCode.RightArrow)  || Input.acceleration.x > threshold)
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

        _animator.speed = speedX / 2.0f;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // _rigidbodyTest.AddForce(_rigidbodyTest.transform.up * _jumpForce);
            _rigidbodyTest.velocity = new Vector2(0f, 10f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collison)
    {
        Debug.Log("End");

        SceneManager.LoadScene("ClearScene");
    }
}
