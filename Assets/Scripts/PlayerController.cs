using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [SerializeField] float controlSpeed = 4f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 3f;

    [Header("Screen-position Based")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = -10f;

    [Header("Control-throw Based")]
    [SerializeField] float controlPitchFactor = -5f;
    [SerializeField] float controlRollFactor = -11f;
    float xThrow, yThrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation()
    {

        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll =  xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = controlSpeed * Time.deltaTime * xThrow;
        float rawNewXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawNewXPos, -xRange, xRange);

        float yOffset = controlSpeed * Time.deltaTime * yThrow;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);


        Vector3 moveVector = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
        transform.localPosition = moveVector;
    }

    public void OnPlayerDeath()
    {
        this.enabled = false;
    }
}
