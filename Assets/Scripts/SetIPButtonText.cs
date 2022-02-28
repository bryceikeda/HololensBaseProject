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

    public ROSConnection ros;

    void Start()
    {
        buttonText = GetComponent<ButtonConfigHelper>();
        buttonText.MainLabelText = ros.RosIPAddress;
        checkedOnce = false;
    }

    void Update()
    {
        // If someone inputs a new ip address and presses enter, check if it connects successfully
        if (!checkedOnce && ros.HasConnectionThread && !ros.HasConnectionError)
        {
            checkedOnce = true;
            ConnectSuccess();
        }
        else if(!checkedOnce && ros.HasConnectionError)
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
        buttonText.MainLabelText = string.Format("<color=red>{0}</color>", ros.RosIPAddress);
    }

    public void ConnectSuccess()
    {
        buttonText.MainLabelText = string.Format("<color=green>{0}</color>", ros.RosIPAddress);
    }
}

