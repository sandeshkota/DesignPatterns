## CHAIN OF RESPONSIBILITY PATTERN

![Chain Of Responsibility Pattern Image](https://raw.githubusercontent.com/sandeshkota/DesignPatterns/main/Assets/Patterns/chain-of-responsibility.png)

> Request is passed along a chain of handlers. Each handler can decide if it can serve the request or to pass it on to the next handler.

### Description

### UML Diagram


### Advantages
- Control: The order in which the handlers are chained can be controlled.
- Open/Closed Principle. New handlers can be introduced without breaking the existing code.

### Drawbacks
- Some requests may end up unhandled

## Code Example

### Requirement
We need to build an applicaiton which will reimburse amount for an organization. 
If the reimbursement amount is,
- not more than 100, then the Team Leader should be able to approve the reimbursement request.
- more than 100, then the Team Leader cannot approve the reimbursement request and hence the request should be moved to manager.
- not more than 500, then the Manager should be able to approve the reimbursement request
- more than 500, then the Manger cannot approve the reimbursement request and hence the request should be moved to CFO* (Chief Financial Officer).
- The CFO approves the should be able to approve the reimbursement request if it is more than 500

### UML Diagram
![Chain Of Responsibility Pattern UML Image](https://raw.githubusercontent.com/sandeshkota/DesignPatterns/main/Assets/UML/Chain_Of_Responsibility.PNG)

### Implementation
- This would require the request to be passed from team Leader to Manager to CFO
- Since there are three type of approvers. Let us creat TeamLeader, Manager and CFO classes
- Each of them implement ```Reimburse(double amount)``` to handle reimbursement request
- Since there is chain of approvers, any request should be passed through this chainm and based on the amount it will be approved at any stage.
- So each approver should be aware of the next approver, and so a method ```SetNextReimburser(IReimburser reimburser)``` is created through which we can chain the approvers.
- The logic of checking the amount is handled in each of approvers ```Reimburse(double amount)``` method. If the amount is higher than the approver's limit, it simply passes the request to next approver that has been set using ```SetNextReimburser(IReimburser reimburser)```.

### Conclusion
- By creating the link between an approver and next approver, we have ensured that the request is passed to the next approver if it cannot be approved
- If the reimbursement request amount is less than the limit of an approver, the approver approves theamount and ends the request

## Other Examples

### Support Issues
- Usually when there is an issue with any application, 
- the complaint is first sent to an L1 support 
- if the L1 cannot address the issue, the complaint is sent to the next in chain which is L2 support
- if the L2 cannot address the issue, the complaint is sent to the next in chain which is L3 support
- in simillar way the complaint is sent to the next is chain until it is addressed
