# Choose Scene

If you would like to start with a scene that has everything set up for building a project for the HoloLens 2, then choose either BaseScene or BaseSceneWithMenu. 

BaseSceneWithMenu has the IP Address keypad and menu as shown in this [video](https://unity3d.com/get-unity/download).

![image](https://user-images.githubusercontent.com/56240638/156014478-0d91fe8c-5566-4ca9-ba6c-34011e104e39.png)

# Adding NumberPad and Menu to your own project
## Packages and Assets

From this project, copy the folders called Prefabs and Scripts into your Unity project. Make sure you have the following MRTK and Unity Robotics Hub packages installed 

* Mixed Reality Toolkit Examples
* Mixed Reality Toolkit Extensions
* Mixed Reality Toolkit Foundation
* Mixed Reality Toolkit Standard Assets
* Mixed Reality OpenXR Plugin
* Unity Robotics Hub TCP Connector

## Add prefabs to scene 
Add the following prefabs to your scene hierarchy. If you don't see the Resources folder with ROSConnectionPrefab then go up to the Robotics Tab, then click ROS Settings. This will automatically add the Resources folder for you. 

![image](https://user-images.githubusercontent.com/56240638/156014624-90776ca2-2596-47c1-9343-a3ab4a790fc1.png)

![image](https://user-images.githubusercontent.com/56240638/156014668-4eb35442-252f-4bfa-acb1-e8abdb1bdaa4.png)

## Add Connect IP Script
Go to the ROSConnectionPrefab and add the ConnectIP script component. 

![image](https://user-images.githubusercontent.com/56240638/156018727-c18bd2aa-91f1-46fb-8bbe-626e9af32092.png)

## Update SetIP game object components

Then go to the NearMenu3x1 game object and navigate to SetIP. In there, add the ROSConnectionPrefab to the SetIPButtonText script. Then at Basic Events, add an On Click() event and add the NumberPad game object. Then click on the GameObject.SetActive function and make sure the box is checked below it

![image](https://user-images.githubusercontent.com/56240638/156018975-a2ce2b9d-2edf-4b8d-88bd-8dbae6a8348f.png)

## Add components to Number Pad Input Script
Lastly, in the NumberPad game object, go to InputField and drag the ROSConnectionPrefab to the Ros and ConnectIP sections of the Number Pad Input component. Lastly, drag the SetIP button from the previous step to the last input. 

![image](https://user-images.githubusercontent.com/56240638/156019069-90d01b3f-9ebd-461b-80c0-0738118517d4.png)

From here you should be good to go! You can click on Robotics->ROS Settings and toggle the Connect on Startup or change the default ROS IP Address before uploading this build to a Hololens 2. 
