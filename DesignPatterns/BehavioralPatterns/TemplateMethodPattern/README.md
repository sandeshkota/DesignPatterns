## Template Method Pattern
> It defines the skeleton of an algorithm in the super/base class but lets subclasses override specific steps of the algorithm without changing its structure.


## Code Example

### UML Diagram

![Template Method Pattern UML Image](https://raw.githubusercontent.com/sandeshkota/DesignPatterns/main/Assets/UML/Template_Method.PNG)

### Requirement
The above example is to save a User and Product information to a Database
- The Objects should be mapped to a specific table and should be able to save to a Database
- Every Object should be validated and should be saved only if it is a valid object
- Each Object should be able to run it's own logic something and after saving the data. These actions should not be mandatory.

### Implementation
-  Since the requirement is to ensure that a certain steps should be followed regardless of it is User or Product
-  Let us create a Model class which takes care of saving the data. Saving the data should internally follow the below steps
  - Validate the data. Proceed only if it is valid object
  - Run Before Save Logic - If any
  - Save to DB
  - Run After Save Logic - If any
- Model class should be made abstract to ensure that an object of it cannot be created. Since it doesn't have a mapping table in the DB.
- We inherit User and Product classes from the Model class. By doing this we have ensured that both User and Product has ```Save()``` method and also it ensures that both the objects follow the same steps to Save the data
- Since we have moved all the logic to Model class, the model class doesn't know how to validate the User and Product since it is not aware of its properties and needs.
- So the validation logic of each object should be handled by themselves. To ensure this the ```Validate()``` method in Model class should be made abstract, which enforces the child classes (user & Product) to implement the validation logic.
- Also as there should be an option to run Object specific logics before and after save. We create two dummy functions ```AfterSave()``` and ```BeforeSave()``` in Model class and mark them Virtual so as to allow the child classes to implement them only if needed (Hook Methods).

### Conclusion
- By moving the ```Save()``` logic to Model (Base) class, we have ensured that the required steps are followed in the same order.
- Also by marking ```Validate()``` method as virtual, we have ensured each child class is responsible of it's own validation
- Also we have ensured that the ```SaveToDB()``` logic is reused by the child objects

### Advantages
- Structure: Ensures that the necessary steps are processed and in the order decided
- Re-Usability: The common code is moved to the base class and reused by all child classes
- Flexibility: The child can implement it's own logic for few of the steps


### Drawbacks
- Violation of Liskov Substitution Principle by suppressing a default step implementation via a subclass.

### Notes
- Follows Hollywood Principle => "You do not call us, we will call you".
  - The base class calls the child class methods based on the order it decides

## Other Examples:

### Sandwich
For any type of sandwich two breads are needed and the content between them can change. So in this case the base class defines the steps to make a sandwich.
It also ensures that two bread slices are added at the top and bottom and asks the sub classes to override and implement adding the stuffing in b/w.

```csharp
// should be abstract because the base class cannot make an actual sandwich
abstract class Sandwich {
  public void MakeSandwich() {
    this.AddBaseBread();
    this.AddStuffing();        // Base class calls the Child Class method.
    this.AddTopBread();
  }
  
  private void AddBaseBread() {
    // code to add Base bread
  }
  
  protected abstract void AddStuffing() { }
  
  private void AddTopBread() {
    // code to add Top bread
  }
}

public class VegetableSandwich: Sandwich {
  protected override void AddStuffing() {
    // add vegetables
  }
}

public class SpinachSandwich: Sandwich {
  protected override void AddStuffing() {
    // add spinach
  }
}

```
