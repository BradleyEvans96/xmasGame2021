using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public Transform ceilingCheck;
    public Transform groundCheck;
    public LayerMask groundObjects;
    public float checkRadius;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private float moveDirection;
    private bool isJumping = false;
    private bool isGrounded;

    private int jumpCount;

    private int maxjumpCount = 1;

    SavePlayerPos playerPosData;

    public GameObject interactIcon;

    public GameObject pickupIcon;

    public bool loadPosition = false;
    private Vector2 boxSize = new Vector2(0.1f, 1f);
    private void Start()
    {
        jumpCount = maxjumpCount;
        interactIcon.SetActive(false);
        pickupIcon.SetActive(false);
    }

    // Awake is called after all objects are initialised. Called in a random order.
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // will look for a component on this GameObject (what the script is attached to) of type Rigidbody 2D
        if (loadPosition)
        {
            playerPosData = FindObjectOfType<SavePlayerPos>();
            playerPosData.PlayerPosLoad();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            checkInteraction();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            checkPickup();
        }

        // Get Inputs
        ProcessInputs();

        //Animate
        Animate();
    }

    // better for handling Physics, can be called multiple times per frame
    private void FixedUpdate()
    {
        // Check if grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects);
        if (isGrounded)
        {
            jumpCount = maxjumpCount;
        }
        // Move
        Move();
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            jumpCount = jumpCount - 1;
        }
        isJumping = false;
    }

    private void Animate()
    {
        if (moveDirection > 0 && !facingRight)
        {
            FlipCharacter();
        }
        else if (moveDirection < 0 && facingRight)
        {
            FlipCharacter();
        }
    }

    private void ProcessInputs()
    {
        moveDirection = Input.GetAxis("Horizontal"); // Scale of -1 -> 1
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            isJumping = true;
        }
    }

    private void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public void openInteractableIcon()
    {
        interactIcon.SetActive(true);
    }

    public void closeInteractableIcon()
    {
        interactIcon.SetActive(false);
    }

    public void openPickUpIcon()
    {
        pickupIcon.SetActive(true);
    }

    public void closePickUpIcon()
    {
        pickupIcon.SetActive(false);
    }

    private void checkInteraction()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, boxSize, 0, Vector2.zero);

        if (hits.Length > 0)
        {
            foreach (RaycastHit2D rc in hits)
            {
                if (rc.transform.GetComponent<Interactable>())
                {
                    rc.transform.GetComponent<Interactable>().Interact();
                    return;
                }
            }
        }
    }

    private void checkPickup()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, boxSize, 0, Vector2.zero);

        if (hits.Length > 0)
        {
            foreach (RaycastHit2D rc in hits)
            {
                if (rc.transform.GetComponent<Pickable>())
                {
                    rc.transform.GetComponent<Pickable>().Interact();
                    return;
                }
            }
        }
    }
}
