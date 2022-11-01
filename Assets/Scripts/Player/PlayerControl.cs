using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControl : MonoBehaviour
{
    /// <summary>
    /// The player's movement speed.
    /// </summary>
    [SerializeField] private float speed = 5f;

    /// <summary>
    /// The direction in which the player is facing.
    /// </summary>
    private Vector2 _direction = Vector2.down;

    /// <summary>
    /// The player's rigidbody component.
    /// </summary>
    private Rigidbody2D _rb;

    /// <summary>
    /// The player's animator component.
    /// </summary>
    private Animator _anim;

    /// <summary>
    /// Initializes components and variables.
    /// </summary>
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    /// <summary>
    /// Checks for input to move and animate the player.
    /// </summary>
    void Update()
    {
        Vector2 dir = Vector2.zero;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            dir.y = 1f;
            _direction = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            dir.y = -1f;
            _direction = Vector2.down;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            dir.x = 1f;
            _direction = Vector2.right;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            dir.x = -1f;
            _direction = Vector2.left;
        }
        PlayAnimation(dir);

        _rb.velocity = dir.normalized * speed;
    }

    /// <summary>
    /// Animates the player.
    /// </summary>
    /// <param name="direction">The direction in which the player is facing.</param>
    private void PlayAnimation(Vector2 direction)
    {
        switch (direction.y)
        {
            case -1:
                _anim.Play("PlayerFrontWalk");
                break;
            case 1:
                _anim.Play("PlayerBackWalk");
                break;
            default:
                switch (direction.x)
                {
                    case -1:
                        _anim.Play("PlayerLeftWalk");
                        break;
                    case 1:
                        _anim.Play("PlayerRightWalk");
                        break;
                    default:
                        if (_direction == Vector2.right)
                        {
                            _anim.Play("PlayerRightIdle");
                        }
                        else if (_direction == Vector2.left)
                        {
                            _anim.Play("PlayerLeftIdle");
                        }
                        else if (_direction == Vector2.up)
                        {
                            _anim.Play("PlayerBackIdle");
                        }
                        else
                        {
                            _anim.Play("PlayerFrontIdle");
                        }

                        break;
                }
                break;
        }
    }
}