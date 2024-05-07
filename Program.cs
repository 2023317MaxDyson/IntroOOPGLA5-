using System.ComponentModel;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Transactions;

namespace GLA5OOPMaxDyson
{
    public class MyInvalidException : Exception
    {
        public MyInvalidException(string message) : base(message)
        {
        }
    }

    class Program
    {
        static bool IsValidEmail(string str)
        {
            const String pattern =
            @"^([0-9a-zA-Z]" + //Start with a digit or alphabetical
            @"([\+\-_\.][0-9a-zA-Z]+)*" + // No continuous or ending +-_. chars in email
            @")+" +
            @"@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,17})$";
            // Return true if str is in valid e-mail format.

            return Regex.IsMatch(str, pattern);
        }
        static string CkeckEmail(out Exception eObj)
        {
            string addr;
            do
            {
                eObj = null;
                Console.WriteLine("Enter e-mail address: ");
                addr = Console.ReadLine();

                try
                {
                    if (!IsValidEmail(addr))
                    {
                        throw (new MyInvalidException("Invalid e-mail address!"));
                    }
                }
                catch (MyInvalidException e)
                {
                    Console.WriteLine("MyEmailException: {0}", e.Message);
                    eObj = e;
                }

            } while (eObj != null);

            return addr;
        }

        static bool IsValidName(string str)
        {
            //ToDo
            //process string str for a valid name input
            //You may use strings or regular expressions for completing it
            //return true if the name is valid, return false otherwise
            //change this return true statement, only return true when the name is valid.




            /*
           //Examples of valid Names:
          Mahbub Murshed
          Mahbub 
          Susan Harper
          Michael Jackson
          Sir Thomas Alva Edison
          Dr. Julius Hossain
          Mr. Smith
          A. K. M. Asadujjaman
           */

            /*
             //Examples of invalid Names:
            mahbub murshed    //first letter of every word must be a capital letter
            mahBub            //Middle letters must not be capital
            S.. Harper        //Two or more consecutive dots(.) not allowed
            M.Jackson         //A single Space must be there after a dot(.)
            . Name            //One or more characters are required before a dot(.)
            Sir_Thomas_Alva_Edison  //Only alphabet characters and dot(.) are allowed
            Julius Hoss@in        //Special characters are not allowed 
            */




            // If the name is not valid



            // Replace the string into substrings 


            string[] name = str.Split();


            // If their is no name entered in the command prompt 

            if (str.Length <= 0)
            {

                return false;

            }


            foreach (string subwords in name)
            {

                //first letter of every word must be a capital letter

                if (!char.IsUpper(subwords[0]))
                {
                    return false;

                }


                //Middle letters must not be capital

                for (int i = 1; i < subwords.Length - 1; i++)
                {
                    if (char.IsUpper(subwords[i])) {

                        return false;

                    }
                }

                //Two or more consecutive dots(.) not allowed


                if (subwords.Contains(".."))
                {
                    return false;

                }


                //A single Space must be there after a dot(.)
                //One or more characters are required before a dot(.)


                if (subwords.Contains(" .") && !char.IsUpper(subwords[0]))
                {
                    return false;

                }


                //Only alphabet characters and dot(.) are allowed


                if (subwords.Contains("@") || subwords.Contains("!") || subwords.Contains("#") || subwords.Contains("$") || subwords.Contains("%") || subwords.Contains("^")
                    || subwords.Contains("&") || subwords.Contains("*") || subwords.Contains("(") || subwords.Contains(")") || subwords.Contains("-") || subwords.Contains("_")
                    || subwords.Contains("+") || subwords.Contains("="))

                {

                    return false;



                }






            }

            // Name is valid 


            return true;


        }

