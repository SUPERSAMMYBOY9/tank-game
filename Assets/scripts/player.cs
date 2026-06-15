using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

[RequireComponent(typeof(Rigidbody))]
public class TankMovement : MonoBehaviour
{
    private Rigidbody rb; //adds the ridgedBody 
    public Transform shootPoint;
    public GameObject Bullet;
    public float fireRate = 1f;
    private float nextFireTime = 0f;

    Vector2 MoveInput; //lets the script know it needs to use the input  
    Vector2 LookInput;
    Vector2 AttackInput;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float RotationSpeed = 50f; //makes a variable that can be changed in the edditor 
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); //adds the ridged body
    }

    private void FixedUpdate() 
    {
        Walk();
        Rotate();
        //Shoot();
    }

    public void OnMove(InputValue value)
    {
        MoveInput = value.Get<Vector2>(); //makes the move input the imput thats added in the editor
    }

    public void OnLook(InputValue value) 
    { 
        LookInput = value.Get<Vector2>();    
    }

    public void OnShoot(InputValue Button)
    {
        AttackInput = Button.Get<Vector2>();
    }

    private void Walk() 
    { 
        //moves the object forward at the speed thats in the move speed variable when one of the movement inputs is pressed
        rb.MovePosition(rb.position + transform.forward *  MoveInput.y * moveSpeed * Time.fixedDeltaTime);
    }

    private void Rotate() 
    {
        if (MoveInput.y != 0f) //makes it so it only works when your moving
        { 
            float rotattionAmount = LookInput.x * RotationSpeed * Time.fixedDeltaTime; //this determins howmuch we turn  every frame
            Quaternion rot = Quaternion.Euler(0f , rotattionAmount, 0f); //this rotates the object
            rb.MoveRotation(rb.rotation * rot);
        }
    }

    private void Shoot(InputValue button) 
    {
        GameObject projectileClone = Instantiate(Bullet, shootPoint.position, Quaternion.Euler(0, 0, 90));
        nextFireTime = Time.time + fireRate;
    }

}

