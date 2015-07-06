using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    public class myClass
    {
        public static void Main()
        {
            string someText = "Some Letters and Stuf 1 and 1 and 2";
            var z = someText.Search('1', 2);
            var x = someText.Search("a", 3);
            var y = someText.CountString("1");
        }
    }

    public static class MyExtensions
    {
        public static int Search(this string yourString, string yourMarker, int yourInst = 1, bool caseSensitive = true)
        {
            //returns the placement of a string in another string
            int num = 0;
            int currentInst = 0;
            //if optional argument, case sensitive is false convert string and marker to lowercase
            if (!caseSensitive) { yourString = yourString.ToLower(); yourMarker = yourMarker.ToLower(); }
            int myReturnValue = -1; //if nothing is found the returned integer is negative 1

            while ((num + yourMarker.Length) <= yourString.Length)
            {
                string testString = yourString.Substring(num, yourMarker.Length);

                if (testString == yourMarker)
                {
                    currentInst++;
                    if (currentInst == yourInst)
                    {
                        myReturnValue = num;
                        break;
                    }
                }
                num++;
            }           
            
            return myReturnValue;
        }

        public static int Search(this string yourString, char yourMarker, int yourInst = 1, bool caseSensitive = true)
        {
            //returns the placement of a string in another string
            int num = 0;
            int currentInst = 0;
            var charArray = yourString.ToArray<char>();
            int myReturnValue = -1;
            if (!caseSensitive)
            {
                yourString = yourString.ToLower();
                yourMarker = Char.ToLower(yourMarker);
            }
            while (num <= charArray.Length)
            {                
                if (charArray[num] == yourMarker)
                {
                    currentInst++;
                    if (currentInst == yourInst)
                    {
                        myReturnValue = num;
                        break;
                    }
                }
                num++;
            }
            return myReturnValue;
        }
        public static int CountString(this string yourString, string yourMarker)
        {
            //counts the number of strings that exist in another string
            int myCnt = 0;
            string newstring = yourString.Replace(yourMarker, "");
            myCnt = (yourString.Length - newstring.Length) / yourMarker.Length;
            return myCnt;
        }   
    }
}
