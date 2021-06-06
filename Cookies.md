# Cookie and Session globals
Any sort of error with the cookies, and we send the user to the Login.aspx page

The "_UserState_" cookie tells us if the user has been to the site yet or not,
and also where they are now.
```csharp
HttpCookie userState = Request.Cookies["UserState"]

cookie == null // Send to StartPage.aspx

cookie["loggedIn"] == "author" // Send to HomePage.aspx
cookie["loggedIn"] == "attendee" // Send GameStartPage.aspx
```

User name and identifier
```csharp
cookie["userName"] // Used for all users
cookie["userID"] // Used only for authors
```

Quiz session identifier, should be empty if the user is not in a session
```csharp
cookie["sessionID"] // Used for all users, when attending a quiz session
```

This is a precaution in case we need it, it might help with redirection
```csharp
cookie["comingFrom"] // The page the user is coming from
cookie["goingTo"] // The page the user is going to
```

This might help with redirecting users between quiz questions.
```csharp
cookie["comingFrom"] // The page the user is coming from
cookie["goingTo"] // The page the user is going to
```