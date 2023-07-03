A MAUI android-application integrating Firebase as a cloud-messaging service. 

There is included a built in MQTTNEt client provider. This can safely be ignored or removed.
This was developed in an earlier stage but later the idea of MQTT was abandoned for the time being. 

Setup and testing
1 - Download repo from github and launch program from visual studio.

2 - Attach Android-phone and debug application on phone (use of built in simulator are cumbersome and buggy).

3 - Go to https://firebase.google.com/.
 - Register a project
 - Register the MAUI app as part of your project.
 	- Register as android
	- Type:”com.binar.hub” in ”android package name”
  - When downloading googleservices.json. Copy this to root of android-application (root/platform/android).
  - Open properties on googleservices.json, on build action, choose “GoogleServices”.
  - Step 3 in register-process for app is already taken care of and the necessary packages are installed in the application.

4 - When all this is done. Run application. Go to output in Visual studio and look for FCM token. Alternatively run break points on method OnNewToken     (in class MessageService in root/platform/android). Copy FCM-token

5 - Go to firebaseConsole. 
  - Open Engage (in left nav-column)
  - Choose Messaging 
  - Choose create new campaign
  - Choose Firebase Notification messages
  -  Fill in title and description and the click on Test Device. Paste the FCM token from your application output (step 4).

6 - Send message, a push notification should hopefully appear on the connected android phone.
