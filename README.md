# Assignment_EmployeeDataManagement
A project to handle csv file data and fetch data as required.

This program has starting point in program.cs.
There we get instance of the singelton class employee.
Then we read the data from the file passing the file name to the function Readdata(String filename)

Then we use the Display() function to get display the data loaded.

<img src="https://github.com/vijaywar/Assignment_EmployeeDataManagement/blob/master/readmeImages/1.jpg" width=600px height=300px>

Functions provided by employee <br>
Readdata(String filepath);<br>
Sortdata_id();<br>
Sortdata_name();<br>
Display();<br>
GetMembers(int id,int sub=0);<br>
GetMangerName(int id);  //using only single line of code<br>
The code is handled for almost all exceptions.<br>

Readdata throws exception RecordDuplicateException if data is duplicated.

Sorted according to names
<img src="https://github.com/vijaywar/Assignment_EmployeeDataManagement/blob/master/readmeImages/2.jpg" width=600px height=300px>

Sorted accordting to id
<img src="https://github.com/vijaywar/Assignment_EmployeeDataManagement/blob/master/readmeImages/3.jpg" width=600px height=300px>

Manager name of the given employee id
<img src="https://github.com/vijaywar/Assignment_EmployeeDataManagement/blob/master/readmeImages/4.jpg" width=600px height=300px>

All employees list directly or indirectly reporting to a manager
<img src="https://github.com/vijaywar/Assignment_EmployeeDataManagement/blob/master/readmeImages/5.jpg" width=600px height=300px>

Thank you!

<div style="float:right;">Vijaykanth Reddy</div>
