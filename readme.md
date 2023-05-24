# C# Programming wit .NET 6

- Common Base Class Library
	- Microsoft.NetCore.App
		- COllection of all Standard Classes in 'Assemblies'(?)
	- Assembly
		- Collection of all classes related with Each Other
		- Each class is responsible to perform similar type of operations
			- e.g.
				- File Classes
		- Classes are grouped under namespace
			- An Assembly can have muliple namespaces
			- A namespace can have muktiple children namespaces in it
	- THe 'System'
		- Highest level namespace
		- Most of the standard .NET CLases / Namespaces are present under 'System' namespace
		- e.g.
			- System
			- Syetem.IO
				- Files and STreams
			- System.Data
				- Data Operations
			- System.Net
				- Networks
			- System.Xml
				- Xml Programming
			- System.Text
				- Text Encoding
				- Sytem.Text.Json
					- For JSON operations	
			- ..... and many more

- Project File
	- COntains all dependecies used by project as follows
		- Target FRameork
			- Which frawork will be used to execute the project
		- Output Type
			- What will be the output file extension after the project is build
	- The Project Output info
		- projectname.dll
			- Intermidiate Code (Actual Assembly)
		- projectname.exe
			- The .NET 6 Hosting aka 'dotnet.exe'
		- projectname.runtimeconfig.json
			- Runtime COnfigration used for the current project
				- Target Framework
				- OS
					- Windows
					- Linux
					- macOS
				- Processor Archi
					- x86
					- x64
					- arm32
					- arm64
		- projetname.deps.cofig
			- LIst of all dependencies for the current project
			- These dependencies will be loaded inside dotnetc.exe while executing the current project
	- Assembly
		- Manifest	
			- Information about assemgly as follows
				- Version
				- COmpanyName
				- Trademark
		- Intermidiate Language (IL) or MSIL
			- Each Project Name is by itself is a namespace
			- E.g.
				- If ProjectName is CS_MyProject, then the default namespace is MyProject
				- This is a ENtrypoint class name as 'Program'
				- For COnsole APp, the 'Main()' method is implicit 
		- Metadata aka MetaInfo
			- Provides an information about the origin (declaration info) for all methods used inside the current projet to verify follows
				- What is the valid SIgneture (syntax with input and output parameter) of the method
				- Which class defines that method
				- WHich namespace contsins that class

- Debugger
	- F9: FUcntion key to apply break point
	- F10: Step Over
		- Skip the function call and keep debugging
	- F11: Step Into
		- Jump insode the method definition and debug the function and come back to caller
	- F5: RUn
	- Ctrl + F5
		- RUn w/o debugging

- Conditions
- Loops
- Arrays
	-  This is a Class in .NET
	- System.Array
	- Array can be declared as 
		- DATATYPE[] identifier = new DATATYPE[LENGTH];
		- e.g.
			- int[]arr = new int[10];
	- Any declared array is by default an instance (or object) of array class
- Strings
- Methods
	- Reusable blocks in application
	- They may have input and output parameters
	- If the method does not return anything then it mustb be 'void'
	- All parameters passed to method is by 'value'
	- a method can return only one value-type frm method
				
# OOPs with C#
- Class
	- Data Abstraction
	- BEhaior Encapsulation
	- Class Contains following
		- Members
			- Methods
			- Data Members
			- Properties
		- Events
	- Class Instance
		- this is needed to access public members of the class
		- the instance is created using 'new' keyword
		- e.g.
			- C1 obj = new C1();
				- C1 is a class and obje is an instance of the the C1 class
	- Access Specifiers
		- Rules for Accessing Members
			- public, member is accessible everywhere
			- private, member accessible only within declaring class
			- protected, member is accessible in declaring class and its derived class
			- internal, member is accessible with an assembly where this class is defined
			- internal protected, menber is accessible withng a declaring assebly as well as in derived class in different assembly
				- e.g.
					- Class c1 in assembly a1 has 'internal protected' member
					- Class c2 in assembly a2 is deribed from class c1 in assembly a1, then the internal protected member of c1 in a1 is accessible in c2 of a2
	- Access modifiers
		- static, the member of the class is accessbile w/o requiring an instace of the class
			- A static class can have only static members
			- A Static member is 'THread Safe, means its value(s) is shared across the application where it is used
		- abstract
			- THis is used by the class, so if the class is abstract, it cannot be instantiated
				- The abstract class must be inherited
			- If the method is abstract, the it does not have any body (iplementation)
				- The abstract method MUST be overriden by the derived class
		- sealed
			- The class cannot be inherited
			- THe method canot be overriden
		- virtual
			- Virtual method have implementation (body)
			- These can be overriden by derived class with new implementation
		- new
			- This is used for 'Shadowing'
			- THis is used in case the derived and base class has same method with same signeture
				- signeture, means input and output parameter are same
		- async
			- USed to make the method execution as asynchronous
		- await
			- MAke suare that the method is asynchronous and it waits for the asyn operations to be executed
