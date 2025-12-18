This is a very rudimentary chat system that allows text based communication over the internet between a Host and Client using Unity 6s UI functionality, it is very bare bones.

T+he version of Unity that this project uses is 6000.0.34f1

The project makes use of ParrelSync: https://github.com/VeriorPies/ParrelSync to allow online testing in editor without having to build the project each time you need to test the client and host behaviour. 

To start testing this: 

1.) Clone the repo and open the ChatSystemUnity6 Demo Unity project.
2.) When the project has opened in Unity, navigate to the menu bar (File, Edit, Assets...) and click: ParrelSync/ClonesManager/Create new clone 
3.) When the clone has been generated, navigate to the menu bar again (File, Edit, Assets...) and click: ParrelSync/ClonesManager/Open in new editor
4.) This will launch another instance of the Unity Editor...


 With two instances of the project opened in Unity, you can now test the functionality. The cloned project will have _clone0 at the end of the project name.

 Host (original Unity Project)

 5.) On the main project (not the clone), enter playmode.
 6.) In the heirarchy, open up DontDestroyOnLoad and select the **NetworkManager** GameObject.
 7.) In the inspector, click Start Host.

 Now open up the cloned project.
 
 8.) On the cloned project, navigate to the heirarchy and locate the Canvas.
 9.) Click on the canvas and in the inspector, locate the Chat UI script, change the name of this to something other than Samuel.
 10.) Enter playmode in the cloned project.
 11.) In the heirarchy, open up DontDestroyOnLoad and select the **NetworkManager** GameObject.
 12.) In the inspector, click Start Client.

 In the Game view, you should now be able to type in messages to the Inputfield UI object, on both the client and host projects and send these messages over the internet. 

 
