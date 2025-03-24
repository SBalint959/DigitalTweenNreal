# DigitalTweenNreal
This project consists of two Unity applications that work together to place a house model in the real world and send its data and geographical coordinates to a Python Flask server. The first app is made for NReal Light AR glasses and works with placing the model in the real-world environment. Since the AR glasses don't have an embedded GPS system, we developed a simple mobile app, used to send geographical coordinates of the user to the NReal app. There is another app that takes the model data from the Flask server and recreates it in a Digital Twin, but since we did not develop the app, it is not here as a part of this project. The system uses another Flask server to store the geographical coordinates of the user so the NReal app can read and use them accordingly.

## Project Overview
### Components
1. Mobile App (Android)
   - A simple Unity app meant to be installed onto an Android phone
   - Contains a button that retrieves the devices GPS coordinates on click
   - Sends the data to the Flask server
2. AR App (NReal Light Glasses)
   - A Unity App meant to run on NReal Light AR glasses
   - Enables the user to Log in and receive data about placeable house models
   - Enables the user to select and place a model of the house
   - The placed model can then be moved and rotated and its location can be locked
   - Periodically requests the latest GPS coordinates from the Flask server
   - When model is locked, its data, along with the gps coordinates is sent to the Flask server
## Instalation and Setup
Clone the repository 
1. Mobile App (Android)
   - Upload the "Geolocation.apk" app from the Build folder onto your Android smartphone
   - Open the app on your Android smartphone
2. AR App (NReal Light Glasses)
   - If you want to test the app in the Unity Editor or on a PC start the "DigitalTween.apk" app
   - If you want to use it on the NReal Light AR glasses, upload the "DigitalTweenPlaneDetector.apk" app onto your AR glasses and start it
## API Endpoints
### POST /send
- Description: Receives GPS
