using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Task1 : MonoBehaviour
{
    public TMP_InputField xInput;
    public TMP_InputField accInput;
    public TMP_InputField aInput;
    public TMP_InputField bInput;
    public TMP_InputField velInput;
    public TMP_Text timeOut;
    public TMP_Text pathOut;
    public TMP_Text velOut;
    public TMP_Text accOut;

    float path = 0f;
    float xPos = 0f;
    float time = 0f;
    float accel = 0f;
    float velocity = 0f;
    float A = 0f;
    float B = 0f;
    float accelStart = 0f;
    Rigidbody rb;
    void Start()
    {
        time = 0f;
        if (xInput != null)
        {
            xInput.onEndEdit.AddListener(UpdateX);
        }
        if (accInput != null)
        {
            accInput.onEndEdit.AddListener(UpdateAcc);
        }
        if (aInput != null)
        {
            aInput.onEndEdit.AddListener(UpdateA);
        }
        if (bInput != null)
        {
            bInput.onEndEdit.AddListener(UpdateB);
        }
        if(velInput != null)
        {
            velInput.onEndEdit.AddListener(UpdateVel);
        }

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= accelStart) {
            accel = A + B * (time - accelStart);
        }
        velocity = velocity + accel * Time.deltaTime;
        Moving();
        timeOut.text = String.Format("{0:0.00}", time);
        pathOut.text = String.Format("{0:0.00}", path);
        velOut.text = String.Format("{0:0.00}", velocity);
        accOut.text = String.Format("{0:0.00}", accel);

    }

    void Moving()
    {
        rb.velocity = new Vector3(velocity, 0, 0);
        path += Mathf.Abs(velocity * Time.deltaTime);
    }
   
  

    void UpdateX(string input)
    {
        if (float.TryParse(input, out float newX))
        {
            xPos = newX;
            transform.position = new Vector3(xPos, 0,0);
            time = 0f;
        }
    }
    void UpdateAcc(string input)
    {
        if (float.TryParse(input, out float newAcc))
        {
            accelStart = newAcc;
            if (accelStart < 0f)
            {
                accelStart = 0f;
                accInput.text = "0";
            }
            time = 0f;
        }
    }
    void UpdateA(string input)
    {
        if (float.TryParse(input, out float newA))
        {
            A = newA;
            time = 0f;
        }
    }
    void UpdateB(string input)
    {
        if (float.TryParse(input, out float newB))
        {
            B = newB;
            time = 0f;
        }
    }
    void UpdateVel (string input)
    {
        if (float.TryParse(input, out float newVel))
        {
            velocity = newVel;
            time = 0f;
        }
    }
}