        static string CkeckName(out Exception eObj)
        {

            /*
             Same as email eaxmple, collect name input in a infinity loop until the input is valid.
            Through an exception for invalid name input.
            Use the following expection message while throwing an exception:
               "Invalid Name! \nName must start with a Capital letter and no digits or symbols are allowed except dot(.)"
             */


            string name;

            do
            {

                eObj = null;

                Console.WriteLine("Enter your name:  ");
                name = Console.ReadLine();

                try {
                    if (!IsValidName(name))
                    {
                        throw (new MyInvalidException("Invalid Name! \nName must start with a Capital letter and no digits or symbols are allowed except dot(.)"));
                    }

                }

                catch (MyInvalidException error)
                {
                    Console.WriteLine("MyNameException: {0}", error.Message);
                    eObj = error;

                }


            } while (eObj != null);



            return name;


        }

        static bool IsValidPhone(string str)
        {
            //ToDo
            //process string str for a valid phone number string
            //You may use strings or regular expressions for completing it
            //return true if the phone number format is valid, return false otherwise
            //change this return true statement, only return true when the phone number is valid.




            /*
             //Example of valid phones:
             
             +880-765-543-1234
             987 543 1234
             1-999-123-1234
             88 123 123 1234
             +82-111-222-3333

            //Example of invalid phones:
            ++456-432-1234      //Two leading ‘+’ signs are not allowed
            123-123             //Must be at least a 10-digit number (Use more digits if the number has country code)
            1-1234-123-1236     //(optional ‘+’ symbol) (optional country code [length 1 to 4 digit length maximum]), 
                               //there will be exactly 3 digits then by 3 digits finally the last 4 digits except the country code.
            -1 403-333-1234      //First symbol before country code can be only ‘+’
            +12345-123-123-1234  //Country code must not be more than 4 
             */


            // If their is no name entered in the command prompt 

            if (str.Length <= 0)
            {
                return false;
            }


            //Two leading ‘+’ signs are not allowed


            if (str.Contains("++")) {

                return false;
            }


            //Must be at least a 10-digit number (Use more digits when has country code.)

            if (str.Length < 10)
            {

                return false;



            }




            //(optional ‘+’ symbol) (optional country code [length 1 to 4 digit length maximum]), 
            //there will be exactly 3 digits then by 3 digits finally the last 4 digits except the country code.

            // EX: Country Code -333-333-444




            //(optional ‘+’ symbol)
            // First symbol before country code can be only ‘+’


            if (!str.StartsWith("+") && !str.StartsWith("0") && !str.StartsWith("1") && !str.StartsWith("2") &&
                !str.StartsWith("3") && !str.StartsWith("4") && !str.StartsWith("5") && !str.StartsWith("6") &&
                !str.StartsWith("7") && !str.StartsWith("8") && !str.StartsWith("9")) {

                return false;

            }




            //Country code must not be more than 4 

            // The country code should start with a digit (0-9) 

            // To do



            return true;



        }


        static string CkeckPhone(out Exception eObj)
        {


            /*
            Same as email eaxmple, collect phone input in a infinity loop until the input is valid.
            Through an exception for invalid phone input.
            Use the following expection message while throwing an exception:
               "Invalid Phone Number!\nAccepted Format: +(1 to 4 digits internal code (optional)) - (3 digits) - (3 digits)-(4 digits)"

             */



            string phonenumber;

            do
            {
                eObj = null;
                Console.WriteLine("Enter phone-number:  ");
                phonenumber = Console.ReadLine();

              try
              {

                    if (!IsValidPhone(phonenumber))
                    { 
                        throw (new MyInvalidException("Invalid Phone Number!\nAccepted Format: +(1 to 4 digits internal code (optional)) - (3 digits) - (3 digits)-(4 digits)"));
                    }

              }

            catch (MyInvalidException error)
                {
                    Console.WriteLine("MyPhoneNumberException: {0}", error.Message);
                    eObj = error;
                }

            } while (eObj != null);


            return phonenumber;
        }


        static void Main(string[] args)
        {
            Exception eObj;
            string Name = CkeckName(out eObj);
            string Phone = CkeckPhone(out eObj);
            string Email = CkeckEmail(out eObj);

            Console.WriteLine();
            Console.WriteLine("Your Name is : " + Name);
            Console.WriteLine("Your Phone Number is : " + Phone);
            Console.WriteLine("Your e-mail is : " + Email);  //Note: the e-mail address is already done for you.

            Console.ReadLine();
        }
    }
}
