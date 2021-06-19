## MEDIATOR PATTERN
> Reduces the complex communication between multiple objects. The pattern restricts direct communication between objects and acts as a mediator for communication between the objects.

## Code Example

### UML Diagram
![Strategy Pattern UML Image](https://raw.githubusercontent.com/sandeshkota/DesignPatterns/main/Assets/UML/Mediator.PNG)

### Requirement
The above example is to create a chat room wherein users can join the chatroom or leave as they want. And the chatroom should provide a channel through which multiple users can communicate with each other.
- There should be a chatroom to which people can join and leave.
- Users within a chatroom can communicate with each other through the chat room.
- Direct interaction between the users should be restricted and the communication should happen only through the Chatroom.

### Implementation
- Create a chat room class which holds list of users that are in the chat room.
- When a user requests to join the chat room. Add the user to the chatroom and also the to user list.
- When user wants to leave the chatroom, remove them from the user list.
- When a user sends a message to a chat room, pass the message to everyone else in the chat room (using the users list) except the persom sending.
- The user object should implement a recieve function to which the Chatroom will send the message

### Conclusion
- By creating the chatroom and maintaining the user list
  - There is no need of individual users to communicate
  - ALl communication happens through the chatroom


### Advantages
- De-Coupling: By reducing the dependency between objects. Reduces many-many relationship to one-many.
- Control: The mediator controls all the communication at one place.
- Flexibility: Impact is very minimal if a component/class is removed. ALso adding a new class for communication is easier as only the mediator should be aware of the new class.

### Drawbacks
- Over time, the mediator object can become GOD object


## Other Examples

### Air Traffic Controller
- The ATC manages all communication between several aeroplanes.
- Individual aeroplanes cannot communicate with each other. But can communicate through the ATC.
- HEnce the ATC plays the mediator role between the communication among teh aeroplanes
