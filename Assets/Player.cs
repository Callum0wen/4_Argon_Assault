using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{

	[Tooltip("In ms^-1")] [SerializeField] float speed = 15f;

	[Tooltip("In m")] [SerializeField] float xRange = 6f;
	[Tooltip("In m")] [SerializeField] float yRange = 4f;

	[SerializeField] float positionPitchFactor = -5f;
	[SerializeField] float controlPitchFactor = -20f;
	[SerializeField] float positionYawFactor = 5f;
	[SerializeField] float controlRollFactor = -20f;

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
		float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
		float pitchDueToControlThrow = yThrow * controlPitchFactor;
		float pitch = pitchDueToControlThrow + pitchDueToPosition;

		float yaw = transform.localPosition.x * positionYawFactor;

		float roll = xThrow * controlRollFactor;

		transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
	}

	private void ProcessTranslation()
	{
		xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
		yThrow = CrossPlatformInputManager.GetAxis("Vertical");

		float xOffset = xThrow * speed * Time.deltaTime;
		float yOffset = yThrow * speed * Time.deltaTime;

		float rawNewXPos = transform.localPosition.x + xOffset;
		float clampedXPos = Mathf.Clamp(rawNewXPos, -xRange, xRange);

		float rawNewYPos = transform.localPosition.y + yOffset;
		float clampedYPos = Mathf.Clamp(rawNewYPos, -yRange, yRange);

		transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
	}
}
