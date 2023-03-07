# Open Closed Principle ( OCP )
In the Initial Project , Lets take the Account class

![image](https://user-images.githubusercontent.com/32676744/223460742-0cb5f0c6-61fe-496d-9cf4-4fc16c13fb96.png)

So **OCP** says this Account class should be closed for Modification, but Open for **Extensions** . What this means is we shouldn't be changing the stuff in Account class once it is in Production. It works.
So If a new scenario comes in , we shodn't have to change this, we should just extend it. So let's see first what that new scenario will look like.

Some of the employees coming in are management and we wanna way to identify the employee is a manager . So can quickly think of creating a manager class and inherit it from Employee class , we can do that but it can create a lot of nuisance and that not really the focus of this.

What we really need to here is modify the EmployeeModel class to add a new Property say *IsManager*

![image](https://user-images.githubusercontent.com/32676744/223464226-ba613867-9386-48cd-8bc0-525512cd5469.png)

Wait a minute, **did we break OCP here** ? Yes, we did . This is when we talk through when is the good idea and when its not to implement the OCP.



