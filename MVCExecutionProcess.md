![MvcProcess](https://user-images.githubusercontent.com/56407906/133404003-20eb6565-df91-476c-9c65-febe93357b0b.png)

## HTTP Request :
- Receive first request for the application. In the Global.asax file, route objects are added to the Route table object. 

## Routing 
- The entry point for every MVC Application begins with Routing. After the application receives the request from the user, it uses URL Routing Module to handle the request.

## Controller
- The controller determines which action method to execute. 
- Mvc controllers implement IController interface to execute the method which actually execute your action method.

## Action Invoker 
- ActionInvoker object that is associated with the controller determines which action method of the controller class to call, and then calls that method.

## Action
-  ActionMethodSelectorAttribute methods used to select action method. The action method receives user input then executes the result and returning a result type to view. 
