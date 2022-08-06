using UnityEngine;
using TMPro;
using Unity.Robotics.ROSTCPConnector;


public class NumberPadInput : MonoBehaviour
{
    [SerializeField] SetIPButtonText setIPButtonText;

    private static NumberPadInput _instance;
    public static NumberPadInput Instance { get { return _instance; } }

    string ipAddress;
    TextMeshPro inputField;
    ROSConnection m_Ros;
    ConnectIP connectIP;
    
    private void OnValidate()
    {
        connectIP = GetComponent<ConnectIP>();
        inputField = GetComponent<TextMeshPro>();
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }  
    }


    void Start()
    {
        m_Ros = ROSConnection.GetOrCreateInstance();
        inputField.text = m_Ros.RosIPAddress;
        ipAddress = m_Ros.RosIPAddress; 
    }

    void UpdateInputField()
    {
        inputField.text = ipAddress; 
    }

    // Add the key letter pressed to input
    public void OnKeyPressedEvent(string key)
    {
        if (key.Equals("Clear"))
        {
            Clear(); 
        }
        else if (key.Equals("Enter"))
        {
            Enter();
        }
        else if (key.Equals("Backspace"))
        {
            Backspace(); 
        }
        else if (ipAddress.Length < 20)
        {
            ipAddress += key;
            UpdateInputField();
        }
        else
        {
            Debug.LogWarning("[NumberPadInput]: Invalid name of key pressed " + key);
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
