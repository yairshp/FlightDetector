# Flight Detector Desktop Application

# About The Project

Flight Detector is a desktop application that allows the user to show flight data on a simulator and explore them.<br>
Users are flight researchers or pilots or simply people who want to view data, sampled at a certain rate during a flight.<br>
Flight data includes, among other things, the position of the rudders, the speed, the altitude, the direction, etc., and they are recorded into a csv file, which can be load
in our app. The app will play the information like a movie from the beginning of the recording until the end, will graphically display
the plane in relation to the Earth, the position of the rudders, and additional flight data in different views, including a special view to find data anomalies.<br>

To run it the user has to load two data files to the app: 
1) csv file that contains the values of the attributes at each moment during the flight.
2) xml file that contains the names of all the attributes.


# Features

* HomePage to upload csv and xml files for the flight simulator.
* MainPage that contains:<br>
 • mediaBar to play the movie, change the speed, stop, go back to the beginning/end<br>
 • joystick and sliders that move according to the position of the airplane<br>
 • data display that contains altimeter, airspeed, heading, pitch, roll, yaw... <br>
 • a list of all the timestep in which there are anomalies<br>
 • graphs related to the flights attributes<br>
   
   <br>
 ![alt tag](https://user-images.githubusercontent.com/81378726/114765868-5c927e80-9d6e-11eb-8d67-b622cb773e00.jpg)
   <br>
   
# Getting Started

# Prerequisites

1) Install the flight simulator - FlightGear(https://www.flightgear.org/) version 2020.3.6. (for all OS)
2) Put the XML file into the folder in which you have installed the FlightGear app, and inside /data/protocol (for example C:\Program Files\FlightGear 2020.3.6\data\Protocol).
3) Open the FlightGear and in the Additional Settings write the lignes below: <br>

--generic=socket,in,10,127.0.0.1,5400,tcp,playback_small <br>
--fdm=null <br>


# Download

Options to download the app: 
- Clone the repository https://github.com/yairshp/FlightDetector.
- Download the zip.


# Usage
Run the FlightGear and the Flight Detector app. <br>
In the HomePage load your csv, xml and dll files and choose an anomaly detector type. <br>
To start flying  press *Start Flying*.<br>
Good fly! <br>
<br>
 ![alt tag](https://user-images.githubusercontent.com/81378726/114764020-2227e200-9d6c-11eb-8b38-6225a6a9d2a0.jpg)
<br>

# Code Design and UML:
<br>


 ![alt tag](https://user-images.githubusercontent.com/81378726/114763777-dbd28300-9d6b-11eb-87f0-c4912a7c43ba.PNG)
<br>

The architecture of the app is based on the *MVVM* architectural pattern. <br>
Model–view–viewmodel (MVVM) is a software architectural pattern that facilitates the separation of the development of the graphical user interface (the view)<br>
The view is the appearance of what the user sees on the screen. It displays a representation of the model and receives the user's interaction with the view (mouse clicks,
keyboard input, screen tap gestures, etc.), and it forwards the handling of these to the view model via the data binding (properties, event callbacks) that is defined to link the view and view model.<br>
The view model is an abstraction of the view exposing public properties and commands. The view directly binds to properties on the view model to send and receive updates. <br>
The Model interacts with the FlightGear app via TCP connection like a client-server.

# Video Explanation 

https://youtu.be/230t_UPn8s0

# Contributors
This program was developed by Adi-Shuker, yairshp, Shana026
