using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControl : MonoBehaviour
{
    /// <summary>
    /// An instance of the player's movement component that is accessible by all classes.
    /// </summary>
    public static PlayerControl Instance = null;

    public GameObject InteractIcon;

    /// <summary>
    /// The player's movement speed.
    /// </summary>
    [SerializeField] private float _speed = 5f;

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
        if (!Instance)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    void Start()
    {
        InteractIcon.SetActive(false);
    }

    /// <summary>
    /// Checks for input to move the player.
    /// </summary>
    void FixedUpdate()
    {
        Vector2 dir = Vector2.zero;

        if (Input.GetKey(KeyCode.E))
        {
            CheckInteraction();
        }

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

        _rb.velocity = dir.normalized * _speed;
    }

    /// <summary>
    /// Returns the direction in which the player is facing.
    /// </summary>
    /// <returns>Player direction.</returns>
    public Vector2 GetDirection() => _direction;

    public void OpenInteractableIcon() => InteractIcon.SetActive(true);

    public void CloseInteractableIcon() => InteractIcon.SetActive(false);

    private void CheckInteraction()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, new Vector2(0.1f, 1f), 0, 
            Vector2.zero);
        
        if (hits.Length > 0)
        {
            foreach (var rc in hits)
            {
                if (rc.transform.GetComponent<Interactable>())
                {
                    rc.transform.GetComponent<Interactable>().Interact();
                }
            }
        }
    }
}