using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{

    private Rigidbody playerRb;
    public Transform turret, chassis;
    public float moveSpeed = 100f;
    public float chassisRotateSpeed = 1f;
    public float turretRotateSpeed = 3f;
    

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void MovePlayer(Vector3 dir)
    {
        Vector3 moveDirection = dir * moveSpeed * Time.deltaTime;
        playerRb.velocity = moveDirection;
    }

    public void FaceDirection(Transform xform, Vector3 dir, float rotSpeed)
    {
        if (dir != Vector3.zero&&xform!=null)
        {
            Quaternion desiredRot = Quaternion.LookRotation(dir);
            xform.rotation = Quaternion.Slerp(xform.rotation,desiredRot,rotSpeed*Time.deltaTime);
        }
    }

    public void RotateChasis(Vector3 dir)
    {
        FaceDirection(chassis, dir, chassisRotateSpeed);
    }

    public void RotateTurret(Vector3 dir)
    {
        FaceDirection(turret,dir,turretRotateSpeed);
    }




}
