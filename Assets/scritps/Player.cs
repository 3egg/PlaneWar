using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Header("general")] [Tooltip("In ms^-1")] [SerializeField]
    private float xSpeed = 25f;

    [Tooltip("In ms^-1")] [SerializeField] private float ySpeed = 30f;
    [Tooltip("In m")] [SerializeField] private float xRange = 25f;
    [Tooltip("In m")] [SerializeField] private float yRange = 15f;

    [Header("move")] [SerializeField] private float posPitch = 0.5f;
    [SerializeField] private float controllPitch = -25f;
    [SerializeField] private float posYawRoll = -2f;
    [SerializeField] private float controllYawRoll = -30f;
    private float xKey, yKey; //按键ad控制的速度即sensitivity

    private bool isControlEnabled = true;


    void OnPlayerDeath()
    {
        isControlEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled)
        {
            MoveXY();
            RotationXY();
        }
    }

    private void RotationXY()
    {
        //当没有按键动作的时候,pitchCon = 0
        //当飞机向上移动时, RX 也要往上偏移,偏移的大小根据按键的大小来判断
        float maxRX = transform.localPosition.y * posPitch; //当y到达了最高点,且停止了移动,3*-3 = -9f;
        float pitchCon = yKey * controllPitch; //根据按键的程度来偏移RX // 0
        float pitch = maxRX + pitchCon; //-9f //最开始的时候, y = -2 , posPitch = -3f rx = 6 

        float maxRY = transform.localPosition.y * posYawRoll;
        float yawCon = xKey * controllYawRoll;
        float yaw = maxRY + yawCon;
        float roll = yawCon + xKey;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void MoveXY()
    {
        float deltaTime = Time.deltaTime; //这个时间越大,表示这一帧持续的越久
        //Vertical
        xKey = CrossPlatformInputManager.GetAxis("Horizontal"); //小于0就是往左,大于0就是往右,否则0就是不动
        float xOffset = xKey * xSpeed * deltaTime; //这个偏移量就是我们的a或d所按的持续偏移

        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        transform.localPosition = new Vector3(clampedXPos, transform.localPosition.y, transform.localPosition.z);

        yKey = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yKey * ySpeed * deltaTime;

        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);
        transform.localPosition = new Vector3(transform.localPosition.x, clampedYPos, transform.localPosition.z);
    }
}