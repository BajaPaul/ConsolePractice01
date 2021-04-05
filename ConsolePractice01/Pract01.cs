using System;

namespace ConsolePractice01
{
    /*
    Classes that you declare directly within a namespace, not nested within other classes, can be either public or internal.
    Classes are internal by default.  Class members, including nested classes, can be public, protected internal, protected,
    internal, or private. Members are private by default.  https://msdn.microsoft.com/en-us/library/0b0thckt.aspx

    A static class is basically the same as a non-static class, but there is one difference: A static class cannot be instantiated.
    In other words, you cannot use the new keyword to create a variable of the class type.  Because there is no instance variable,
    you access the members of a static class by using the class name itself.  A static class can be used as a convenient container 
    for sets of methods that just operate on input parameters and do not have to get or set any internal instance fields.  All members
    in a static class must be static.  https://msdn.microsoft.com/en-us/library/79b3xss3.aspx
    
    A static member is callable on a class even when no instance of the class has been created. The static member is always accessed by
    the class name, not the instance name. Only one copy of a static member exists, regardless of how many instances of the class are
    created. Static methods and properties cannot access non-static fields and events in their containing type, and they cannot access
    an instance variable of any object unless it is explicitly passed in a method parameter.

    A 'const' field is essentially static in its behavior. It belongs to the type, not to instances of the type. Therefore, const fields
    can be accessed by using the same ClassName.MemberName notation that is used for static fields. No object instance is required.
    */

    /// <summary>
    /// Practice class with detalied notes on various setting and options.
    /// </summary>
    class Pract01   // Setup Practice class to explore settings.  Classes are internal by default.
    {
        // Create some instance variables.  Private indicates varibales can only be used within this class.  Nothing outside does not know
        // the exist.  Public indicates that anything anywhere can see and use them.  Best practice is keep them private unless absolutely
        // need to be exposed.  Private is default and does not need to be declared!!!

        private string title;
        string author;          // Is private by default
        private int pages = 20; // Can initialize values here too.  Otherwise set to default, in this case 0
        int wordCount;          // Is private by default

        const int baseYear = 1900;      // A 'const' field is essentially static in its behavior.  See note above class for more.

        private static string publisher;    // This variable is only accessible within the class since it is "private" but
                                            // since is "static" it will have same value accross all instances of the class.

        public static int pubYear;          // This variable is accessible from anywhere since it is "public" and
                                            // since is "static" it will have same value accross all instances of the class.
                                            // Since it is public it is only accessible from the base class and not it's instances.
                                            // But it's value can be used and changed by any instance. 

        /*
        Add Constructors which are used to set up new instances of this class.  Constuctors have same name as the class and they do
        not have any return values, such as void or int.  This is how complier knows they are constructors.  Constructors need to have
        different signatures, which are the parameter differences between them.  Constructors are used for initiation of values!!!!

        A class is allowed one static constructor to setup static variables so they are ready for use before class is used.  If static constructor
        is present, it will run before class can be used.  See more p.128 and https://msdn.microsoft.com/en-us/library/79b3xss3.aspx
        */

        public Pract01()        // This is the default constructor which compiler will make if you do not specify at least one.
        {
        }

        static Pract01()        // Static constructor, only one allowed per class!
        {
            // title = "unknown";   // this gives error since title is not static
            publisher = "unknown";  // This is a poor example since variables could be initialized when declared.
            pubYear = baseYear;     // A static constructor could be handy to get path to current user's desktop, for instance.
        }

        public Pract01(string title)    // Make public since want to make this accessible outside of class.  Not required to be public.
        {
            this.title = title;     // Keyword "this" reaches outside constructor to instance varable declared above
        }

        public Pract01(string title, string author)    
        {
            this.title = title;
            this.author = author;
        }
        
        public Pract01(string title, string author, int pages, int wordCount)
        {
            this.title = title;
            this.author = author;
            this.pages = pages;
            this.wordCount = wordCount;
        }

        /*
        Add Methods to provide ways to work with the class's objects.  Constructors just set up new instances of the class.
        These methods are set public so they can be accessed externally.  Note that these objects did not use the keyword "static".
        Non "static" instance varibales and methods belong to an instance of the class, which means each instance will have it's own 
        set of data.  Any member marked "static" belongs to the class as a whole.  Static basically means any member reference, or value,
        is shared and can be used or changed between all instances of a class!

        If a variable or method is made "static" in a class, you do not need to declare or make an instance of the object to access it 
        since it belongs to the class as a whole.  A perfect example is the "Console" class.  It can be used without making a new instance.
        */

        public string GetTitle()
        {
            return title;   // uses the instance varible since no equivalent parameter was specified
        }

        public void SetTitle(string title)
        {
            this.title = title;     // Note keyword "this" would not need to be used if parameter was named something different, newTitle...
        }

        public string GetAuthor() { return author; }

