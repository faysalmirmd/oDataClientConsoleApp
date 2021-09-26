# oDataClientConsoleApp
A Console application utilizing public OData API from: https://www.odata.org/odata-services/ (v4).

ODataClientConsoleApp 1.0.0
Copyright (C) 2021 ODataClientConsoleApp


# Project Setup
Step 1: Download and install .NET 5 SDK (https://dotnet.microsoft.com/download/dotnet/5.0), Visual Studion needs to be updated to version 16.8.0 or higher

Step 2: Clone the following repository from Github.
```
git clone https://github.com/faysalmirmd/oDataClientConsoleApp.git
```
Step 3: open the project in Visual Studio

Step 4: Hit F5 in Visual Studio

# Run from CMD
Step 1: cd oDataClientConsoleApp (Directory containing ODataClientConsoleApp.csproj file)

Step 2: dotnet build

Step 3: dotnet run
		
# Commands to Execute
```
ODataClientConsoleApp 1.0.0
Copyright (C) 2021 ODataClientConsoleApp

  list           List the people

  details        Details view of a person by UserName with parameter -u <username> i.e details -u russellwhyte

  create         Create a person with parameters, add -b true for batch operation
                 UserName -u <username>
                 FirstName -f <firstname>
                 LastName -l <lastname>
                 Emails -e <comma separated emails>
                 Gender -g <gender> i.e male/female/unknown
                 Address -a <address>
                 City -c <city>
                 Country -s <country>
                 Region -r <region>
                 Note: Double quote("") is required around parameter values containing whitespace i. e
                 create -u <username> -s "United states"

  update         Update a person by UserName -u <username> with parameters to update, add -b true for batch operation
                 FirstName -f <firstname>
                 LastName -l <lastname>
                 Emails -e <comma separated emails>
                 Gender -g <gender> i.e male/female/unknown
                 Address -a <address>
                 City -c <city>
                 Country -s <country>
                 Region -r <region>
                 Note: Double quote("") is required around parameter values containing whitespace i. e
                 update -u <username> -a "Bandar Utama, 47800 Petaling Jaya, Selangor"

  remove         remove person by UserName with parameter -u <username>, add -b true for batch operation

  batchcommit    Batch commit all the changes

  search         search people by UserName with parameter -u <username> or for full text search, -s <text>

  filter         filter by oData filter query param with parameter -f "<filterQueryValue>" i.e -f "FirstName eq 'Scott'"
                  Operator Options:
                   Equal: eq
                   Not Equal: ne
                   Greater Than: gt
                   Greater Than or Equal: ge
                   Less Than: lt
                   Less Than or Equal: le
                  Filter phrases:
                    contains(PropertyName,'Value')
                    startswith(PropertyName,'Value')
                    endswith(Property1,'Value1')
                    indexOf(Property1,'Value1') eq 1
                    length(Property1) eq 19
                    substring(Property1, 1, 2) eq 'ab'
                 and/or can be applied i.e Property1 eq 'Value1' and Property2 eq 'Value2'
                 Note: Double quote("") is required around parameter values containing spaces i. e the filter query
                 You can add multiple filter queries separated by '|', will be run in batch i.e.
                 filter -f "FirstName eq 'Scott'|LastName ne 'Jack'"
                 filter -f  "FirstName ne 'Russell'|Emails/any(s:endswith(s, 'example.com'))"

  help           Display more information on a specific command.

  version        Display version information.



```
	
