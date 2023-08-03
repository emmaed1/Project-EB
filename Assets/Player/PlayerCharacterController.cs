using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerCharacterController : MonoBehaviour
{
    [SerializeField] LayerMask groundLayers;
    public float runSpeed = 8f;
    public float jumpHeight = 3f;

    private float gravity = -50f;
    private CharacterController characterController;
    private Vector3 velocity;
    private bool isGrounded;
    private float horizontal;
    public GameObject RestartMenu;

    static public bool dialogue = false;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(horizontal, 0, 0);

        isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundLayers, QueryTriggerInteraction.Ignore);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }
        characterController.Move(move * runSpeed * Time.deltaTime);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        if (Input.GetButtonUp("Jump") && velocity.y > 0f)
        {
            velocity = new Vector3(0, velocity.y * 0.5f);
        }
        characterController.Move(velocity * Time.deltaTime);
        if (characterController.transform.position.y < -1)
        {
            RestartMenu.SetActive(true);
        }
    }
}
