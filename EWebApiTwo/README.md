## WebApi 

###  Overall description
<p> WebApi sends and downloads data in many ways.
<p> On the one hand, I have WebApi, which sends Json data to every user using his phone and receives data modified when the user
makes changes to his library. - Part of WebApi with controllers and CRUD methods.
<p> On the other hand. I am (administrator) who inserts only these data (games) and everything that represents them.
This is the main function. In addition, I intend to modify, delete, view all data in my cloud database. - Web in ASP.NET with CloudDatabase 
only for the Administrator to manage it.

### Mechanics  
<ul><b>WebAPI</b>
<li>receiving data using the Get, Delte, Post, Put methods on the phone,</li>
<li>these methods were simply goal-oriented to get, for example: Id (as arguments) for the user who wants to log in or 
view the list of each game</li>
</ul>
<ul><b>Web</b>
<li>show each table and every row, for example: users, list of real games and their DLC</li>
<li>add, edit, delete, modify rows</li>
</ul>
