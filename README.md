# Open Closed Principle ( OCP )
In the Initial Project , Lets take the Account class

![image](https://user-images.githubusercontent.com/32676744/223460742-0cb5f0c6-61fe-496d-9cf4-4fc16c13fb96.png)

So **OCP** says this Account class should be closed for Modification, but Open for **Extensions** . What this means is we shouldn't be changing the stuff in Account class once it is in Production. It works.
So If a new scenario comes in , we shodn't have to change this, we should just extend it. So let's see first what that new scenario will look like.

Some of the employees coming in are management and we wanna way to identify the employee is a manager . So can quickly think of creating a manager class and inherit it from Employee class , we can do that but it can create a lot of nuisance and that not really the focus of this.

What we really need to here is modify the EmployeeModel class to add a new Property say *IsManager*

![image](https://user-images.githubusercontent.com/32676744/223697580-42d79686-049f-4247-a77c-decffbb6e369.png)

Wait a minute, **did we break OCP here** ? Yes, we did , because we modified an existing class.
This is when we talk through when is the good idea and when its not to implement the OCP.

If we are in a develpement process, this doesn't apply, this doesn't mean we shouldn't design an application which compliant OCP, but we are in a dev process and things can change all across the board in the development and thats ok, but when it goes to production, the only way when its gonna change is because of a bug in the system or atleast that the general rule. If it is a minor change , which is ok means even if we add a minor property and things not gonna break , its fine.

in this case, even we added IsManager, the program still runs , see below output...

![image](https://user-images.githubusercontent.com/32676744/223697660-08f7c711-e719-4cab-b8af-5f0ee72e3cf6.png)

that is because I am not depend on this new property in here.. so this scenario like changing a model is ok , but we can do the same by having an Interface for the model and creating a new IManager to add the new property, there is many ways to do it ..anyway


Now we modify the main console app to reflect the change we were made...

![image](https://user-images.githubusercontent.com/32676744/223698663-a3056004-2882-4c3d-ac89-9a71e8e8088f.png)

Output

![image](https://user-images.githubusercontent.com/32676744/223698753-bb00ea46-19fb-4827-aa22-e4eeed7944de.png)

Next boss come and say we need a manager flag added and the accout processor need to know somehow the employee is a manager or not. 
so we need to modify the PersonModel to add some kind of identifier . To do this , we add a enums like below ( there are many ways we can do, in this case we are using enums, that it)

![image](https://user-images.githubusercontent.com/32676744/223699833-d7321460-725d-4493-9bb3-b813820f7b7c.png)

now in PersonModel we add the enum type

![image](https://user-images.githubusercontent.com/32676744/223700496-eaa73f65-1e4d-4dbb-89e4-32a1242757ab.png)

At this point program run as expected 

but now if the person is a manager, then we need to set the flag to true. This is where the Open closed priciple helps at 

We are modifying Account class to check the person is a manager

![image](https://user-images.githubusercontent.com/32676744/223701228-82c4e7de-f9e1-45ff-8266-ec3f43559fa8.png)

We added the change, but we violated the OCP here by modifyinf the *Create* method

just to demonstrate the program works, we can modify the main program to set the IsManager property

![image](https://user-images.githubusercontent.com/32676744/223701829-b8860de1-c271-47f5-9094-22d1a58b623e.png)

Output
![image](https://user-images.githubusercontent.com/32676744/223701905-ce8255c3-be45-472c-a585-8e0d0ca7f22b.png)

So it works, but we had to modify the working code to make a new change

Now the boss comes and say that, we have new type say **Executive**

So we add a new type in our enums and employee model to represent that new type

![image](https://user-images.githubusercontent.com/32676744/223702662-af76ae77-f0ad-4be6-9754-e0f954a4b0f9.png)
![image](https://user-images.githubusercontent.com/32676744/223702720-15337eaf-869c-46b4-ba0b-96a587842471.png)

Adding this will not break anything , the program runs . we do the same thing in the main program to add the new type 

Now in Account class, we need to check the type and set the output value.

existing account class
![image](https://user-images.githubusercontent.com/32676744/223703385-9f21b3eb-efa7-46b6-ae09-b308452dea38.png)

so to add a new check, say we comment the existing code and add a new block which includes existing code as well, say a switch statement instead of *if*

![image](https://user-images.githubusercontent.com/32676744/223704104-8427119e-b6f4-4900-bab6-bea4bdb872a0.png)


so now the program run, it works , but the Manager is now showing incorrect result for Elon. this was true earlier . we took the code to do it in different way, but forgot to do it , see output below . so we took the code that was working in production and mess the things . so this is a problem
![image](https://user-images.githubusercontent.com/32676744/223704300-724c8696-abc0-4209-b649-1d70d07ff487.png)

so we now comeback and fix the code 

![image](https://user-images.githubusercontent.com/32676744/223705109-610b245f-6fcf-48a2-b6e1-e2df318abc15.png)


lets make Bill gate executive
![image](https://user-images.githubusercontent.com/32676744/223705358-619c37a3-a6f4-466a-9e43-336429df5a89.png)

![image](https://user-images.githubusercontent.com/32676744/223705425-a74cca5b-cf16-4400-9f14-42ab103517f0.png)

at the end , so we modified the codes, the code works , but we introduced bug in the system

so OCP is trying to solve this problem . so the concept is if the application is working, don#t modify the code to introduce potential new bugs to the system

so lets re-imagine how we can do this account class change in OCP way 

So we are keeping the two new properties added in to the *EmployeeModel* , but all other changes are removing from the code







