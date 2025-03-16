using UnityEngine;
using UnityEngine.InputSystem;

public class turningScript : MonoBehaviour
{
    //serializedfield of inputaction and playerinput
    [SerializeField] private PlayerInput playerInput;
    private InputAction moveInput;
    private float rotationSpeed = 12f;
    private float rotationGoal = 0;
    private float currentRotation = 0;

    //awake function
    void Awake()
    {
        moveInput = playerInput.actions["Move"];
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = moveInput.ReadValue<Vector2>();
        if (move != Vector2.zero)
        {
            if (move.x > 0)
            {
                rotationGoal = 0;
            }
            else if (move.x < 0)
            {
                rotationGoal = 180;
            }
        }
        // Rotate using Rotate function
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime * (rotationGoal - currentRotation));
        currentRotation = transform.eulerAngles.y;
    }
    public void SetPlayerInput(PlayerInput pI)
    {
        playerInput = pI;
    }

}
