using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(PlayerSetup))]
[RequireComponent(typeof(PlayerShoot))]

public class PlayerController : MonoBehaviour
{
    PlayerHealth playerHealth;
    PlayerMotor playerMotor;
    PlayerSetup playerSetup;
    PlayerShoot playerShoot;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerMotor = GetComponent<PlayerMotor>();
        playerSetup = GetComponent<PlayerSetup>();
        playerShoot = GetComponent<PlayerShoot>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 inputDirection = GetInput();
        if (inputDirection.sqrMagnitude > 0.25f)
        {
            playerMotor.RotateChasis(inputDirection);
        }

        Vector3 turretDir = Utility.GetWorldPointFromScreenPoint(Input.mousePosition,playerMotor.turret.position.y)-playerMotor.turret.position;
        playerMotor.RotateTurret(turretDir);
    }

    private void FixedUpdate()
    {
        Vector3 inputDirection = GetInput();
        playerMotor.MovePlayer(inputDirection);
    }

    Vector3 GetInput()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Debug.Log(h+" "+v);
        return new  Vector3(h, 0,v);
    }

}
