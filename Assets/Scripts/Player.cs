using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 4f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(Camera.main.ScreenToWorldPoint(new Vector3(1, 0, 0)));
        HandleInput();
    }

    private void HandleInput()
    {
        float horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float verticalThrow = CrossPlatformInputManager.GetAxis("Vertical");

        if(horizontalThrow > 0 || horizontalThrow < 0)
        {
            float xOffset = speed * Time.deltaTime * horizontalThrow;
            float rawNewXPos = transform.localPosition.x + xOffset;
            float clamedXPos = Mathf.Clamp(rawNewXPos, -xRange, xRange);
            Vector3 moveVector = new Vector3(clamedXPos, transform.localPosition.y, transform.localPosition.z);
            transform.localPosition = moveVector;
        }

        if(verticalThrow > 0 || verticalThrow < 0)
        {
            float yOffset = speed * Time.deltaTime * verticalThrow;
            float rawYPos = transform.localPosition.y + yOffset;
            float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);
            Vector3 moveVector = new Vector3(transform.localPosition.x, clampedYPos, transform.localPosition.z);

            transform.localPosition = moveVector;
        }
    }
}
