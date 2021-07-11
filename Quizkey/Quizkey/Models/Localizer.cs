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
            locales.Add("Welcome", new Dictionary<string, string> { { "hr", "Dobrodošli" }, { "en", "Welcome" }});                                      // Navbar
            locales.Add("Play", new Dictionary<string, string> { { "hr", "Igraj" }, { "en", "Play" } });                                                // HomePage
            locales.Add("Login", new Dictionary<string, string> { { "hr", "Prijava" }, { "en", "Login" } });                                            // HomePage
            locales.Add("Register", new Dictionary<string, string> { { "hr", "Registracija" }, { "en", "Register" } });                                 // HomePage
            locales.Add("Go", new Dictionary<string, string> { { "hr", "Dalje" }, { "en", "Go" } });                                                    // Play
            locales.Add("Username", new Dictionary<string, string> { { "hr", "Korisničko ime" }, { "en", "Username" } });                               // Login & Register  
            locales.Add("Password", new Dictionary<string, string> { { "hr", "Zaporka" }, { "en", "Password" } });                                      // Login & Register
            locales.Add("RepeatPassword", new Dictionary<string, string> { { "hr", "Ponovite zaporku" }, { "en", "Repeat password" } });                // Login & Register
            locales.Add("Email", new Dictionary<string, string> { { "hr", "Adresa E-Pošte" }, { "en", "E-mail" } });                                    // Login & Register
            locales.Add("MyProfile", new Dictionary<string, string> { { "hr", "Moj profil" }, { "en", "My profile" } });                                // Navbar LoggedIn
            locales.Add("MyQuizes", new Dictionary<string, string> { { "hr", "Moji kvizovi" }, { "en", "My quizes" } });                                // Navbar LoggedIn
            locales.Add("MyLogs", new Dictionary<string, string> { { "hr", "Moji zapisnici" }, { "en", "My logs" } });                                  // Navbar LoggedIn
            locales.Add("Logout", new Dictionary<string, string> { { "hr", "Odjava" }, { "en", "Logout" } });                                           // Navbar LoggedIn
            locales.Add("CreateNewQuiz", new Dictionary<string, string> { { "hr", "Kreiraj novi kviz" }, { "en", "Create new quiz" } });                // Home Page
            locales.Add("Question", new Dictionary<string, string> { { "hr", "Pitanje" }, { "en", "Question" } });       
            locales.Add("Answer", new Dictionary<string, string> { { "hr", "Odgovor" }, { "en", "Answer" } });       
            locales.Add("questions", new Dictionary<string, string> { { "hr", "pitanja" }, { "en", "questions" } });       
            locales.Add("CorrectAnswer", new Dictionary<string, string> { { "hr", "Odaberite točan odgovor" }, { "en", "Set the correct answer" } });       
            locales.Add("TimeLimit", new Dictionary<string, string> { { "hr", "Odaberite vremensko ograničenje " }, { "en", "Set a time limit" } });       
            locales.Add("WaitingFor", new Dictionary<string, string> { { "hr", "Čekamo ostale " }, { "en", "Waiting for everyone else" } });       
            locales.Add("Points", new Dictionary<string, string> { { "hr", "Bodova" }, { "en", "Points" } });       
            locales.Add("QuizTopic", new Dictionary<string, string> { { "hr", "Tema kviza" }, { "en", "Quiz topic" } });       
            locales.Add("StartQuiz", new Dictionary<string, string> { { "hr", "Započni kviz" }, { "en", "Start quiz" } });       
            locales.Add("StopQuiz", new Dictionary<string, string> { { "hr", "Zaustavi kviz" }, { "en", "Stop quiz" } });       
            locales.Add("NextQuestion", new Dictionary<string, string> { { "hr", "Slijedeće pitanje" }, { "en", "Next question" } });       
            locales.Add("DownloadLog", new Dictionary<string, string> { { "hr", "Preuzmi zapisnik" }, { "en", "Download log" } });       
            locales.Add("EndQuiz", new Dictionary<string, string> { { "hr", "Završi kviz" }, { "en", "End quiz" } });       
            locales.Add("Code", new Dictionary<string, string> { { "hr", "Kod" }, { "en", "Code" } });       
            locales.Add("Edit", new Dictionary<string, string> { { "hr", "Izmjeni" }, { "en", "Edit" } });       
            locales.Add("Delete", new Dictionary<string, string> { { "hr", "Izbriši" }, { "en", "Delete" } });       
            locales.Add("Actions", new Dictionary<string, string> { { "hr", "Akcije" }, { "en", "Actions" } });       
            locales.Add("nplayed", new Dictionary<string, string> { { "hr", "Broj igranja" }, { "en", "# of times played" } });       
            locales.Add("nplayers", new Dictionary<string, string> { { "hr", "Broj igrača" }, { "en", "# of players" } });       
            locales.Add("nquestions", new Dictionary<string, string> { { "hr", "Broj pitanja" }, { "en", "# of question" } });       
            locales.Add("TimePlayed", new Dictionary<string, string> { { "hr", "Odigrano" }, { "en", "Time played" } });       
            locales.Add("Cancel", new Dictionary<string, string> { { "hr", "Odustani" }, { "en", "Cancel" } });       
            locales.Add("Inspect", new Dictionary<string, string> { { "hr", "Pregledaj" }, { "en", "Inspect" } });       
            locales.Add("Player", new Dictionary<string, string> { { "hr", "Igrač" }, { "en", "Player" } });
            locales.Add("yourposition", new Dictionary<string, string> { { "hr", "Vaša pozicija" }, { "en", "Your position" } });
            locales.Add("EverybodyIn", new Dictionary<string, string> { { "hr", "Svi su tu?" }, { "en", "Everybody in?" } });       
            locales.Add("Confirm", new Dictionary<string, string> { { "hr", "Jeste li sigurni?" }, { "en", "Are you sure?" } });       
            locales.Add("PleaseCode", new Dictionary<string, string> { { "hr", "Molimo upišite kod kviza" }, { "en", "Please enter a quiz code" } });       
            locales.Add("PleaseName", new Dictionary<string, string> { { "hr", "Molimo upišite vaše ime" }, { "en", "Please enter your name" } });       
            locales.Add("UpdateAcc", new Dictionary<string, string> { { "hr", "Ažuriraj račun" }, { "en", "Update Account" } });       
            locales.Add("DeleteAcc", new Dictionary<string, string> { { "hr", "Obriši račun" }, { "en", "Delete Account" } });       
            locales.Add("seconds", new Dictionary<string, string> { { "hr", "sekundi" }, { "en", "seconds" } });       
            locales.Add("custom", new Dictionary<string, string> { { "hr", "proizoljno" }, { "en", "custom" } });       
            locales.Add("Save", new Dictionary<string, string> { { "hr", "Spremi" }, { "en", "Save" } });       
            locales.Add("Discard", new Dictionary<string, string> { { "hr", "Odbaci" }, { "en", "Discard" } });       
            locales.Add("WrongEmail", new Dictionary<string, string> { { "hr", "Adresa E-pošte je netočna" }, { "en", "Wrong Email format" } });       
            locales.Add("MissingEmail", new Dictionary<string, string> { { "hr", "Nedostaje vam adresa E-pošte." }, { "en", "Email was not entered." } });       
            locales.Add("MissingName", new Dictionary<string, string> { { "hr", "Nedostaje vam ime." }, { "en", "Name was not entered." } });       
            locales.Add("MissingPassword", new Dictionary<string, string> { { "hr", "Nedostaje vam zaporka." }, { "en", "Password was not entered." } });       
            locales.Add("MissingPasswordRepeat", new Dictionary<string, string> { { "hr", "Zaporka nije bila ponovljena." }, { "en", "Password was not repeated." } });       
            locales.Add("PasswordMatch", new Dictionary<string, string> { { "hr", "Zaporke se ne podudaraju." }, { "en", "Passwords do not match." } });       
            locales.Add("ForgotPassword", new Dictionary<string, string> { { "hr", "Zaboravili zaporku?" }, { "en", "Forgot Password?" } });       
            locales.Add("UsernameTaken", new Dictionary<string, string> { { "hr", "Korisničko ime je zauzeta." }, { "en", "Username is already taken." } });       
            locales.Add("EmailTaken", new Dictionary<string, string> { { "hr", "Adresa e-pošte je zauzeta" }, { "en", "Email is already taken." } });       
            locales.Add("IncorrectLogin", new Dictionary<string, string> { { "hr", "Netočno korisničko ime ili zaporka." }, { "en", "Incorrect username or password." } });       
            locales.Add("MissingAccount", new Dictionary<string, string> { { "hr", "Nije pronađen korisnički račun." }, { "en", "Account not found." } });       
            locales.Add("GoHome", new Dictionary<string, string> { { "hr", "Vrati se na početnu stranicu" }, { "en", "Go to home page" } });       
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