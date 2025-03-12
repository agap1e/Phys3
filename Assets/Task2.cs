using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Task2 : MonoBehaviour
{
    public TMP_InputField xInput;
    public TMP_InputField yInput;
    public TMP_InputField accInput;
    public TMP_InputField aInput;
    public TMP_InputField bInput;
    public TMP_InputField cInput;
    public TMP_InputField dInput;
    public TMP_InputField velXInput;
    public TMP_InputField velYInput;
    public TMP_Text timeOut;
    public TMP_Text pathOut;
    public TMP_Text velXOut;
    public TMP_Text velYOut;
    public TMP_Text accXOut;
    public TMP_Text accYOut;

    float path = 0f;
    float xPos = 0f;
    float yPos = 0f;
    float time = 0f;
    float accelX = 0f;
    float accelY = 0f;
    float velocityX = 0f;
    float velocityY = 0f;
    float A = 0f;
    float B = 0f;
    float C = 0f;
    float D = 0f;
    float accelStart = 0f;
    Rigidbody rb;
    void Start()
    {
        time = 0f;
        if (xInput != null)
        {
            xInput.onEndEdit.AddListener(UpdateX);
        }
        if (yInput != null)
        {
            yInput.onEndEdit.AddListener(UpdateY);
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
        if (cInput != null)
        {
            cInput.onEndEdit.AddListener(UpdateC);
        }
        if (dInput != null)
        {
            dInput.onEndEdit.AddListener(UpdateD);
        }
        if (velXInput != null)
        {
            velXInput.onEndEdit.AddListener(UpdateVelX);
        }
        if (velYInput != null)
        {
            velYInput.onEndEdit.AddListener(UpdateVelY);
        }

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= accelStart) {
            accelX = A + B * (time - accelStart);
            accelY = C + D * (time - accelStart);
        }
        velocityX = velocityX + accelX * Time.deltaTime;
        velocityY = velocityY + accelY * Time.deltaTime;
        Moving();
        timeOut.text = String.Format("{0:0.00}", time);
        pathOut.text = String.Format("{0:0.00}", path);
        velXOut.text = String.Format("{0:0.00}", velocityX);
        velYOut.text = String.Format("{0:0.00}", velocityY);
        accXOut.text = String.Format("{0:0.00}", accelX);
        accYOut.text = String.Format("{0:0.00}", accelY);

    }

    void Moving()
    {
        rb.velocity = new Vector3(velocityX, velocityY, 0);
        path = Math.Abs(Mathf.Sqrt(Mathf.Pow(transform.position.x - xPos, 2) + Mathf.Pow(transform.position.y - yPos, 2)));
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
    void UpdateY(string input)
    {
        if (float.TryParse(input, out float newY))
        {
            yPos = newY;
            transform.position = new Vector3(0, yPos, 0);
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
    void UpdateC(string input)
    {
        if (float.TryParse(input, out float newC))
        {
            C = newC;
            time = 0f;
        }
    }
    void UpdateD(string input)
    {
        if (float.TryParse(input, out float newD))
        {
            D = newD;
            time = 0f;
        }
    }
    void UpdateVelX (string input)
    {
        if (float.TryParse(input, out float newVel))
        {
            velocityX = newVel;
            time = 0f;
        }
    }
    void UpdateVelY(string input)
    {
        if (float.TryParse(input, out float newVelY))
        {
            velocityY = newVelY;
            time = 0f;
        }
    }
}
