## OBSERVER PATTERN

![Observer Pattern Image](https://raw.githubusercontent.com/sandeshkota/DesignPatterns/main/Assets/Patterns/observer.png)

> Defines one to many dependency between Objects. So that when one object changes state all of it's dependents are notified and updated automatically. 

### Description

### UML Diagram


### Advantages
- De-Coupling: Removes direct dependency between Objects by creating the IObserver interface
- Flexibility: Observers can be added/removed at any point in time
- Open/Close Principle: New Observer/Subject can be added without impacting the existing code

### Drawbacks
- Subscribers are notified in random order.
- Subscribers cannot subscribe based on conditions.


## Code Example

### Requirement
The plan is to implement an Exception Handler in the apllication.
  - Whenever there is an exception, the updates should be notified to Table Logger so that the details are logged to the table
  - Whenever there is an exception, the updates should be notified to Email Sender too so that the team recieves an Exception email
  
### UML Diagram
![Observer Pattern UML Image](https://raw.githubusercontent.com/sandeshkota/DesignPatterns/main/Assets/UML/Observer.PNG)

### Implementation
- Create a Exception Handler class
- ```RegisterObserver()``` is provided for  Table Logger & Email Sender to register for updates
- ```UnRegisterObserver()``` is provided for the Observers to stop being notified for future Updates
- The Exception Handler maintains the list of Observers that should be notified when an Exception occurs
- When an Exception occurs, the Exception Handler notifies all the observers that have registered. It also sends its own reference ```this``` using which, the Observers can get the updates.
- The Exception Handler, provides a method ```GetData()``` using which the Observers can recieve the changed state

### Conclusion
- By Creating the Register() and UnRegister() methods, we have eliminated the direct dependency between the Objects
  - There is no need of individual users to communicate
  - ALl communication happens through the chatroom


## Other Examples

### Coming soon..
