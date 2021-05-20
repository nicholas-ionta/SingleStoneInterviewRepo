# SingleStoneInterviewRepo
Visual Studio 2019 solution &amp; test documents


Included in this Repo is my VS solution for the interview challenge and a postman collection for testing. I believe that this fit much of the requirements outlined in the document sent to me plus or minus a few hings based on assumptions I had to make. I was unable to create a fully IIS web application that is able to run without the use of VS in the time given however I have tested the API methods and ensured they run to what I believe to be correct. 

Running the code:
Opening the solution in VS and running an IIS Express will open a chrome browser to a blank page of a pre-generated local host web page (I just created a basic .Net Framework solution based on the selections available on project create). Once you have the local host https address and port number you can copy those into the postman collection I have also provided for testing (See below). 

For Testing:
  -I have added a Postman collection which can be uploaded to a postman web or desktop app for testing locally.
  -Once application is open click File > Import and select the collection.
  -copy the available port number from the web page in your chrome browser and replace the port number that is in the URL for each test.
  -The Create, UpdateContact both have example json to establish a LiteDB of test cases to use
  -The GetAllTest, Delete, and Call-List do not require specific json and have urls that once created a few test cases can be altered with the correct Ids
  

What I would do to improve this given more time:
-Create a DB context that is instansed on app start to prevent the need from creating the context at the beginning of each method.
-Remove the need for a front end. Although there is a lot that can be done with a front end attached the API was requested made no mention of it.
-Add field validation for the create and update methods.
-I would like to make further use of a DB that is not LiteDB. Although I enjoyed learning it for this excersize there are certain limitations to it that I found frustrating in my implemenation that prevented me from completing this in the time I had wanted.
-I would like to have had a machine that was set up for development before starting so I could have employed a .Net Core application as I feel it would have been easier. (I've never used my personal laptop for coding/work so I was missing several libraries/tools that would have made the task easier) 

Overall I enjoyed the excersize. Although it was in a tech stack I am very familiar with I tried some new things that I wouldn't normally do in a work setting, like using the basic solution in VS and LiteDB.
