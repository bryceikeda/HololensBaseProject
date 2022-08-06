# Overview
This project provides two scenes. If you would like to start with a scene that has everything set up for building a project for the HoloLens 2, then choose either BaseScene or BaseSceneWithMenu. 

Side Note: This also contains the scene called WSL2TestScene for testing the connection between WSL2 and the HoloLens.

BaseSceneWithMenu has the IP Address keypad and menu as shown in this [video](https://youtu.be/kmEVIafkqgM). If you would like to add the Keypad and Menu to your own project, follow the directions below. 

![image](https://user-images.githubusercontent.com/56240638/156014478-0d91fe8c-5566-4ca9-ba6c-34011e104e39.png)

# Adding NumberPad and Menu to your own project
## Packages and Assets

From this project, copy the folders called Prefabs and Scripts into your Unity project. Make sure you have the following MRTK and Unity Robotics Hub packages installed:

* Mixed Reality Toolkit Examples
* Mixed Reality Toolkit Extensions
* Mixed Reality Toolkit Foundation
* Mixed Reality Toolkit Standard Assets
* Mixed Reality OpenXR Plugin
* Unity Robotics Hub TCP Connector (currently using v0.7.0)

## Add prefabs to scene 
Add the following prefabs to your scene hierarchy. 

![image](https://user-images.githubusercontent.com/56240638/156014624-90776ca2-2596-47c1-9343-a3ab4a790fc1.png)

## Update SetIP On Click()

Then go to the NearMenu3x1 game object and navigate to SetIP. In there, add the SetIPButtonText script (which should already be there). Then at Basic Events, add an On Click() event and add the NumberPad game object. Then click on the GameObject.SetActive function and make sure the box is checked below it.

<img src="https://user-images.githubusercontent.com/56240638/183230127-21544e51-9b89-4183-91b2-5bb300591687.png" alt="drawing" style="width:750px;"/>

## Add components to Number Pad Input Script
Lastly, in the NumberPad game object, go to InputField and drag the SetIP button from the previous step to the field in Number Pad Input.

<img src="https://user-images.githubusercontent.com/56240638/183230060-76a958d8-855a-4095-b151-7e0f0bceaf7a.png" alt="drawing" style="width:750px;"/>

From here you should be good to go! You can click on Robotics->ROS Settings and toggle the Connect on Startup or change the default ROS IP Address before uploading this build to a Hololens 2. 
