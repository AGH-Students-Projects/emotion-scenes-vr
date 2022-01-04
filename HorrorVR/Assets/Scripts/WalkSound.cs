using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSound : MonoBehaviour
{
    CharacterController characterController;
    AudioSource walkAudio;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        walkAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded == true && characterController.velocity.magnitude > 2f && walkAudio.isPlaying == false)
        {
            walkAudio.Play();
        }
    }
}