- Class Properties
	- They are known as intelligent-fields
		- get;set; properties
		- set is to set value for private member
		- get is to read value from the provate member
- Inheritence 
	- Class can be derived from 'ONE-SINGLE-BASE-CLASS'
	- Single Inheritence
		- A base class has a single DErived class
```` csharp
	 class Base {}
	 class Derive:Base{}
````

	- Hierarchycal INheritence
		- A base class have multiple Derived classes
```` csharp
	class Base {}
	class Derive1:Base{}
	class Dertive2:Base{}
````
	- Multi-Level interitence
		- A base class has is derived class, and the derived class is a base class for further derivation
```` csharp
	class Base {}
	class Derive1:Base{}
	class Derive2:Derive1{} 
````

- Polymorphism
	- We implement this using
		- Method Overriding
	- We MUST have an abatrast class with either abstract methods or virtual methods
	- Derive class can access base class methods
	- The DErive class instnace can be created using BAse class
```` csharp
	class Base{}
	class Derive:Base{}


	Base b = new Derive(); // The b can only access Base class methods, this can be used if the base class is abstract class but have non-virtual methods (methods those cannot be overriden by derived class) 

````

- Interfaces
	-  They contains methods declaration
	- CLass can implement 'multiple' interfaces
	- If a class implement an interface, then all methods of the interface must be implemeneted by the class, but this is not multiple inheritence
	- CLass implement interfaces using following stretegies
		- Implicit
			- Methdos are implementd by class
			- these methods are owned by class and interface both
			- these methods can be accessible by class instance and interface reference created using class
```` csharp
	pubic interface I1 { m1(); m2() }
	class C1:I1
	{
	   public m1(){}
	   public m2(){}
	}

	// to access methods from class
	C1 obj = new C1(); // class instance
	obj.m1();
	obj.m2();

	// Interface reference using class
	I1 obj1 = new C1();
	obj1.m1();
	obj1.m2();

````
		- Expliit
			- Class contains method definitions from interface
			- But methods are owned by interface and can only be accessible using interface reference and not by class instance
```` csharp
	public I1 { m1(); m2();}
	//exlicit implementation of interface, the method name is prefixed using interface. and no access specifier
	class C1: I1
	{
	  I1.m1(){}
	  I2.m2(){}
	}

	// accessind methods
	I1 obj = new C1();
	obj.m1();
	obj.m2();
````
	- Class implementing mutiple interfaces havig same methods with same signeture
```` csharp
	public I1 {m1();m2();}
	public I2 {m1(), m2();}


	// class impelementng I1 and I2


	class C1 : I1, I2 
	{
	   I1.m1() {}
	   I1.m2() {}
	   I2.m1() {}
	   I2.m2() {}
	}

	I1 obj1 = new C1(); // THis will access methods from I1
	I2 obj2 = new C1(); // THis will access methods from I2


````

	- A class can derived only from one base class and can implement mutiple interfaces
	
```` csharp
	class Base	{}
	interface I1{}
	interface I2{}

	class Derive :Base, I1, I2 {}
````

- Collection Classes
	- In-Memory Data Store classes
	- Data Structures to arrange data in local memeory
	- Fast classes to store large data for the application
	- NAmespaces
		- System.Collections
			- ArrayList
			- Statck
			- Queue
			- ... and many more
			- Each enrtry in ollection class is stored as Object using 'Boxing'
		- System.Collections.Generics
			- Template classes
			- E.g.
				- class MyClass<T>
					- T can be any .NET Type
					- Once the T is set then only values for that type will be alowed
					- e.g.
						- if T is 'int', then only integer values can be used
						- No Boxing and Unboxing

