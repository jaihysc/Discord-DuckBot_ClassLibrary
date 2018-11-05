using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DuckBot_ClassLibrary
{
    public class CoreMethod
    {
        //<This must be set prior to using the methods in this class>
        internal static string rootLocation = "";
        internal static bool rootLocationSet = false;

        public static void DeclareRootLocation(string rootLocationPath)
        {
            rootLocation = rootLocationPath;
            rootLocationSet = true;
        }
        public static void RootLocationInvalidHandler()
        {
            throw new Exception("Paths file root location was not set");
        }
        //</>

        public static List<string> ReadFromFileToList(string fileName)
        {
            List<string> returnFileInfoList = new List<string>();

            if (rootLocationSet == true)
            {
                try
                {
                    //Read root path file
                    var fileLocations = File.ReadAllLines(rootLocation + @"\Paths.txt");

                    //Check path file for specified name of txt file
                    //E.G "UserCredits.txt"
                    string returnFileLocation = fileLocations.First(p => p.Contains(fileName)).ToString();
                    foreach (var item in File.ReadAllLines(returnFileLocation))
                    {
                        returnFileInfoList.Add(item);
                    }

                }
                catch (Exception)
                {
                }
            }
            else
            {
                RootLocationInvalidHandler();
            }

            return returnFileInfoList;
        }

        public static List<string> ReadFromFilePathToList(string filePath)
        {
            List<string> returnFileInfoList = new List<string>();

            if (rootLocationSet == true)
            {
                try
                {
                    //Check path file for specified name of txt file
                    //E.G "UserCredits.txt"
                    foreach (var item in File.ReadAllLines(filePath))
                    {
                        returnFileInfoList.Add(item);
                    }

                }
                catch (Exception)
                {
                }
            }
            else
            {
                RootLocationInvalidHandler();
            }


            return returnFileInfoList;
        }


        public static void WriteListToFile(List<string> listToWrite, bool overwriteExistingContent, string filePath)
        {
            if (rootLocationSet == true)
            {
                try
                {
                    //Overwrite existing contents if true
                    if (overwriteExistingContent == true)
                    {
                        File.WriteAllText(filePath, "");
                    }

                    //Write items from list
                    foreach (var item in listToWrite)
                    {
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath, true))
                        {
                            file.WriteLine(item);
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }
            else
            {
                RootLocationInvalidHandler();
            }


        }

        public static void WriteStringToFile(string stringToWrite, bool overwriteExistingContent, string filePath)
        {
            if (rootLocationSet == true)
            {

                try
                {
                    //Overwrite existing contents if true
                    if (overwriteExistingContent == true)
                    {
                        File.WriteAllText(filePath, "");
                    }

                    //Write string
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath, true))
                    {
                        file.WriteLine(stringToWrite);
                    }

                }
                catch (Exception)
                {
                }
            }
            else
            {
                RootLocationInvalidHandler();
            }

        }


        public static string GetFileLocation(string fileName)
        {
            string returnFileLocation = "";

            if (rootLocationSet == true)
            {
                try
                {
                    //Read root path file
                    var fileLocations = File.ReadAllLines(rootLocation + @"\Paths.txt");

                    //Check path file for specified name of txt file
                    //E.G "UserCredits.txt"
                    returnFileLocation = fileLocations.First(p => p.Contains(fileName)).ToString();
                }
                catch (Exception)
                {
                }
            }
            else
            {
                RootLocationInvalidHandler();
            }

            return returnFileLocation;
        }
    }
}
