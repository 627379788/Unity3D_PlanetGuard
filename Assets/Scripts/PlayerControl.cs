using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;

public class PlayerControl : MonoBehaviour
{
    [Header("General Setup Settings")]
    [Tooltip("控制左右移动速度")][SerializeField] float controlSpeedX = 30f;
    [Tooltip("控制上下移动速度")][SerializeField] float controlSpeedY = 30f;
    [Tooltip("设置屏幕横向移动间距")][SerializeField] float rangeX = 6f;
    [Tooltip("设置屏幕纵向移动间距")][SerializeField] float rangeY = 6f;
    [Header("Laser Gun Array")]
    [Tooltip("激光数组")][SerializeField] GameObject[] lasers;

    [Header("Screen position based tuning")]
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float positionYawFactor = 2f;

    [Header("Player input based tuning")]
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float controlRollFactor = -20f;

    float horizontal, vertical;

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotate();
        ProcessFiring();
    }

    void ProcessFiring()
    {
        if (Input.GetButton("Fire1")) {
            SetLasersActive(true);
        }else {
            SetLasersActive(false);
        }
    }

    void SetLasersActive(bool isActive)
    {
        foreach(GameObject laser in lasers) {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }

    void ProcessRotate()
    {
        float pitchDueToPosition = positionPitchFactor * transform.localPosition.y;
        float pitchDueToControl = vertical * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControl;
        float yaw = positionYawFactor * transform.localPosition.x;
        float roll = horizontal * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessTranslation()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        float offsetX = horizontal * Time.deltaTime * controlSpeedX;
        float newX = transform.localPosition.x + offsetX;
        float clampX = Mathf.Clamp(newX, -rangeX, rangeX);

        float offsetY = vertical * Time.deltaTime * controlSpeedY;
        float newY = transform.localPosition.y + offsetY;
        float clampY = Mathf.Clamp(newY, -rangeY, rangeY);

        transform.localPosition = new Vector3(clampX, clampY, transform.localPosition.z);
    }
}
