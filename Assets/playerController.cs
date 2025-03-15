using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private PlayerInput playerInput;

    private InputAction moveInput;
    //private InputAction lookInput;
    private CharacterController characterController;
    
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        moveInput = playerInput.actions["Move"];
        //lookInput = playerInput.actions["Look"];
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moveInput.ReadValue<Vector2>() != Vector2.zero)
        {
            // Move the player with the CharacterController move function
            characterController.Move(new Vector3(moveInput.ReadValue<Vector2>().x, 0, moveInput.ReadValue<Vector2>().y) * speed * Time.deltaTime);
        }
        
    }

    public PlayerInput GetPlayerInput()
    {
        return playerInput;
    }
}
