# AppTestStudio

AppTestStudio is a automated development environment, it contains a builder, tester, and can simultaneously run multiple scripts automating multiple apps.  
![Image](zATSCircles.png)

Install [NoxPlayer](https://www.bignox.com/)
Install the app of your choice on the Nox player.
Install AppTestStudio

In AppTestStudio go to File->New->Wizard, search for your app, locate the app( so that AppID, and AppName populate) -> Click Create Project.

Click on Start Emmulator + Launch App ( This will run the emmulator in a set Resolution, and run the app )
(wait for the app to load)

On the Events Node in AppTestStudio Tree, right Click and Choose "Add Event", this will take a screenshot.

Now click on the colors that are unique to this screen, that won't be on other screens.  Add points(number of pixels to consider OK) if the colors vary such as an animation.

Now that the Event is created, Rigth Click and add either more events or add an Action, Now draw a box where you want AppTestStudio to click randomly.

You can click the test Button to test clicks or Test.

When you have a list of events, click Run Script, this will launch a background thread and run the script.  

-=-=-=-=--=-=-=-=--=-=-=-=--=-=-=-=--=-=-=-=--=-=-=-=--=-=-=-=--=-=-=-=--=-=-=-=--=-=-=-=--=-=-=-=--=-=-=-=-


Conversion to C# is almost over, there could be some leftovers here or there typically the implicity to explict casting conversion.

With Minutes of training could save you hours or days.

[AppTestStudio Projects](https://github.com/DanielHarrod/AppTestStudio-Projects/)
