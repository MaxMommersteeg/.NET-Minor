using System;
using TechTalk.SpecFlow;

namespace TestGherkin
{
    [Binding]
    public class VaststellenGeschiktheidBestuurderSteps
    {
        [Given(@"Is minimaal (.*) jaar oud")]
        public void GivenIsMinimaalJaarOud(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"vandaag is het (.*)(.*)")]
        public void GivenVandaagIsHet(string p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"de huurperiode begint op (.*)(.*)")]
        public void GivenDeHuurperiodeBegintOp(string p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"de huurperiode eindigd op (.*)(.*)")]
        public void GivenDeHuurperiodeEindigdOp(string p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"bestuurder met (.*) en komt uit (.*) en heeft een (.*)")]
        public void WhenBestuurderMetEnKomtUitEnHeeftEen(string p0, string p1, string p2)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"bestuurder is (.*) met (.*) welke geldig is tot (.*)")]
        public void WhenBestuurderIsMetWelkeGeldigIsTot(string p0, string p1, string p2)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"is het rijbewijs (.*)")]
        public void ThenIsHetRijbewijs(string p0, Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"bestuurder is (.*)")]
        public void ThenBestuurderIs(string p0, Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