- We can have Polymorphism using interaecs using following ways
	- Like Abstract class 
	- Using Generics (Frequently used in all modern frameworks e.g. MVC, Mobile Apps, REST APIs)

- Delegate
	- It is a type that is used for following
		- Invoking a method with its reference (Address)
			- The Signeture of method MUST match with SIgneture of Delegate
```` csharp
	 // 1. declere delegate (always as namespace level)
	 // delegate with two integer input parameters and and integer as output parameter
	 // means this will be used to invoke a method that has 2 int input parameters and return int as output
	 public delegate int OperationHander(int x,int y);
````
			- The Delegate can directly COntain an Implementation aka Anonymous method
				- Method w/o any name
			- The delegate can be an input parameter to method
				- If a method has an input parameter as delegate, then to that method we can pass 'Lambda Expression (=>)' as input parameter
		- Declare an Event for performing an operation when some condition matches
			- If a delegate is used to declare an event then the return type of deleate must be 'void'
			- 3 Objects reuired for Events
				- 1. THe Caller aka client that request for OPeration (Accout Holder)
				- 2. The Actual Object that accepts the request, perform operations and then raise event (Bank)
					- THis is the object that has an event declared in it 
				- 3. The LIstener object that will listen to the event and receive data from it (EventListener)
				- THe Caller Object MUST koe about the Actual Object that raises event as well as the Listener objecst  
		- Asynchronous Programing

# Next Level Programming FEatures
	- Language Integrated Query (LINQ)
		- Database Like Query to object
		- Langage Independent
		- Seperate FRamework for .NET
	- Enhanced the C# Programming (C# 3.0)
		- Auto-Implemented Properties
			- public int EmpNo {get;set;}
		- Object Initializer
			- Employee emp = new EMployee() {EmpNo=101,EmpName="Mahesh"};
		- Collection Initiaizer
			- List<int> lstInt = new List<int>() {10,20,30};
		- Lambda Expression
		- Extension Methods
			- These methods are accessed using an object of the class, but they are not phisycall present in that class
			- To implement the extension method, following rules MUST be followed
				- The class declaring method as extension method MUST be 'static'
				- The method which will be acting as extension method MUST be 'static'
				- The first parameter of this method MUST be 'this' referred reference of the 'class' for which the method will be an extension method. INstead of class we can also use an interface that is implemenetd by the class for which we are writing an extension method
					- e.g.
						- static int MyExtension(this MyClass m) {.....}
							- Here 'MyExtension()' method is an extension method for 'MyClass' class
```` csharp
	pubic interface I1 {}


	publc sealed class MyClass : I1 {}


	public static class ClsMyExtetnsion
	{
	/// Extension method
	  public static int MyExtension(this I1 obj)
	  {

	  }
	}


	MyClass m  =new MyClass();
	m.MyExtension();

````
	- The MyExtesion() method will be avaiable for all  classes those implements I1 interface

	- We can add extension methods for Standard .NET Classes also


# USing Language Integrated Query (LINQ)
	- USe An Extension Methods
		- Select()
		- Where()
		- OrderBy()
		- OrderbyDescending()
		- Join()
		- GroupBy()
		- ... an many more

# EntityFramework Core (EF Core)

1. ORM by Microsot on .NET
	- Table MUST have Priary Key
	- Database First APproach
		- CLR CLasses aka Entity Classes aka Model classes are generated from Dataase Design
			- e.g.
				- Employee class will be generated from EMployee Table
		- USe this when following conditions are satisfied
			- Database is production ready
			- No changes in database tables (schemas) are needed
			- Migration aplications whe database is to be used as it is
	- Code First  Approach
		- We define Entity classes (Class with Public Properies as well as classes having relations)
		- Generate Database Migrations from Entity classes to generate database and tables
		- USe this in following cases
			- Application is to be deigned fro scratch
			- Database independency
			- Database changes are frequent as per the need of application logic
