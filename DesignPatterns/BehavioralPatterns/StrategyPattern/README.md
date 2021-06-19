## STRATEGY PATTERN
- It defines a family of algorithms and enacapsulates each algorithm and also allows it to be interachangable at run time.

## Code Example

![image](https://raw.githubusercontent.com/sandeshkota/DesignPatterns/main/Assets/UML/Strategy.PNG)

### Requirement
The above example is of a Bank which lends money to customers based on various factors.
- The Bank has a Customer Service class which Gets the interest rate for the Customer
- The Bank calculates the interest rate for a customer based on several factors
  - Customer Rating: Provided by rating agencies. There are several rating agencies and the bank officer should be able to decide the rating agency.
  - Interest Rate: Should be able to decide if the bank should go with High Interest Rate or Low interest rates
  - Discounts: The Bank officer should be able to provide discounts to customers if needed 
- In the above requirement the Bank officer needs flexibility to decide all three different strategies (Rating, Interest Rate, Discount) at run time. The application should be able to take these inputs and calculate the itnerest rate.

### Implementation
- Customer Rating
  - There are various rating agencies that rate customers based on theior own logic. Ex: Moody rating agency, Crisil rating agency, Fitch rating agency, Sicra rating agency. The rating agencies may differ the way they rate a customer but the rating scale is same (AAA, BBB, CCC).
  - The Bank officer should be able to decide the rating agency based on the inforamtion provided by the customer. So the application should be flexible enough to let the bank officer decide which rating agency to consider for any customer.
    - To achieve this flexibility, the customer service class has a rating strategy interface ```IRatingStrategy``` reference. And the Customer service doesn't bother how the rating is calcualted. It just calls the ```GetCustomerRating()``` and expects a value. The bank officer can now decide which Rating Agency the customer serviec class should use by Setting the rating agency using ```SetRatingStrategy(IRatingStrategy ratingStrategy)```

- Interest Rate Strategy
  - In simillar lines, the customer class has ```IInterestRateStrategy``` for getting either the High Interest Rate or Default Interest Rate.

- Discount Strategy
  - In simillar lines, the customer class has ```IDisocuntStrategy``` for getting either the discount rate.

### Conclusion
- By extracting the these logics into a interface we have achieved,
  - Flexibility: Let the strategies be decided at run time
  - Extensibility: The bank can decide to add more strategies (for any of the logic - Customer rating, Interest Rate, Discount) without impacting the existing code 



### Advantages
- De-Coupling: Isoalte algorithm implementation from the code that uses it
- Re-Usability: Using Composition rather than Inheritance
- Control: Change algorithm at run time
- Open/Close Principle: New strategy classes can be added without impacting the existing code
- Prevents conditional statements

### Drawbacks
- Clients must be aware of the various algorithms available. And decide the suitable one based on the scenario.
- Increases the number of classes to manage. If there are too many strategies, maintenance can become an overhead.
- Modern languages lets you simillar behaviour by passing the algorithm while execution.


## Other Examples

### GPS Application
- Suppose you are writing a application for a car driver, which displays the path based on the driver's current location and the destination.
- Later you decide to expand the applicaiton for Bicycle riders and wants to provide the path for bicycle riders. The logic cannot be same since the Bicycle can have a shorter path as the narrow roads allows Bicycle to pass but not the Car. 
- Now you want to allow even the pedestrians to use your application, the path to pedestrians may be different since they can climb stairs and might shorten the distance between current location and destination
- Now waht if you want to allow people to use public transport to reach their destination. The path will vary significantly.
- As you can see the logic/strategy to come up with the path varies (b/w Car Strategy, Bicycle strategy, Pedestrian Strategy, Public Transport Strategy) based on the person who is using it. 
- To adapt to these various strategy it is good to implement Strategy pattern to come up with the path.
