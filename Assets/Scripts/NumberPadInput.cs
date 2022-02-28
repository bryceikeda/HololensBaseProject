using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Robotics.ROSTCPConnector;
using System; 

public class NumberPadInput : MonoBehaviour
{
    private TextMeshPro inputField;

    [SerializeField]
    string ipAddress;
    public string IPAddress { get => ipAddress; set => ipAddress = value; }

    // ROS Connector
    [SerializeField]
    ROSConnection ros;
    public ROSConnection ROS { get => ros; set => ros = value; }

    public ConnectIP connectIP;
    public SetIPButtonText setIPButtonText; 

    void Start()
    {
        inputField = GetComponent<TextMeshPro>();
        inputField.text = ros.RosIPAddress;
        ipAddress = ros.RosIPAddress; 
    }

    // Update the text field
    void UpdateInputField()
    {
        inputField.text = ipAddress; 
    }

    // Add the key letter pressed to input
    public void KeyPress(string key)
    {
        if (ipAddress.Length < 20)
        {
            ipAddress = ipAddress + key;
            UpdateInputField();
        }
    }

    // Clear the input
    public void Clear()
    {
        ipAddress = string.Empty;
        UpdateInputField();
    }

    // Delete single character
    public void Backspace()
    {
        if (ipAddress.Length != 0)
        {
            ipAddress = ipAddress.Remove(ipAddress.Length - 1, 1);
        }
        
        UpdateInputField();
    }

    public void Enter()
    {
        connectIP.Connect(ipAddress);
        setIPButtonText.CheckConnectionStatus(); 
    }
}
