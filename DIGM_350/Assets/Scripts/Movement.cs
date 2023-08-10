using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Movement : MonoBehaviour
    {
        public float acceleration, moveSpeed;
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
            }

        private void CheckInteract() {
            if (Input.GetMouseButtonDown(0)) {
                RaycastHit hit; 
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit)) {
                    if (hit.transform.name == "NPC") {
                        interacting = true;                     
                        hit.collider.GetComponent<NpcScript>().TriggerDialogue();
                        //Debug.Log("My object is clicked by mouse");
                    }
                }
            }
        }


        private void Update()
        {
            if (!interacting) {
                horizontalInput = Input.GetAxisRaw("Horizontal");
                verticalInput = Input.GetAxisRaw("Vertical");
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