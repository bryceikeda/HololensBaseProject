using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using Unity.Robotics.Core;

public class PublisherSkeleton : MonoBehaviour
{
    [SerializeField]
    const string k_Topic = "";

    [SerializeField]
    double m_PublishRateHz = 20f;

    [SerializeField]
    ROSConnection m_ROS;

    double m_LastPublishTimeSeconds;


    double PublishPeriodSeconds => 1.0f / m_PublishRateHz;

    bool ShouldPublishMessage => Clock.NowTimeInSeconds > m_LastPublishTimeSeconds + PublishPeriodSeconds;

    // Start is called before the first frame update
    void Start()
    {
        // substitute MsgType with the type you are trying to publish
        //m_ROS.RegisterPublisher<MsgType>(k_Topic);
    }

    void PublishMessage()
    {
        // Replace Msg with the decleration of whatever msg you are sending in this function
        //m_ROS.Publish(k_Topic, Msg);
        m_LastPublishTimeSeconds = Clock.FrameStartTimeInSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        if (ShouldPublishMessage)
        {
            PublishMessage();
        }
    }
}
