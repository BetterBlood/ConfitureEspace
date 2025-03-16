using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class turningScriptEnemy : MonoBehaviour
{
    [SerializeField] Transform parentDirection;
    
    private float rotationSpeed = 12f;
    private float rotationGoal = 0;
    private float currentRotation = 0;
    private Vector3 move;


    //awake function
    void Awake()
    {
        //move = enemyBehaviour.GetDirection();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move = parentDirection.forward;
        if (move != Vector3.zero)
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


}