2. Packages used for EF Core 
	- Microsoft.EntityFrameworCore 
		 - BAse Object Model
	- Microsoft.EntityFrameworCore.Relational	
		- For RDBMS
	- Microsoft.EntityFrameworCore.SqlServer
		- For SQL Server
	- Microsoft.EntityFrameworCore.Tools
		- USed for CLI COmmand to generate Classes from Database and Vide-versa
	- Microsoft.EntityFrameworCore.Design
		- USed to Run the Appliation Migration in case of Code-First

	- Using CLI
		- Open the Command Prompt and go to the Project folder and run following omand to add package for the Project
			- dotnet add package [PACKAGE-NAME] -v [VERSION-NO]
			- dotnet add package Microsoft.EntityFrameworCore -v 6.013 
3. Code Object MOdel
	- DbContext class
		- Base class for EF Core
		- USed to manage DB Connection
		- USed to map Entity class with Database Table using DbSet<T> class
		- USed to manage DB Transaction to Commit changed to Database table
	- DbSet<T> class
		- Represent mapping between Entity class and Database table
		- T is the Entity class mapped with Database Table name T
		- The Recordset the contains recrds from tabel into the application memeory
4. Pseduo Code
	- Consider 'ctx' is an instance of DbContext
	- COnsider 'Employee' is ENtity class
	- Conside 'DbSet<Employee>' is 'Employees'
		- Employees is RecordSet

	- To Read all Records
		- var employees = ctx.Employees.ToList();
	- TO Search Record based on Primary Key 
		- var employee = ctx.Employees.Find(EMpNo);
		- var employee = await ctx.Employees.FindAsync(EmpNo);
	- To add new Employee
		- Define an instance of EMployee class and set its property values
			- e.g.
				- Employee Emp = new Employee();
		- Add this instnace in Employees RecordSet
			- var record = ctx.Employees.Add(Emp);
			- var record = await ctx.Employees.AddAsync(Emp);
		- Commit Transactions
			- ctx.SaveChanges();
			- await ctx.SaveChangesAsync();
		- Adding MUtiple Records
			- Create a collection of EMployee (Array, List)
			- Add this collection to RecordSet
			- var result = ctx.Employees.AddRange(collection);
			- var result = await ctx.Employees.AddRangeAsync(collection);
	- To Update Record
		- First Search Record BAsed on Primary Key
			- var employee = ctx.Employees.Find(EMpNo);
		- Update propertis of this searched record
		- COmmit Transaction
	- To Delete Record
		- First Search Record BAsed on Primary Key
			- var employee = ctx.Employees.Find(EMpNo);
		- Remove it
			- ctx.Employees.Remove(employee); 
		- Commit TRansactions

- EF COre from Command Line aka CLI
	- Install the dotnet ef in global scope
		- dotnet tool install --global dotnet-ef
	- To Use the Database First Approach
		- OPen the COmmand Prompt and navigate to the Project FOlder and run the following command
			- dotnet ef dbcontext scaffold "[CONNECTION-STRING]" Microsoft.EntityFrameworkCore.SqlServer -o Models
				- COnnect to Database using the CONNECTION-STRING
				- REad all Tables
				- Generate Entity Classes in Models Folder
			- CONNECTION-STRING Examples
				- For Windows AUth
					- "Data Source= INSTANCE-NAME | IP ADDRESS | localhost | .; Initial Catalog=DATABASE-NAME;Integrated Security=SSPI"
				- For SQL Server Authentication
					- "Data Source= INSTANCE-NAME | IP ADDRESS | localhost | .; Initial Catalog=DATABASE-NAME;User Id=USERNAME;PAssword=PASSWORD"

	- TO USe the COde FIrst Approach
		- CReate ENtity Classes
			- Class with Public Properties
			- At lead one property MUST be applied with [Key] Attribute, this is Primary Identity Key
			- We can define following attributes on properties
				- [Required] , same as NOT NULL
				- [StringLenght], the Length
```` csharp
      pubic class Employee
	  {
	    [Key]
		public int EmpNo{get;set;}
		[Required]
		[StringLength(1000)]
		public string EmpName {get;set;}
	  }
````
		- Create a class derived from Dbontext and DEfine pubilc properties of DbSet<T> for mapping, here T is an Entity class
