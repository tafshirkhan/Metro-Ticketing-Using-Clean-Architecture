# Metro-Ticketing-Using-Clean-Architecture

Metro ticketing service using clean architecture &amp; CQRS pattern

Under blank solution:
Create a new folder as src.

---

### Step - 1:

---

Under src:
Create 4 new project as Class Library:
1)Metro.Application
2)Metro.Core
3)Metro.Infrastructure
4)Shared

And Create a new project as Web API:
1)Metro.API

---

#### Step - 2:

---

Add Project References:

#Metro.Application:
=>Metro.Core.
=>Shared.
#Metro.Infrastructure:
=>Metro.Application.
#Metro.API:
=>Metro.Application.
=>Metro.Infrastructure.
=>Shared.

---

#### Step - 3:

---

Now we need to install some NuGet packages into different projects.

#Metro.Application:
Install below nuget packages:
=>AutoMapper.
=>AutoMapper.Extensions.Microsoft.DependencyInjection.
=>Dapper.
=>FluentValidation.
=>FluentValidation.DependencyInjectionExtensions.
=>MediatR.
=>MediatR.Extensions.Microsoft.DependencyInjection.
=>Microsoft.Extensions.DependencyInjection.Abstraction.
=>Newtonsoft.Json.

#Metro.Core:
Install below nuget packages:
=>Dapper.
=>Microsoft.EntityFrameworkCore.

#Metro.Infrastructure:
Install below nuget packages:
=>Dapper.
=>Microsoft.EntityFrameworkCore.
=>Microsoft.EntityFrameworkCore.Relational.
=>Microsoft.EntityFrameworkCore.SqlServer.
=>Microsoft.EntityFrameworkCore.Tools.
=>Microsoft.Extensions.Options.ConfigurationExtensions.
=>System.Data.SqlClient.

#Shared:
Install below nuget packages:
=>MediatR.
=>MediatR.Extensions.Microsoft.DependencyInjection.

#Metro.Infrastructure:
Install below nuget packages:
=>FluentValidation.AspNetCore.
=>Microsoft.EntityFrameworkCore.Design.
=>Newtonsoft.Json.

---

#### Step - 4:

---

# Working with Metro.Core:

Under Metro.Core create a new folder as #Entities.
Under #Entities create a folder as #Base which will contains the BaseEntity.cs class:
public class BaseEntity<TKey> where TKey : struct
{
public TKey Id { get; set; }
public Guid CreatedBy { get; set; }
public DateTime CreatedDate { get; set; } = DateTime.Now;
public string AuthorizeStatus { get; set; } = "U";
public bool IsDeleted { get; set; } = false;
public Guid? AuthorizedBy { get; set; }
public DateTime? AuthorizedDate { get; set; }
public Guid? LastModifiedBy { get; set; }
public DateTime? LastModifiedDate { get; set; }
}

Under #Entities create a another folder as #metro which will contains all the required classes for our business.
