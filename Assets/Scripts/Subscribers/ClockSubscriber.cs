using System.Collections;
using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector;
using UnityEngine;
using TMPro;
using RosMessageTypes.Rosgraph;

public class ClockSubscriber : MonoBehaviour
{
    public TextMeshPro tmp;

    void Start()
    {
        ROSConnection.GetOrCreateInstance().Subscribe<ClockMsg>("clock", PrintClock);
    }

    void PrintClock(ClockMsg msg)
    {
        tmp.text = msg.clock.sec.ToString();
    }
}