```` csharp
	namespace MyApplication
	{
		public class MyDbContext : DbContext
		{
		   public DbSet<Employee> Employees {get;set;}

		   protected override void OnConfiguring()
		   {
			  // Conenction String
		   }
		   // OPtional
		   protected override void OnModelCreating()
		   {
			  //Code for mapping the properties from Entity class to Table 		
		   }
		}
	}
````

	- Generate Migrations
		- A class that will define mapping between Entity class and Database Table

		- dotnent ef migrations add [MIGRATION-NAME] -c [CONTEXT-CLASS]
		- e.g.
			- dotnet ef migrations add firstMigration -c MyApplication.MyDbContext
	- Update the database
		- THis will create database and Tables in Database Server
		- dotnet ef database update -c [CONTEXT-CLASS]
		- e.g.
			- dotnet ef database update -c  MyApplication.MyDbContext

			- This will read migrations class and generate scripts for creating database and tables

# Programming with ASP.NET Core 6 MVC
1. Microsoft.AspNetCore.App
	- ASP.NET COre Base Model
		- Hoting Env
			- Host Builder that configures the ASP.NET Core App on Hosting ENv whihc uses 'dotnet.exe' to execute the web app
			- THe 'WebApplicationBuilder' class
				- Create a Dependency Injection Container
					- Services property of the type IServiceCollection
				- REgister Middlewares
		- Services
			- The Arrangement of 'Dependency Injection' Container
			- Uses IServiceCollection to register following dependencies in DI Container
				- DbContext
				- Identity
					- Security
						- Authentication
						- AUthorization
						- TOkens
				- Sessions
				- Cache
				- Cross Origin Resource Sharing (CORS)
				- Custom Third-Party Services
				- Developres APplication Domain Services
			- Dependency Object LIfetime Methods using the 'ServiceDescriptor' class
				- Singleton, AddSingleton()
					- Life for entire App Life
				- Scopped, AddScopped()
					- Life for a specific Session
				- Transient, AddTransient()
					- Life for specific Request
		- Middlewares
			- The Http request Pipeline
			- Manages following
				- Exceptions
				- Https Redirection
					- Http to Https
				- ROuting
				- CORS
				- StaticFiles
				- Authentication
				- Authorization
				- Custom Middlewares
- MVC
	- builder.Services.AddControllersWithViews()
		- used to accept request for
			- MVC COntrollers
			- API Controllers
	- Controller
		- Accept Http Request and start processing it based on Http Request Types
			- Http Request Types: GET, POST, PUT, and DELETE
		- MVC Controller class has following
			- Derived from 'Controller' abstract base class, which is further derived from 'ControllerBase' abstract class
			- Action Methods
				- Methods those are exeueted based on HTTP Request Type
				- Each Action MEthod Returns type of 'IActionResult'
					- IActionResult is implemted by following classes
						- ViewResult, retunrns View
						- FileResult, returns file
						- PartielViewResut, returns a Partial view
						- JsonResult, returns JSON
			- DO not write any Business Login in Controller
			- What MUST be written in COntrollr
				- Vaidtion Check for ENtities
				- Security Check
				- Exception Filters (OR USe Middlewars)
				- REdirect Across Controllers
				- Managing State
					- Session
					- TempData
# Views in MVC
1. RazorPage<TModel> base class
	- TModel, is the model class passed to View
2. View USes following
	- TagHelper
		- an attribute applied to HTML element to set its behavior
		- asp-action
			- The HTTP GET Request to Action Method
		- asp-controller
			- The HTTP GET Request to Controller
		- asp-items
			- USed by HTML select element to show collection data in HTML select element 
		- asp-for
			- USed to bind the public property from Model class to HTML element
			- WHen HTML element is updated, the corresponding Model property will be updated
	- HtmlHelper
		- The Custom HTML UI defined in ASP.NET MVC Views

# Model Validations
- The 'VaidationAttribute' an Abstract base class used for validating each Model-Binded property based on VAlidation Rules
	- RequiredATtribute
	- STringLengthAttribute
	- CompareAttribute
	- .....
- This class has 'IsValid(object value)' returning 'boolean'
	- The value is the value of the property being validated
	- If the value is valid return true else false
- If the Custom Data Annotation Validations are to be applied, then create a class derived from ValidationAttribute and override the IsValid() method

