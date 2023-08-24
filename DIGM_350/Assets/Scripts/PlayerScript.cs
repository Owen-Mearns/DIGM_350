using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class PlayerScript : MonoBehaviour
    {

        [Header("Jumping")]
        public KeyCode jumpKey = KeyCode.Space;
        public LayerMask whatIsGrounded;
        bool grounded;
        bool readyJump = true;

        public float acceleration, moveSpeed, playerDrag;
        private float horizontalInput, verticalInput;
        //[SerializeField] float maxAcceleration = 5f;

        public Transform orientation;

        Vector3 moveDirection;
        private Rigidbody rb;

        public static bool interacting = false;

        void Start() {
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Awake()
            {
                rb = GetComponent<Rigidbody>();
                rb.freezeRotation = true;
                rb.drag = playerDrag;
            }
        /*Checks raycast on click
         * Name of the object in hierarchy matters
         * static interacting is checked in all movement methods, true to lock
         */
        private void CheckInteract() {
            if (Input.GetMouseButtonDown(0)) {
                RaycastHit hit; 
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit)) {
                    if (hit.transform.name == "NPC") {
                        interacting = true;                     
                        hit.collider.GetComponent<DialogueTrigger>().TriggerDialogue();
                    }
                if (hit.transform.name == "Firewood") {
                    //Debug.Log("found wood HAHAHAHAH");
                    hit.collider.GetComponent<FirewoodScript>().CollectFirewood();
                }
            }
            }
        }

    private void Jump()
    {
        //reset y velocity

        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * 5.0f, ForceMode.Impulse);

    }

    private void ResetJump()
    {
        readyJump = true;
    }


    private void Update()
        {
        grounded = Physics.Raycast(transform.position, Vector3.down, 2.0f * .5f + .2f, whatIsGrounded);
        if (!interacting) {
                horizontalInput = Input.GetAxisRaw("Horizontal");
                verticalInput = Input.GetAxisRaw("Vertical");

            if (Input.GetKey(jumpKey) && readyJump && grounded)
            {
                Debug.Log("jump");
                readyJump = false;

                Jump();

                Invoke(nameof(ResetJump), 1.0f);
                
            }
            CheckInteract();
            }
        }

        private void FixedUpdate()
        {
            if (!interacting) {
                moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
                rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Force);
            }
        }
    }