using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DuckBot_ClassLibrary
{
    public class HelperMethod
    {
        //<This must be set prior to using the methods in this class>
        public static string updateTimeContainer = "--Last Update Time--";
        internal static bool updateTimeContainerNameSet = false;

        public static void DeclareUpdateTimeContainer(string updateTimeContainerName)
        {
            updateTimeContainer = updateTimeContainerName;
            updateTimeContainerNameSet = true;
        }
        public static void UpdateTimeContainerNameNotSetHandler()
        {
            throw new Exception("Update time container name was not set");
        }
        //</>

        public static DateTime GetLastUpdateTime(List<string> inputStorageList)
        {
            DateTime interestLastUpdateDate = DateTime.Now;

            if (updateTimeContainerNameSet == true)
            {
                //Gets last update time from storage list
                //Get last update date from file, get current time
                string interestLastUpdateTime = "";
                try
                {
                    //Get line containg last update time
                    interestLastUpdateTime = inputStorageList.First(p => p.Contains(updateTimeContainer));

                    //Extract last update date 
                    interestLastUpdateDate = DateTime.Parse(interestLastUpdateTime.Substring(updateTimeContainer.Length + 5, interestLastUpdateTime.Length - updateTimeContainer.Length - 5));
                }
                catch (Exception)
                {
                }
            }
            else
            {
                UpdateTimeContainerNameNotSetHandler();
            }


            return interestLastUpdateDate;
        }
    }
}
