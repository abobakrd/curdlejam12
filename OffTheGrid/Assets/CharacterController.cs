using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // player input
    float xAxis;
    float yAxis;

    // other components
    Animator anim;
    private Rigidbody2D _rb2D;

    // editor values for physics
    public float _climbSpeed = 2f;
    public float runSpeed = 2f;
    public float jumpForce = 2f;

    // player states
    private bool _isGrounded;
    private bool _isClimbing;
    private bool _isJumping;

    // Camera
    private Camera _camera;
    private CameraFollow _cameraFollow;

    // other
    private float _screenYMiddle;
    private Vector3 _screenCenter;
    private float _yCenter;

    private string _currState;

    // animator states
    private const string ANIM_IDLE = "Character Player - Idle";
    private const string ANIM_RUNNING = "Character Player - Running";
    private const string ANIM_JUMPING = "Character Player - Jumping";
    private const string ANIM_CLIMB_UP = "Character Player - Climb Up";
    private const string ANIM_CLIMB_DOWN = "Character Player - Climb Down";
    private const string ANIM_CLIMB_IDLE = "Character Player - Climb Idle";

    void Awake()
    {
        _camera = Camera.main;
        _rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        _screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 4);
    }

    void Start()
    {
        _cameraFollow = _camera.GetComponent<CameraFollow>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ladder")
        {
            _isClimbing = true;
            Debug.Log("Triggered Ladder");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ladder") _isClimbing = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            _isGrounded = true;
            Debug.Log("Collided with Ground");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // make camera follow player in Y pos if player is above half the height of the screen
        _yCenter = _camera.ScreenToWorldPoint(_screenCenter).y;
        _cameraFollow.AirCamOn();

        // Running movement
        xAxis = Input.GetAxis("Horizontal");
        yAxis = Input.GetAxis("Vertical");

        transform.Translate(xAxis * runSpeed * Time.deltaTime, 0, 0);

        if (_isGrounded && !_isClimbing)
        {
            if (xAxis > 0)
            {
                normalizeScaleX();
                AnimState(ANIM_RUNNING);
            }
            else if (xAxis < 0)
            {
                invertScaleX();
                AnimState(ANIM_RUNNING);
            }
            else
            {
                AnimState(ANIM_IDLE);
            }
        }

        // Climbing movement
        if (_isClimbing)
        {
            if (yAxis > 0) AnimState(ANIM_CLIMB_UP); else if (yAxis < 0)  AnimState(ANIM_CLIMB_DOWN); else AnimState(ANIM_CLIMB_IDLE);
            _rb2D.isKinematic = true;
            transform.Translate(xAxis * runSpeed * Time.deltaTime, yAxis * _climbSpeed * Time.deltaTime, 0);
        }
        else
        {
            if (_rb2D.isKinematic) _rb2D.isKinematic = false;
        }

        // Jumping movement
        if (Input.GetKeyDown(KeyCode.Space) && (_isGrounded || _isClimbing))
        {
            _isGrounded = false;
            _rb2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            AnimState(ANIM_JUMPING);
        }
    }

    void invertScaleX()
    {
        if (transform.localScale.x != -1) transform.localScale = new Vector3(-1, 1, 1);
    }

    void normalizeScaleX()
    {
        if (transform.localScale.x != 1) transform.localScale = new Vector3(1, 1, 1);
    }

    // animation
    void AnimState(string newState)
    {
        if (_currState == newState) return;

        anim.Play(newState);

        _currState = newState;
    }
}