        public void SetAuthor(string author) { this.author = author; }

        public int GetPages() { return pages; }

        public void SetPages(int pages) { this.pages = pages; }

        public int GetWordCount() { return wordCount; }

        public void SetWordCount(int wordCount) { this.wordCount = wordCount; }
        
        public void CalcWordCount(string text)
        {
            wordCount = text.Split(' ').Length;     // Returns string array that contains substrings separated by ' ' space character.
                                                    // "Length" then returns int of number of substrings in the array.
            Console.WriteLine($"\n\nInside Pract01.CalcWordCount: First way to calc wordCount={wordCount}");

            // equivalent way to do this follows.
            string[] substring = text.Split(' ');   // This way makes more sense.  Above procedure called classes and/or complier is doing some
            wordCount = substring.Length;           // heave lifting to make the above shortcut work.  Syntactic Sugar at work here.
            Console.WriteLine($"Inside Pract01.CalcWordCount: Second way to calc wordCount={wordCount}");
        }
        
        public void SetPublisher(string newPublisher)   // Since publisher is private need method to set it externally
        {
            publisher = newPublisher;   // Could not use keyword "this" in this case since variable is declared as "static"
        }

        public string GetPublisher()    // Since publisher is private need method to access it externally
        {
            return publisher;           // publisher is static so it will have same value across all instances
        }

        public int NewPublishDate(int yearsToAdd)
        {
            return pubYear + yearsToAdd;   // Could not use keyword "this" in this case since variable is declared as "static"
                                           // Can not access pubYear directly by instances.  Only via base class.  pubYear can be used
                                           // by instance methods to calculate new values and can also be modified by instance methods.
        }

    }


    /// <summary>
    /// Practice class with detailed notes on various property settings and options.
    /// </summary>
    class Pract02
    {
        // Properties are syntatic sugar.  The compiler turns them back into methods internally.

        private int score;

        // Example of way to do with methods.  The hard way!  To get the score from an instance, use "Pract02.GetScore();"
        public int GetScore()
        {
            return score;
        }

        public void SetScore(int score)     // To set the score from an instance, use "Pract02.SetScore(10);"
        {
            this.score = score;
            if (this.score < 0)
                this.score = 0;
        }

        // Example of way to do same thing with properties.  The easy way??

        public int Score    // To get/set Score from an instance, use "int temp = Pract02.Score;" or "Pract02.Score = 50;"
        {
            get
            {
                return score;       // Very popular lower case for instance vaiables and Upercase for properties, score vs. Score
            }
            set
            {
                score = value;      // Keyword "value" takes on value that caller is setting and is same type, int in this case.
                if (score < 0)
                    score = 0;
            }
        }

        // New case

        private int seconds;  // the instance variable

        public int Seconds      // To get/set Seconds from an instance, use "int sec = Pract02.Seconds;" or "Pract02.Seconds = 50;"
        {                           // Curly brackets required to establish property
            get                     // Note: Curly brackets are always required after get {} and set {}
            {
                return seconds;     // Backing field is 'seconds' since an instance variable exist
            }
            set
            {
                seconds = value;
            }
        }

        public int Minutes      // To get Minutes from an instance, use "int min = Pract02.Minutes;".
        {
            get
            {
                return seconds / 60;    //  No backing field here since there is not a 'minutes' instance variable
            }
            // No setter or getter required, one or the other, or both.
            // This is considered a read-only property.  If visa versa, it would be a write-only property which are rarely useful.
        }

        // Getters and setter can have different accessibilty levels.  Getter could be public and setter could be private so it
        // can only be changed within the class.

        public int Seconds2      // To get/set Seconds from an instance, use "int sec = Pract02.Seconds2;" or "Pract02.Seconds2 = 50;"
        {   
            get 
            {
                return seconds;
            }
            private set         // Setter is private so can only be changed within the class since not accessible via an instance.
            {                   // Private is different than read-only...
                seconds = value;
            }
        }

        // You can auto-implement properties via shorthand.  Like said above, this is syntatic sugar and compiler will convert to methods.

        public int Seconds3 { get; set; }     // The result of this is exactly the same as "Seconds" property above, except, compiler
                                              // will create a backing field, not 'seconds3', and you will not have access to it.
                                              // Conclusion, if you need access to the backing field, then this shorthand will not work for you.

        // You can auto-implement properties via shorthand to be read-only.  These can only be set via a constructor or default value and
        // cannot be changed externally via an instance.  Once again, you will not have access to the backing field since created with shorthand.

        public double X { get; } = 10.0;            // Read-only values.  Read-only is refered to as immutable.
        public double Y { get; } = 15.0;            // Default variables can be set when initialized.  Won't ever be able to use these initialized
                                                    // values since contructor below overwrites them when new instance is created.

        public Pract02(double x, double y)          // This constructor sets read-only values when new instance of calss is created.
        {
            X = x;
            Y = y;
        }


    }

}
