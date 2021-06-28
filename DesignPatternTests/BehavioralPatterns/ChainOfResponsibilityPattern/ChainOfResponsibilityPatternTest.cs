using Xunit;
using DesignPatterns.BehavioralPatterns.ChainOfResponsibilityPattern;
using System;

namespace DesignPatternTests.BehavioralPatterns.ChainOfResponsibilityPattern
{
    [Trait("Pattern", "Behavioral")]
    public class ChainOfResponsibilityPatternTest
    {
        [Fact]
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
        public void Reimburse_Failure_Test()
        {
            // arrange
            var teamLeader = new TeamLeader();
            var manager = new Manager();
            var cfo = new ChiefFinancialOfficer();
            teamLeader.SetNextReimburser(manager);
            manager.SetNextReimburser(cfo);
            cfo.SetNextReimburser(null);

            // act
            teamLeader.Reimburse(1001);

            // assert
            Assert.False(teamLeader.HasReimbursed);
            Assert.False(manager.HasReimbursed);
            Assert.False(cfo.HasReimbursed);
        }

    }

}
