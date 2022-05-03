using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;

#if WINDOWS_UWP
using Windows.Storage;
#endif

public class ConnectIP : MonoBehaviour
{ 
    ROSConnection ros;

    // ROS Connector
    [SerializeField]
    string rosIP;
    public string ROSIP{ get => rosIP; set => rosIP = value; }

    // Start is called before the first frame update
    void Start()
    {
        ros = GetComponent<ROSConnection>(); 
        rosIP = ros.RosIPAddress;
#if WINDOWS_UWP
        // Get IP address from localSettings
        var localSettings = ApplicationData.Current.LocalSettings;
        if(localSettings.Values["IP"] != null){
            rosIP = localSettings.Values["IP"].ToString();
        }
#endif
        if (ros.ConnectOnStart)
        {
            ros.Connect(rosIP, ros.RosPort);
        }
    }

    public void Connect(string inputIP)
    {
        rosIP = inputIP; 
        ros.Disconnect();
        ros.Connect(rosIP, ros.RosPort);

#if WINDOWS_UWP
        // Save IP address to localSettings
        var localSettings = ApplicationData.Current.LocalSettings;
        localSettings.Values["IP"] = rosIP;   
#endif
    }
}
