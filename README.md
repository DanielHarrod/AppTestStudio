# AppTestStudio

## Goals

AppTestStudio is a automated development environment, it contains a builder, tester, and can simultaneously run multiple scripts that can simultaneously automate multiple android apps.  
![Image](https://appteststudio.b-cdn.net/ATSCircles.png)

Interactively: Design, Test, Schedule and Play multiple clients at the same time.
![Image](https://appteststudio.b-cdn.net/ATSAutomate.png)

## Getting Started
1. Install [NoxPlayer](https://www.bignox.com/) 

   1.1 - Launch NoxPlayer client go to Gear on the top menu(Settings)->Interface Settings-> Make sure fixed Window size is checked.
   
   ![Image](https://appteststudio.b-cdn.net/Settings.png)
   ![Image](https://appteststudio.b-cdn.net/FixedWindowSize.png)

2. Install the app of your choice on the Nox player.

   ![Image](https://appteststudio.b-cdn.net/Tools.png)
   ![Image](https://appteststudio.b-cdn.net/PlayStore.png)
   
3. Close this instance of Nox Player, Use the launch controls from App Test Studio - Launching from app test studio, configures DPI, resolution, and window naming.  Which enables consistency and transportability between systems.   

4. Install AppTestStudio

## To Create a new project in AppTestStudio use the Wizard.

### 1.) In AppTestStudio go to File->New->Wizard

![Image](https://appteststudio.b-cdn.net/Wizard.png)

### 2.) Use the wizard to quickly configure a project in seconds.
1.) Enter Seach text for app or game.

2.) Click on the Search button to search for the app.

3.) Click on the app.

4.) Game ID and Name will autopopulate.

5.) Click Create Project
![Image](https://appteststudio.b-cdn.net/AppWizard.png)

### 3.) Start the emmulator

***Always launch the Emmulator from AppTestStudio***  AppTestStudio launches the emmulator with a specific  WindowName, and resolution for consistency and automation.

1.) The Package Name is used to launch the application when the emmulator starts.  If the Package Name is configured, pressing the "Start Emmulator + Launch App" button will launch the instance of nox player specified in the instance to launch (in 2. below).  Package Name is recommended but not required, if you don't want or have the Package Name, Press the "Start Emmulator"( in 4. below) button instead.  Then run the application from the emmulator manually.  When scheduling a script to run at a later time, the application the Package name is required so that the script can be run, and the applicaion can be loaded.

2.) Instance to launch is the instance number you want to target during testing, launching and running scripts.  This is required, users with a single instance will always choose instance 0.  Multiple apps/accounts can be configured on different instances.  For example, you could run 5 instances with the same account, and automate 5 different apps/games on each instance.  Or you could run a differnet account on each instance, and run 5 separate instances of the same app/game.

3.)  The Start Emmulator + Launch App button will run the Android Emmulator and launch the application on the emmulator.

4.) Start Emmulator button will launch the instance to launch(2) of the android emmulator with a set window name,and initial resolution for consistency.

Initial Resolution: is passed from the Start Emmulator buttons to set emmulator to a specific size so that the screenshots will always contain the same resolution.  This helps with sharing the script.  Be sure to have the "Fixed Window Size" checkbox checked, this will make it less likely to resize the window.  Sometimes the emmulator window get's resized, it's best to restart the emmulator.

Video:  A video can be saved that takes a screenshot of the screen at each activity/checkpoint.  Video can be helpful to troubleshoot issues with the script.

Frame Limit: A basic limit to prevent running out of disk space, the script can take 100's to 1000's of screenshots when running.  

