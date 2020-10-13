using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driving : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float currentbreakForce;
    private bool isBreaking;

   
    
    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;

    [SerializeField] private WheelCollider FrontLeftWheelCollider;
    [SerializeField] private WheelCollider FrontRightWheelCollider;
    [SerializeField] private WheelCollider RearRightWheelCollider;
    [SerializeField] private WheelCollider RearLeftWheelCollider;

     [SerializeField] private Transform FrontLeftWheelTransform;
    [SerializeField] private Transform FrontRightWheelTransform;
    [SerializeField] private Transform RearRightWheelTransform;
    [SerializeField] private Transform RearLeftWheelTransform;






    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
      
        
    }



    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor()
    {
        FrontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        FrontRightWheelCollider.motorTorque = verticalInput * motorForce;
        currentbreakForce = isBreaking ? breakForce : 0f;
        if (isBreaking)
        {
            ApplyBreaking();
        }
        else
        {
            ResetBreaking();
        }
    }

    

   private void ApplyBreaking()
   {
       FrontRightWheelCollider.brakeTorque = currentbreakForce;
       FrontLeftWheelCollider.brakeTorque = currentbreakForce;
       RearLeftWheelCollider.brakeTorque = currentbreakForce;
       RearRightWheelCollider.brakeTorque = currentbreakForce;
   }

   private void ResetBreaking()
   {
       FrontRightWheelCollider.brakeTorque = 0f;
        FrontLeftWheelCollider.brakeTorque = 0f;
        RearLeftWheelCollider.brakeTorque = 0f;
        RearRightWheelCollider.brakeTorque = 0f;
   }

   private void HandleSteering()
   {
       currentSteerAngle = maxSteerAngle * horizontalInput;
       FrontLeftWheelCollider.steerAngle = currentSteerAngle;
       FrontRightWheelCollider.steerAngle = currentSteerAngle;
       

   }

   private void UpdateWheels()
   {
       UpdateSingleWheel(FrontLeftWheelCollider, FrontLeftWheelTransform);
       UpdateSingleWheel(FrontRightWheelCollider, FrontRightWheelTransform);
       UpdateSingleWheel(RearLeftWheelCollider, RearLeftWheelTransform);
       UpdateSingleWheel(RearRightWheelCollider, RearRightWheelTransform);
   }



   private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
   {
       Vector3 pos;
       Quaternion rot
;      wheelCollider.GetWorldPose(out pos, out rot);
       wheelTransform.rotation = rot;
       wheelTransform.position = pos;
   }

   

  


   

}
