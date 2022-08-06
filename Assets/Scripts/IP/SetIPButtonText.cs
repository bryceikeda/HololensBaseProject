using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Robotics.ROSTCPConnector;
using Microsoft.MixedReality.Toolkit.UI; 

public class SetIPButtonText : MonoBehaviour
{
    // Need this variable because other threads will
    // be running if you change the IP via script. If you 
    // make a connection while other threads can't, HasConnectionError
    // will be turned to false because other threads are still
    // trying to connect but cant. 
    bool checkedOnce;

    ButtonConfigHelper buttonText;

    ROSConnection m_Ros;

    private void OnValidate()
    {
        buttonText = GetComponent<ButtonConfigHelper>();
    }

    void Start()
    {
        m_Ros = ROSConnection.GetOrCreateInstance();
        buttonText.MainLabelText = m_Ros.RosIPAddress;
        checkedOnce = false;
    }

    void Update()
    {
        // If someone inputs a new ip address and presses enter, check if it connects successfully
        if (!checkedOnce && m_Ros.HasConnectionThread && !m_Ros.HasConnectionError)
        {
            checkedOnce = true;
            ConnectSuccess();
        }
        else if(!checkedOnce && m_Ros.HasConnectionError)
        {
            checkedOnce = false;
            ConnectFail(); 
        }
    }

    public void CheckConnectionStatus()
    {
        checkedOnce = false; 
    }

    public void ConnectFail()
    {
        buttonText.MainLabelText = string.Format("<color=red>{0}</color>", m_Ros.RosIPAddress);
    }

    public void ConnectSuccess()
    {
        buttonText.MainLabelText = string.Format("<color=green>{0}</color>", m_Ros.RosIPAddress);
    }
}

