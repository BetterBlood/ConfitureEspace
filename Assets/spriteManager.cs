using UnityEngine;
using UnityEngine.InputSystem;

public class spriteManager : MonoBehaviour
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
        // get the normalized time from the animator
        float normalizedTime = spriteMovingAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime;
        if (moveInput.ReadValue<Vector2>() != Vector2.zero)
        {
            //spriteIdle.SetActive(false);
            spriteMovingAnimator.SetBool("isWalking", true);
        }
        else
        {
            spriteMovingAnimator.SetBool("isWalking", false);
        }

    }
}
