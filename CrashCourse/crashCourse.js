class Shape {
  constructor(height, width, radius) {
    this.height = height;
    this.width = width;
    this.radius = radius;
  }

  // Methods
  //Square
  calcSurfaceSquare() {
    return this.height * this.height;
  }
  calcPerimeterSquare() {
    return this.height * 4;
  }
  //Rectangle
  calcSurfaceRectangle() {
    return this.height * this.width;
  }
  calcPerimeterRectangle() {
    return 2 * (this.height + this.width);
  }
  //Circle
  calcSurfaceCircle() {
    return Math.PI * Math.pow(this.radius, 2);
  }
  calcDiameterCircle() {
    return this.radius * 2;
  }
}
class Square extends Shape {
  constructor(height) {
    super(height, height);
    console.log(height);
  }
  get area() {
    return this.calcSurfaceSquare();
  }
  get perimeter() {
    return this.calcPerimeterSquare();
  }
}
const square = new Square(10);
console.log(square.area); //10*10=100
console.log(square.perimeter); //10*4=40

class Rectangle extends Shape {
  constructor(height, width) {
    super(height, width);
    console.log(height, width);
  }
  get area() {
    return this.calcSurfaceRectangle();
  }
  get perimeter() {
    return this.calcPerimeterRectangle();
  }
}
const rectangle = new Rectangle(10, 5);
console.log(rectangle.area); //10*5=50
console.log(rectangle.perimeter); //2*(10+5)=30

class Circle extends Shape {
  constructor(radius) {
    super(radius, radius, radius);
    console.log(radius);
  }
  get area() {
    return this.calcSurfaceCircle().toFixed(2);
  }
  get diameter() {
    return this.calcDiameterCircle();
  }
}
const circle = new Circle(5);
console.log(circle.area); //Math.PI(3,14)* radius^2==
console.log(circle.diameter); //2*5=10