- If Validations are Dependant based on Domain Logic then Data Annotations won't work, its is better to implement one of the following mechanism to implement such validations
	- In COntroller class inside the action method write the conditional logic to validate
		- To pass error message to View from the Actio Method use one of the following
			- ViewData, Key/Value Pair
			- ViewBag, the Dynamic Objet

	- Use an exception handler to throw an exception and then retunr to error page
		- USe try...catch block and then redirect to Error Page
		- Create Exception Action FIlter
			- Applied in MVC and API COntrollers, does not work in ASP.NET Core app with RAzor Pages
		- CReate an Exception Middleware (Recomended)
			- Works for ENtire ASP.NET Core Eco-System
			- TO Navigate to an exception page it is recommended that, we should avoid hardcoding for route values, instead use the following
				- RouteData property of ControllerBase class
					- USe its 'Values' property, that represent ROute Exepression
					- RouteData.Values["controller"] refer Program.cs
					- RouteData.Values["action"] refer Program.cs
# Sessions
- USe the Session object for passing data across controllers, the data is live throught the Application till it is not chnaged
	- The server-side state management
	- The values will be stored on Host Server
	- USe the AddSession Service as well as the AddInemoryCache service
```` c#
	builder.Services.AddInMemoryCache();
	builder.Services.AddSession();
````
	- Add the Session Middleware	
		- TO inform that the CUrrent HTTPRequest uses the Session State
```` c#
	- app.UseSession();
````

	- The HttpSession object, uses the ISession interface
		- SetInt32(), GetInt32() methods
		- SetString(), GetString()
	- ISession interface has following 2 methods
		- Set()
			- Write Binary Data in Session
		- TryGet()
			- Try to read Binary Data from Session
	- TO Store a CLR Object in Session State, create a custom Session Store Extension for ISession interace

# Action Filters	
	- They are the Software Objects executed based on their application
		- FOr a Specific MEthod in MVC /  API Controller (Lower for Requset, Highest Priority for Response)
		- For a Speific MVC / API Controller (Middle for Requset, Middle Priority for Response )
		- For all Controllers in the APplcation (Highest Priority for Requset, Lower Priority for Response)	
	- IActionFilter Interface
		- ActionFilter Abstract BAse class
		- Override FOllowing Methods
			- OnActionExecuting, accepts parameter ActionExectingContext
			- OnActionExecuted, accepts parameter ActionExecutedContext
			- OnResultExecuting, accepts parameter ResultExecutingContext
			- OnResultExecuted, accepts parameter ResultExecutedContext
		- All these classes are finally derived from 'ActionContext' class and have access to  'RouteData' class

		- AUthorization Filter, Check for Security
		- REsource Filter, Check for the REsurce being targetted e.g. COntroller and its Action
		- Action Filter, Custom Logic
		- Exception Filter, The Standard Exception ot Custom Exception
		- Result Filter, The Result To be returned by the action Method
		

# Parameter Binder aka Model Binder
- Mechansim of Mapping / Binding Received data from Body, QueryString, URL, Headers, Form to the CLR Object
- FromBody
	- Data Received from Http Request MEssage Body
- FromForm
	- Data received from Form Post request	
- FormQuery
	- Data Received from QueryString
- FromRoute
	- Data received from ROute Expressions

# ASP.NET Core Identity
- Microsoft.AspNetCore.Identity
	- A Security FRamework
- Microsoft.AspNetCore.Identity.EntityFrameworkCore
- REady-to-Use Security Classes
	- UserManager<IdentityUser>
		- USed to Create and Manager Users
		- IdentityUser
			- Class USed to Store User's Information in Database
	- RoleManager<IdentityRole>
		- Used to Create and Manage Roles for the Application
		- IdentityRole
			- CLass used to store Role Information in Database 
	- SignInManager<IdentityUser>
		- Manages USer SignIn
- AddIdentity()  
	- Service to be added in DI Container to configure App for ASP.NET Core Security
	- This method will Register UserManager, SignINManager, and RoleManger classed in DI COntainer
- AddAuthentication() and AddAuthorization() Service Methods to Perform Credentials and Role Management in DI Container
- UseAuthentication() and UseAuthorization() Middlewares
	- USed for Verifying User's Credentials and Roles by Calling Database
