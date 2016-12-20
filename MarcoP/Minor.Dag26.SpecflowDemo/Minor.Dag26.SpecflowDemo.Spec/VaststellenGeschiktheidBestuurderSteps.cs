using System;
using TechTalk.SpecFlow;

namespace Minor.Dag26.SpecflowDemo.Spec
{
    [Binding]
    public class VaststellenGeschiktheidBestuurderSteps
    {
        [Given(@"de aanvang van de huurperiode is (.*) mei (.*)")]
        public void GivenDeAanvangVanDeHuurperiodeIsMei(int p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"de risicolanden zijn Malta en Cyprus")]
        public void GivenDeRisicolandenZijnMaltaEnCyprus()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"(.*) is het nummer van een geldig rijbewijs")]
        public void GivenIsHetNummerVanEenGeldigRijbewijs(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"(.*) is het nummer van een ongeldig rijbewijs")]
        public void GivenIsHetNummerVanEenOngeldigRijbewijs(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"de eerste dag van de huurperiode is (.*) mei (.*)")]
        public void GivenDeEersteDagVanDeHuurperiodeIsMei(int p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"de laatste dag van de huurperiode is (.*) mei (.*)")]
        public void GivenDeLaatsteDagVanDeHuurperiodeIsMei(int p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"(.*) is een (.*) rijbewijs")]
        public void GivenIsEenRijbewijs(int p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"een bestuurder met (.*)(.*) uit Nederland met (.*) wil een auto huren")]
        public void WhenEenBestuurderMetUitNederlandMetWilEenAutoHuren(string p0, int p1, int p2)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"het rijbewijs met (.*), (.*) mei (.*), (.*) mei (.*), B en (.*) op geldigheid wordt gecontroleerd,")]
        public void WhenHetRijbewijsMetMeiMeiBEnOpGeldigheidWordtGecontroleerd(int p0, int p1, int p2, int p3, int p4, string p5)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"dan is de bestuurder geschikt")]
        public void ThenDanIsDeBestuurderGeschikt()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"is het rijbewijs geldig")]
        public void ThenIsHetRijbewijsGeldig()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
