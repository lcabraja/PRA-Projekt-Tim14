# Cookie and Session globals
Any sort of error with the cookies, and we send the user to the Login.aspx page

The "_UserState_" cookie tells us if the user has been to the site yet or not,
and also where they are now.
```csharp
HttpCookie userState = Request.Cookies["UserState"]

cookie == null // Send to StartPage.aspx

cookie["loggedin"] == "author" // Send to HomePage.aspx
cookie["loggedin"] == "attendee" // Send GameStartPage.aspx
```

Self Explanatory
```csharp

cookie["language"] == "en" // English
cookie["language"] == "hr" // Croatian
```

User name and identifier
```csharp
cookie["username"] // Used for all users
cookie["userid"] // Used only for authors
```

```csharp
cookie["points"] // An integer ammount of points that the attendee has
cookie["quizcode"] // The quizcode that the user is currently attending
```

Quiz session identifier, should be empty if the user is not in a session
```csharp
cookie["sessionid"] // Used for all users, when attending a quiz session
```

This is a precaution in case we need it, it might help with redirection
```csharp
cookie["comingfrom"] // The page the user is coming from
cookie["goingto"] // The page the user is going to
```