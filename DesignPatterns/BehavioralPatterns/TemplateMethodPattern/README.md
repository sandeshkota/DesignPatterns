## Template Method Pattern
Template Method is a behavioral design pattern that defines the skeleton of an algorithm in the super/base class but lets subclasses override specific steps of the algorithm without changing its structure.


### Examples:

**Sandwich:** For any type of sandwich two breads are needed and the content between them can change. So in this case the base class defines the steps to make a sandwich.
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
