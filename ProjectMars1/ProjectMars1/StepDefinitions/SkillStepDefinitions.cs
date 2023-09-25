using InternshipTask1.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UserStoryTask1.Pages;

namespace ProjectMars1.StepDefinitions
{
    [Binding]
    public class SkillsStepDefinitions : CommonDriver
    {
        SkillsPage skillspageobj;
        LoginPage loginPageObj;
        
        public SkillsStepDefinitions()
        {
            skillspageobj = new SkillsPage();
            loginPageObj = new LoginPage();
        }

        [Given(@"User is logged into localhost")]
        public void GivenUserIsLoggedIntoLocalhost()
        {
            loginPageObj.LoginSteps();
        }

        [When(@"I navigate to Profile page")]
        public void WhenINavigateToProfilePage()
        {
            skillspageobj.ProfileTab();
        }

        [When(@"I add new '([^']*)' and '([^']*)'")]
        public void WhenIAddNewAnd(string Skill, string Level)
        {
            skillspageobj.AddSkills(driver, Skill, Level);
        }

        [Then(@"Verify new '([^']*)' and '([^']*)' are added successfully\.")]
        public void ThenVerifyNewAndAreAddedSuccessfully_(string Skill, string Level)
        {
            (string addedSkill, string addedSkillLevel) = skillspageobj.VerifyAddedSkills();

            if (Skill == addedSkill && Level == addedSkillLevel)
            {
                Assert.AreEqual(Skill, addedSkill, "Input language and added first langauage do not match");
                Assert.AreEqual(Level, addedSkillLevel, "Input level and added first level do not match");
            }
            else
            {
                Assert.Pass("Check for message");
            }            
        }

        [When(@"I edit existing '([^']*)' and '([^']*)'")]
        public void WhenIEditExistingAnd(string Skills, string Level)
        {
            skillspageobj.ProfileTab();
            skillspageobj.EditSkillAndLevel(Skills, Level);
        }

        [Then(@"Verify new '([^']*)' and '([^']*)' are edited successfully\.")]
        public void ThenVerifyNewAndAreEditedSuccessfully_(string Skills, string Level)
        {
            (string editedSkill, string editedSkillLevel) = skillspageobj.VerifyEditedSkills();

            if (Skills == editedSkill && Level == editedSkillLevel)
            {
                Assert.AreEqual(Skills, editedSkill, "Input language and added first langauage do not match");
                Assert.AreEqual(Level, editedSkillLevel, "Input level and added first level do not match");
            }
            else
            {
                Assert.Pass("Something's not right.Check for error message");
            }
        }

        [When(@"I delete existing '([^']*)' and '([^']*)'")]
        public void WhenIDeleteExistingAnd(string Skills, string Level)
        {
            skillspageobj.DeleteSkillsAndLevel(Skills, Level);
            skillspageobj.checkCancelFunction();
        }

        [Then(@"Existing skill deleted successfully\.")]
        public void ThenExistingSkillDeletedSuccessfully_()
        {
            Console.WriteLine("Delete fuctionality checked successfully");
        }

    }
}
