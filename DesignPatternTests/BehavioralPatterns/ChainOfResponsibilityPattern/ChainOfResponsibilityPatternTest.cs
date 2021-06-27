using Xunit;
using DesignPatterns.BehavioralPatterns.ChainOfResponsibilityPattern;
using System;

namespace DesignPatternTests.BehavioralPatterns.ChainOfResponsibilityPattern
{
    public class ChainOfResponsibilityPatternTest
    {
        [Fact]
        [Trait("Pattern", "Behavioral")]
        public void TeamLeader_Reimburse_Success_Test()
        {
            // arrange
            var teamLeader = new TeamLeader();
            var manager = new Manager();
            var cfo = new ChiefFinancialOfficer();
            teamLeader.SetNextReimburser(manager);
            manager.SetNextReimburser(cfo);

            // act
            teamLeader.Reimburse(100);

            // assert
            Assert.True(teamLeader.HasReimbursed);
            Assert.False(manager.HasReimbursed);
            Assert.False(cfo.HasReimbursed);
        }

        [Fact]
        [Trait("Pattern", "Behavioral")]
        public void Manager_Reimburse_Success_Test()
        {
            // arrange
            var teamLeader = new TeamLeader();
            var manager = new Manager();
            var cfo = new ChiefFinancialOfficer();
            teamLeader.SetNextReimburser(manager);
            manager.SetNextReimburser(cfo);

            // act
            teamLeader.Reimburse(500);

            // assert
            Assert.False(teamLeader.HasReimbursed);
            Assert.True(manager.HasReimbursed);
            Assert.False(cfo.HasReimbursed);
        }

        [Fact]
        [Trait("Pattern", "Behavioral")]
        public void CFO_Reimburse_Success_Test()
        {
            // arrange
            var teamLeader = new TeamLeader();
            var manager = new Manager();
            var cfo = new ChiefFinancialOfficer();
            teamLeader.SetNextReimburser(manager);
            manager.SetNextReimburser(cfo);

            // act
            teamLeader.Reimburse(1000);

            // assert
            Assert.False(teamLeader.HasReimbursed);
            Assert.False(manager.HasReimbursed);
            Assert.True(cfo.HasReimbursed);
        }

        [Fact]
        [Trait("Pattern", "Behavioral")]
        public void Reimburse_Failure_Test()
        {
            // arrange
            var teamLeader = new TeamLeader();
            var manager = new Manager();
            var cfo = new ChiefFinancialOfficer();
            teamLeader.SetNextReimburser(manager);
            manager.SetNextReimburser(cfo);

            // act
            teamLeader.Reimburse(1001);

            // assert
            Assert.False(teamLeader.HasReimbursed);
            Assert.False(manager.HasReimbursed);
            Assert.False(cfo.HasReimbursed);
        }
    }

}