![Image](https://appteststudio.b-cdn.net/StartEmmulator.png)

### 4.) Design your script

#### 4.1 On the Events Node in AppTestStudio Tree, right Click and Choose "Add Event", this will take a screenshot.
![Image](https://appteststudio.b-cdn.net/AddEvent.png)


#### 4.2 A new Event is created - at screenshot is automatically taken of the current emmulator window.

1-Give the Event a name

2-Left click on a few unique colors on the screenshot, in this example, I chose a white color inside the 'u' in Zeus, a black color in the 'e' in Zeus, and a Blue color near the word Zeus, and a blue color inside the blue label after the name Zeus.

3-A grid view shows the color, and X,Y coordinates of the color.  Since the logic is AND, when the script is run when all 4 colors at the 4 locations are true, then child events and actions will be run.

(opinion) There are other pixel,coordinate locations that may be better, for example: selecting pixels on the skip text may be ideal so that anytime skip is presented it would be clicked.

![Image](https://appteststudio.b-cdn.net/Event.png)

#### 4.3 Now create an Action
Right click on the 'Zeus' Event, then left click 'Add Action'.

The name will automatically have 'Click ' prepended to the parent name.

![Image](https://appteststudio.b-cdn.net/AddAction.png)

#### 4.4 Build the Action
Incidate where to click, click and drag a blue box around the area that needs to be clicked.  AppTestStudio will randomly click at a single location inside the box when the application is run or when the application is tested.
![Image](https://appteststudio.b-cdn.net/Action.png)

#### 4.4) When the Action note still selected, click 'Test'
App Test Studio will click inside the box inside the emmulator, which will advance app to the next screen.
![Image](https://appteststudio.b-cdn.net/Test.png)

### 4.5) Object Search
Object search enables you to quickly define regions on the screen to search, and quickly define images to locate.

#### 4.5.1) First Define an object.
To define an object click the 'Create Object' button from an Event Node or Right click on the Objects Tree Node under the application.
![Image](https://appteststudio.b-cdn.net/CreateObject.png)

#### 4.5.2) Next identify the object to serach for.
Add New Object will take a screenshot of the current window and allow you to select the object to look for.  

1.) Take a screenshot:  Sometimes a fresh screenshot is needed to get the right image, pressing 'Take a Screenshot' will load a fresh screenshot.

2.) Name: This is the unique name that will be attached to an Object Search Node, Use good naming patterns so it can be easily identfiable.

3.) Draw a box, it will highlight in Blue.

3.1) To improve accuracy look for sections that are unique and distinguishable, sometimes avoiding using the background can improve accuracy.

4.) Make Object (SAVE): Make object will save your selection and add it to the list of objects that can be searched for in the Object Search Event.

![Image](https://appteststudio.b-cdn.net/AddNewObject.png)

#### 4.5.3) Make a New Event with Mode: Object Search
Events default to Color/Point change the event mode to 'Object Search'

On the Object Search a screenshot will be displayed, draw a mask around the area to be searched.  Image recognition can significantly slower than the Color/Point implementation, so define a mask to reduce the area that is needed to be searched.  To draw a mask click on the area and draw a box.  If the box is unsuitable, redraw a box.

![Image](https://appteststudio.b-cdn.net/EventModeObjectSearch.png)

#### 4.5.3) Object properties
After the Object Search Event mode is set to 'Object Search' object properties appears.

Search Object: Select the object to search.

Color Channel: You can choose to search of Red, Green, or the Blue Channel.  It will compare the object to the search area based on the Red, Green, or Blue colors to determine the location of the object.  This if for fine tuning and in most cases I use Red, but sometimes the other colors provide better results.  

Threshold: Object search will ALWAYS find something, it will ALWAYS locate the closest match and provide a Threshold value.  Adjust the acceptance threshold value so that it performs as expected.  The default threshold is set to 70, a threshold match of 100 would be that the image matches identically.

Mask Size: Shows the size of the mask range, it is recommended to limit the area to search for performance reasons.

Set Mask to Max: Is it time to search the entire area, press the Max button and it's done.

Object:  This shows the object to search for giving you a visual representation.

![Image](https://appteststudio.b-cdn.net/Object.png)

#### 4.5.3) An Event under Object Search
So you have build the event, but events don't do anything.  Now an action is needed, place an action under the Object Search.
Object Search has a hourglass icon when the mode of an evetn is set to 'Object Search'.  When a Click or Drag event is a child of a Object Search, the click or drag event will be positioned at the location of the found object that was found in the object search mask.  
On the click event draw a box the size of the range you would like searched, when the object is found the box will be centered on the location, then the click or drag will be performed.
![Image](https://appteststudio.b-cdn.net/EventUnderObjectSearch.png)

### 5.) Continue building 

Continue building more actions and events until the build is complete.

#### 5.1) Using Logical grouping
Use an Event inside another Event.

1.) Organize events inside other events for clarity.

2.) Organize events inside other events for logic/priority.

![Image](https://appteststudio.b-cdn.net/Groups.png)

#### 5.2) Control what happens after an Event or Action occurs.
What needs to occur after a Event Node is true or after an Action node is completed. 

By default Event nodes are set to After Completion: Continue

By default Action nodes are set to After Completion: Back to Home

Continue - Chosing continue will continue execution of any child nodes (nodes lower in the tree) followed by any sibling nodes (nodes on the same level).  This is used when chains of need to be run in a specific order, especially useful when unique events cannot be identified.  

Back to Home - Goes back to the Beginning (Home Events) and starts over from the top.

Back to Parent - Goes back to the Parent Level.  Back to parent is used when you don't want any sibling nodes(Nodes on the same level) to be run.  This can be useful as a break condition such as the app not being ready for the sibling processes.

Stop Thread - Stop will stop the thread when running the script, and App Test Studio will attempt to close the emmulator.  This is useful when you run out of turns for a given application, run out of life, money, or reach an point where large amounts of waiting are necessary.

Recycle - Recycle will restart the emmulator, and restart the application, leaving the thread running.  This useful when there is a detectable an error condition, such as when Ads and the application don't play nice, and cause the app to move or switch resolutions.  Recycling the emmulator and rerunning the app can sometimes fix the issue.

Delay - How long to wait after the Event is true or Action is complete before moving to the next child or sibiling.  The script can run 20-40 times per second, often times the app needs to redraw the screen or move to the next activity.  Waiting ensures that the script will not need to have any false positives.  For example: Setting the Click wait to 0 sec could cause AppTestStudio to click on a button 20 times before the appliation can move to the next activity, because AppTestStudio can be configured to run with limited waiting.

By default Event nodes are set to Delay: 0

By default Action nodes are set to Delay: 1s

Delay for example can be useful to wait for an activity to complete, or wait for 30 seconds after clicking a 'watch ads' button.  

Limit - Limit is used to add superior control over how many times a process can be run.

Wait type: Iteration and Iterations #.  Iterations # is how many times the Action or Event needs to be capable of completing before it is actually done.  If you want AppTestStudio to click the button every 10th time it's able. Set Limit (checked), Wait Type(Iteration), Iterations(10), Repeats(checked).  

Wait type: Time.  How long to wait between activities.  For example you only want an event to be tested every 120 seconds: Set Limit(checked), Wait Type(Time), Time(2 minutes) and Repeats(checked).  Another example you want an event to be tested only once after 45 seconds into execution: Set Limit(Checked),Wait Type(Time), Time(45 seconds) and Repeats(unchecked).

Wait type: once per session:  You want this activity to run only one time.

Repeats will reset the iteration count if limit has already compelted, so it will occur again.

![Image](https://appteststudio.b-cdn.net/After.png)

#### 5.3 Properties

Enabled: Enable or disable parts of the script from running.  This is useful when you don't want full functionality, or something is not working as desired.

Repeats Until False (with Iteration Limit):  This will repeat until the designated iteration limit is hit OR if the event value is false.  This is usefull when you want to repeat a section of code without going back through the entire loop from the start.

![Image](https://appteststudio.b-cdn.net/Properties.png)

Coming soon, needs an update.
[AppTestStudio Projects](https://github.com/DanielHarrod/AppTestStudio-Projects/)
