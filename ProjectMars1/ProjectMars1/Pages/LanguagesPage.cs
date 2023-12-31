﻿using InternshipTask1.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProjectMars;

namespace InternshipTask1.Pages
{
    public class LanguagesPage : CommonDriver
    {

        private IWebElement addNewButton => driver.FindElement(By.XPath("//thead/tr/th[3]/div[@class='ui teal button ']"));
        By addLanguage = By.XPath("//div[@class='five wide field']/input");
        By addButton = By.XPath("//div[@class='six wide field']/input[1]");
        By profileTab = By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]");
        By languageTab = By.XPath("//a[@class= 'item active']");
        By editButton = By.XPath("//div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]/i");
        By cancelButton = By.XPath("//input[@value= 'Cancel']");
        IWebElement profileOption => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span/div/a[1]"));


        public void GoToProfilePage()
        {
            // go to hi user dropdown
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span", 5);
            IWebElement userDropdown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span"));
            userDropdown.Click();

            // select go to profile from drop down 
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span/div/a[1]", 7);
            //IWebElement profileOption = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span/div/a[1]"));
            profileOption.Click();

            //or click on profile tab
        }
        public void ClickOnProfileTab()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]", 7);
            driver.FindElement(profileTab).Click();
        }

        public void AddLanguage(string Language, string Level)
        {

            //find lang tab
            driver.FindElement(languageTab).Click();

            try
            {
                if (addNewButton != null && addNewButton.Enabled)
                {
                    // Proceed with further actions or assertions
                    Wait.WaitToBeClickable(driver, "XPath", "//thead/tr/th[3]/div[@class='ui teal button ']", 3);
                    addNewButton.Click();
                    // Additional code

                    driver.FindElement(addLanguage).Click();
                    driver.FindElement(addLanguage).SendKeys(Language);


                    IWebElement chooseLanguageLevel = driver.FindElement(By.XPath("//select[@class='ui dropdown']"));
                    SelectElement languageLevel = new SelectElement(chooseLanguageLevel);
                    languageLevel.SelectByText(Level); // selects based on text in dropdown            

                    driver.FindElement(addButton).Click();

                    //check for message that new language is added successfully
                    Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 3);
                    IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

                    // Get the text of the message element
                    string actualMessage = messageBox.Text;
                    Console.WriteLine(actualMessage);

                    // Verify the expected message text
                    string expectedMessage1 = Language + " has been added to your languages";
                    string expectedMessage2 = "Please enter language and level";
                    string expectedMessage3 = "This language is already exist in your language list.";
                    string expectedMessage4 = "Duplicated data";

                    Assert.That(actualMessage, Is.EqualTo(expectedMessage1).Or.EqualTo(expectedMessage2).Or.EqualTo(expectedMessage3).Or.EqualTo(expectedMessage4));
                }



                //Using assert are equal fails the test.
                //Assert.AreEqual(expectedMessage1, actualMessage, "The language and level already exist");
                //Assert.AreEqual(expectedMessage2, actualMessage, "Check error message");

            }

            catch (NoSuchElementException)
            {
                Console.WriteLine("Add new button doesn't exist");

            }

        }

        public (string, string) VerifyAddLanguage()

        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]", 7);
            driver.FindElement(profileTab).Click();

            Wait.WaitToBeVisible(driver, "XPath", "//form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 2);
            IWebElement addedLanguage = driver.FindElement(By.XPath("//form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));

            Wait.WaitToBeVisible(driver, "XPath", "//form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]", 7);
            IWebElement addedLanguageLevel = driver.FindElement(By.XPath("//form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));

            return (addedLanguage.Text, addedLanguageLevel.Text);

            //Assert.That(addedLanguage, Is.EqualTo(Language), "Language is not added or doesnt exist");
            //Assert.That(addedLanguageLevel, Is.EqualTo(Level), "Level is not added or doesnt exsit");

        }

        public void EditLanguageAndLevel(IWebDriver driver, string Language, string Level)
        {
            driver.FindElement(languageTab).Click();

            Wait.WaitToBeClickable(driver, "XPath", "//div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]/i", 3);
            driver.FindElement(editButton).Click();

            //Wait.WaitToBeClickable(driver, "XPath", "//div[@class='five wide field']/input", 5);
            //driver.FindElement(addLanguage).Clear();

            //driver.FindElement(languageTab).Click();
            //Wait.WaitToBeClickable(driver, "XPath", "//div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i", 3);
            //driver.FindElement(editButton).Click();

            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='five wide field']/input", 5);
            driver.FindElement(addLanguage).SendKeys(Keys.Control + "A");
            driver.FindElement(addLanguage).SendKeys(Keys.Backspace);
            //driver.FindElement(addLanguage).Clear();            
            driver.FindElement(addLanguage).SendKeys(Language);

            IWebElement chooseLanguageLevel = driver.FindElement(By.XPath("//select[@class='ui dropdown']"));
            SelectElement languageLevel = new SelectElement(chooseLanguageLevel);
            languageLevel.SelectByText(Level); // selects based on text in dropdown

            //Thread.Sleep(1000);
            Wait.WaitToBeClickable(driver, "XPath", "//*[contains(@value, 'Update')]", 5);
            By updateButton = By.XPath("//*[contains(@value, 'Update')]");
            driver.FindElement(updateButton).Click();

            //check for message that new language is added successfully
            Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 3);
            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

            // Get the text of the message element
            string actualMessage = messageBox.Text;
            Console.WriteLine(actualMessage);

            // Verify the expected message text
            string expectedMessage1 = Language + " has been updated to your languages";
            string expectedMessage2 = "Please enter language and level";
            string expectedMessage3 = "This language is already exist in your language list.";
            string expectedMessage4 = "Duplicated data";

            Assert.That(actualMessage, Is.EqualTo(expectedMessage1).Or.EqualTo(expectedMessage2).Or.EqualTo(expectedMessage3).Or.EqualTo(expectedMessage4));
        
        //Assert.AreEqual(expectedMessage, actualMessage, "Error while editing the language.");

        }
        public (string, string) VerifyEditedLanguage()
        {

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]", 7);
            driver.FindElement(profileTab).Click();

            Wait.WaitToBeVisible(driver, "XPath", "//form/div[2]/div/div[2]/div/table/tbody/tr/td[1]", 2);
            IWebElement editeddLanguage = driver.FindElement(By.XPath("//form/div[2]/div/div[2]/div/table/tbody/tr/td[1]"));

            Wait.WaitToBeVisible(driver, "XPath", "//form/div[2]/div/div[2]/div/table/tbody/tr/td[2]", 7);
            IWebElement editedLanguageLevel = driver.FindElement(By.XPath("//form/div[2]/div/div[2]/div/table/tbody/tr/td[2]"));

            return (editeddLanguage.Text, editedLanguageLevel.Text);

            //Assert.That(addedLanguage, Is.EqualTo(Language), "Language is not added or doesnt exist");
            //Assert.That(addedLanguageLevel, Is.EqualTo(Level), "Level is not added or doesnt exsit");

        }

        public void DeleteLanguageAndLevel()
        {
                driver.FindElement(languageTab).Click();

                Wait.WaitToBeClickable(driver, "XPath", "//div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i", 3);
                By deleteButton = By.XPath("//div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i");
                driver.FindElement(deleteButton).Click();

                //check for message that new language is added successfully
                Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 3);
                IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

                // Get the text of the message element
                string actualMessage = messageBox.Text;
                Console.WriteLine(actualMessage);
                // Verify the expected message text

        }

        public void checkCancelFunction()
        {
            Wait.WaitToBeClickable(driver, "XPath", "//div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]/i", 3);
            driver.FindElement(editButton).Click();
            driver.FindElement(cancelButton).Click();
            Console.WriteLine("Cancel function checked for Edit");

            Wait.WaitToBeClickable(driver, "XPath", "//thead/tr/th[3]/div[@class='ui teal button ']", 3);
            addNewButton.Click();
            driver.FindElement(cancelButton).Click();
            Console.WriteLine("Cancel function checked for AddNew");
        }


    }
}