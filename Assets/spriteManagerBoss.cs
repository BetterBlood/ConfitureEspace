using UnityEngine;
using UnityEngine.InputSystem;

public class spriteManagerBoss : MonoBehaviour
{
   //[SerializeField] private GameObject spriteIdle;
    //[SerializeField] private GameObject spriteMoving;
    [SerializeField] private Animator spriteMovingAnimator;
    [SerializeField] private PlayerInput playerInput;
    private InputAction moveInput;
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
        if (moveInput.ReadValue<Vector2>() != Vector2.zero)
        {
            //spriteIdle.SetActive(false);
            spriteMovingAnimator.SetBool("isAttacking", true);
        }
        else
        {
            spriteMovingAnimator.SetBool("isAttacking", false);
        }

    }
}
