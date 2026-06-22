using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class turret_script : MonoBehaviour
{
    private Rigidbody rb;
    public Transform turret;
    float TurretInput;
    [SerializeField] private float TurretSpeed = 1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnAim(InputValue inputValue)
    {
        TurretInput = inputValue.Get<float>();
    }

    void Update()
    {
       
        if (transform.hasChanged ==  false)
        {
            AimTurret();
        }
       
    }

    private void AimTurret()
    {
        turret.Rotate(0, TurretInput * TurretSpeed * Time.deltaTime, 0);
    }
}
