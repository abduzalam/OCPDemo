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


**The first real big way to make sure that you can implement OCP is to not tie yourself directly to *classes*** . This means do not use classes, try to avoid it if possible( think of interfaces here). If we not tied directly to class, we can do some modifications to existing code with minimum impact to the working code.
Using interface we can achieve it by add on to other classes 

So lets do this. go to PersonModel and extract a new interface from it. see the below screen

![image](https://user-images.githubusercontent.com/32676744/223711308-94b3ebc0-96e5-4bfa-a3ba-051c9e14fe9a.png)

Essentially interface is a contract, so I created a contract for the Applicants 
![image](https://user-images.githubusercontent.com/32676744/223711799-4e31246f-02ae-4901-a5ee-2b0d767c020e.png)

changes to PersonModel 

![image](https://user-images.githubusercontent.com/32676744/223711925-9666768a-5486-4269-a4d3-14c46f9ce15f.png)

Next in the account class, instead of using PersonMode class in the Create method, use IApplicantModel

![image](https://user-images.githubusercontent.com/32676744/223712140-f31a7c8e-2bf6-4df5-9e87-550647cbe77d.png)

Now I also want to do one more thing

I want to create an inteface for Accounts

![image](https://user-images.githubusercontent.com/32676744/223713135-4e9c3ce9-9ecd-4dc3-b56a-58f24c860ae9.png)


so we just extracted interface for two classes 

Now can do some modification by actually modifying PersonModel class. we can an add one property here, yes I am doing some modification to my model. I could have done in the begining, but I coudn't think through how to implement OCP. Now I am coming back here and simulating how to do OCP and yes I have to make some modification but I am gonna make the change that wouldn't make any harm to my code. 

![image](https://user-images.githubusercontent.com/32676744/223734354-aad9c28c-0e74-40b4-9560-0f0481fd15be.png)

I need to put into my contract as well. 

![image](https://user-images.githubusercontent.com/32676744/223734593-47ef45d9-6375-49a6-ba44-a6bdbc0f82ae.png)


Now every IApplicantModel should have an AccoutProcessor

I have assgined the Account class to the AccountProcessor in PersonModel like below

![image](https://user-images.githubusercontent.com/32676744/223734974-56b3af8f-505b-4922-bea2-6f9ae87c207c.png)

Now we comeback to our main program and change the Accouts creation like below

![image](https://user-images.githubusercontent.com/32676744/223736161-0a83168b-868e-4410-9a4e-e2adec8feaa3.png)


At this point also the code works without any issue
![image](https://user-images.githubusercontent.com/32676744/223736091-e554220b-fb5e-4f18-a20a-77b48a764f19.png)


Now change the main program again to replace PersonModel

![image](https://user-images.githubusercontent.com/32676744/223736634-e455273a-67de-4099-9a61-7308ad43cb32.png)

It still Ok, as the PersonModel implements all fields in the IAccountModel. so no issue, so how does it help us


Now the boss comes to us and says I need you to give me now managers.. no problem boss

Now I add a new class ManagerModel

![image](https://user-images.githubusercontent.com/32676744/223738852-3126fc21-4a28-49f0-8a9e-789902e75fc8.png)

We will not modify the account class , but we can create a new ManagerAccouts class and implement from IAccounts

![image](https://user-images.githubusercontent.com/32676744/223739921-df7f91d5-6f8b-4389-b413-be224193f622.png)

Here the Create method content we can copy & paste from Account class, but think its a DRY ( don't repeat yourself) , so we can think of having a base class to have the create method to reuse the code over here, but what if we want to have a different logic for manager creation, then we can have our own logic here..

In this case, I am putting all managers to abcdcorp domain and also setting IsManager property like below 

![image](https://user-images.githubusercontent.com/32676744/223741478-4bb98489-d117-49b1-b2da-b442e00824ef.png)


Now I am saying in my ManagerModel assign the AccountProcessing = ManagerAccounts

![image](https://user-images.githubusercontent.com/32676744/223741871-29389d37-ae4f-4ea1-9a43-020468ce31ab.png)

Now If I go back to my main program, I can add a new manager model to the IApplicantModel without any issue

changed Elon to ManagerModel

![image](https://user-images.githubusercontent.com/32676744/223743074-3a5c1cc5-dc07-4256-b548-4c0eb56314bc.png)


Output
![image](https://user-images.githubusercontent.com/32676744/223742944-bf18ef5a-e00f-4224-9254-deda8ae4968c.png)

so the code now works, here we didn't make any code changes to the existing account class, instead we created a new IAccount and extended the Account class.

now if boss comes and say we need to add Executive, we can follow the similar approach done for adding manager class

![image](https://user-images.githubusercontent.com/32676744/223745706-fea0dd5e-c1db-49f4-9dda-d284ef00bd56.png)

Model

![image](https://user-images.githubusercontent.com/32676744/223745796-182b704c-9305-456f-b4db-869cf686490b.png)


Main program

![image](https://user-images.githubusercontent.com/32676744/223746071-5a79a6b8-2f36-4381-8c98-6fabd7be036b.png)


Output

![image](https://user-images.githubusercontent.com/32676744/223746257-99ff0f80-f20e-4968-a1b7-7fbd290ef012.png)







