using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Minor.Dag26.SpecflowDemo.Spec
{
    [Binding]
    public class CalculatorSteps
    {
        private Calculator _calculator = new Calculator();

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int invoer)
        {
            _calculator.Enter(invoer);
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            _calculator.AddUp();
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int result)
        {
            Assert.AreEqual(result, _calculator.Result);
        }
    }
}
