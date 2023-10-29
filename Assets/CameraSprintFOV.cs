using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Gameplay;
using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(PlayerInputHandler), typeof(AudioSource))]
public class CameraSprintFOV : MonoBehaviour
{
    [Header("Field Of View")]
    public float normalFOV;
    public float SprintingFOV;
    public float FOVChangeTime;
    public Camera PlayerCamera;
    public bool dynamicFOV;
    public bool IsGrounded { get; private set; }
    PlayerInputHandler m_InputHandler;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DynamicFOV();
    }

    void DynamicFOV()
    {
        bool isSprinting = m_InputHandler.GetSprintInputHeld();

        if(isSprinting == true)
        {
            PlayerCamera.fieldOfView = Mathf.Lerp(PlayerCamera.fieldOfView, SprintingFOV, FOVChangeTime * Time.deltaTime);
        }
        else if(IsGrounded)
        {
            PlayerCamera.fieldOfView = Mathf.Lerp(PlayerCamera.fieldOfView, normalFOV, FOVChangeTime * Time.deltaTime);
    }
    }
}
