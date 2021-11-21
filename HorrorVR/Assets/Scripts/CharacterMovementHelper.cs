using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CharacterMovementHelper : CharacterControllerDriver
{
   
    // Update is called once per frame
    void LateUpdate()
    {
        UpdateCharacterController();
    }
}
