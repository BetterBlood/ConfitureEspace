using UnityEngine;
using UnityEngine.InputSystem;

public class directionManager : MonoBehaviour
{

    [SerializeField] private PlayerInput playerInput;
    private InputAction lookInput;
    void Awake()
    {
        lookInput = playerInput.actions["Look"];
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lookInput.ReadValue<Vector2>() != Vector2.zero)
        {
            transform.forward = new Vector3(lookInput.ReadValue<Vector2>().x, 0, lookInput.ReadValue<Vector2>().y);
        }
    }
}
