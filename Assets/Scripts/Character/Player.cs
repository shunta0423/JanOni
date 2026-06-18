using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    [Header("Player")]
    public bool isLocalPlayer;

    [Header("Status")]
    public int score = 25000;
    public bool isDealer;
    public bool isOni;

    [Header("Mahjong")]
    public Hand Hand { get; private set; }

    [SerializeField]
    private HandView handView;

    [Header("Movement")]
    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private float jumpHeight = 2f;

    [SerializeField]
    private float gravity = -9.81f;

    [Header("Camera")]
    [SerializeField]
    private Transform cameraPivot;

    [SerializeField]
    private Camera playerCamera;
    private float mouseSensitivity = 100f;

    private CharacterController controller;

    private float verticalVelocity;
    private float xRotation;

    //public  Animator animator;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();

        Hand = new Hand();
    }

    private void Start()
    {
        //playerCamera.gameObject.SetActive(isLocalPlayer);
        //handView.gameObject.SetActive(isLocalPlayer);
        playerCamera.gameObject.SetActive(true);
        handView.gameObject.SetActive(true);

        //animator = GetComponent<Animator>();
    }

    public void RefreshHand()
    {
        Hand.Sort();
        handView.UpdateView(Hand);
    }

    public void Draw(PaiType tile)
    {
        Hand.Add(tile);
        RefreshHand();
    }

    public void Discard(PaiType tile)
    {
        Hand.Remove(tile);
        RefreshHand();
    }

    private void Update()
    {
        //if (!isLocalPlayer)
        //    return;

        Move();
        Look();
    }

    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 move =
            transform.right * horizontal +
            transform.forward * vertical;

        move.Normalize();

        //if(move == Vector3.zero)
        //{
        //    animator.SetBool("is_running", false);
        //}
        //else
        //{
        //    animator.SetBool("is_running", true);
        //}

        if (controller.isGrounded)
        {
            if (verticalVelocity < 0)
                verticalVelocity = -2f;

            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity =
                    Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }

        verticalVelocity += gravity * Time.deltaTime;

        move.y = verticalVelocity;

        controller.Move(move * moveSpeed * Time.deltaTime);
    }
    private void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // ¶‰E
        transform.Rotate(Vector3.up * mouseX);

        // ã‰º
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -70f, 70f);

        cameraPivot.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}