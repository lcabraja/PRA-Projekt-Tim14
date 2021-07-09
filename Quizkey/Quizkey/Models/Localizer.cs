using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quizkey.Models
{
    public sealed class Localizer
    {
        Dictionary<string, Dictionary<string, string>> locales = new Dictionary<string, Dictionary<string, string>>();

        private static readonly Lazy<Localizer>
            lazy =
            new Lazy<Localizer>
                (() => new Localizer());

        public static Localizer Instance { get { return lazy.Value; } }

        private Localizer()
        {
            locales.Add("Welcome", new Dictionary<string, string> { { "hr", "Dobrodošli" }, { "en", "Welcome" }});              // Navbar
            locales.Add("Play", new Dictionary<string, string> { { "hr", "Igraj" }, { "en", "Play" } });                        // HomePage
            locales.Add("Login", new Dictionary<string, string> { { "hr", "Prijava" }, { "en", "Login" } });                    // HomePage
            locales.Add("Register", new Dictionary<string, string> { { "hr", "Registracija" }, { "en", "Register" } });         // HomePage
            locales.Add("Go", new Dictionary<string, string> { { "hr", "Dalje" }, { "en", "Go" } });                            // Play
            locales.Add("Username", new Dictionary<string, string> { { "hr", "Korisničko ime" }, { "en", "Username" } });       // Login & Register  
            locales.Add("Password", new Dictionary<string, string> { { "hr", "Zaporka" }, { "en", "Password" } });              // Login & Register
            locales.Add("Email", new Dictionary<string, string> { { "hr", "Adresa E-Pošte" }, { "en", "E-mail" } });            // Login & Register
            locales.Add("MyProfile", new Dictionary<string, string> { { "hr", "Moj profil" }, { "en", "My profile" } });        // Navbar LoggedIn
            locales.Add("MyQuizes", new Dictionary<string, string> { { "hr", "Moji kvizovi" }, { "en", "My quizes" } });        // Navbar LoggedIn
            locales.Add("MyLogs", new Dictionary<string, string> { { "hr", "Moji zapisnici" }, { "en", "My logs" } });          // Navbar LoggedIn
            locales.Add("Logout", new Dictionary<string, string> { { "hr", "Odjava" }, { "en", "Logout" } });          // Navbar LoggedIn
            locales.Add("CreateNewQuiz", new Dictionary<string, string> { { "hr", "Kreiraj novi kviz" }, { "en", "Create new quiz" } }); // Home Page
            locales.Add("Question", new Dictionary<string, string> { { "hr", "Pitanje" }, { "en", "Question" } });       
            locales.Add("questions", new Dictionary<string, string> { { "hr", "pitanja" }, { "en", "questions" } });       
            locales.Add("CorrectAnswer", new Dictionary<string, string> { { "hr", "Odaberite točan odgovor" }, { "en", "Set the correct answer" } });       
            locales.Add("TimeLimit", new Dictionary<string, string> { { "hr", "Odaberite vremensko ograničenje " }, { "en", "Set a time limit" } });       
            locales.Add("WaitingFor", new Dictionary<string, string> { { "hr", "Čekamo ostale " }, { "en", "Waiting for everyone else" } });       
            locales.Add("Points", new Dictionary<string, string> { { "hr", "Bodova" }, { "en", "Points" } });       
            locales.Add("QuizTopic", new Dictionary<string, string> { { "hr", "Tema kviza" }, { "en", "Quiz topic" } });       
            locales.Add("StartQuiz", new Dictionary<string, string> { { "hr", "Započni kviz" }, { "en", "Start quiz" } });       
            locales.Add("StopQuiz", new Dictionary<string, string> { { "hr", "Zaustavi kviz" }, { "en", "Stop quiz" } });       
            locales.Add("NextQuestion", new Dictionary<string, string> { { "hr", "Slijede'e pitanje" }, { "en", "Next question" } });       
            locales.Add("DownloadLog", new Dictionary<string, string> { { "hr", "Preuzmi zapisnik" }, { "en", "Download log" } });       
            locales.Add("EndQuiz", new Dictionary<string, string> { { "hr", "Završi kviz" }, { "en", "End quiz" } });       
            locales.Add("Code", new Dictionary<string, string> { { "hr", "Kod" }, { "en", "Code" } });       
            locales.Add("Edit", new Dictionary<string, string> { { "hr", "Izmjeni" }, { "en", "Edit" } });       
            locales.Add("Delete", new Dictionary<string, string> { { "hr", "Izbriši" }, { "en", "Delete" } });       
            locales.Add("SAMPLETEXT", new Dictionary<string, string> { { "hr", "SAMPLETEXT" }, { "en", "SAMPLETEXT" } });       
        }
        public string Resource(string request, string locale)
        {
            try
            {
                return locales[request][locale ?? "en"];
            }
            catch (Exception)
            {
                return "MISSING STRING";
            }
        }
    }
}