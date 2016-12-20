using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Dag17.Minor.ASPNETOefenen.Testen
{
    internal class MonumentenMockController
    {
        public MockMonumentAgent monumentAgent;

        public MonumentenController _MonumentenController { get; private set; }

        public MonumentenMockController(IAgent monumentAgent)
        {
            this.monumentAgent = (MockMonumentAgent)monumentAgent;
            _MonumentenController = new MonumentenController(monumentAgent);
        }

        public void setList(List<Monument> monumentList)
        {
            monumentAgent.setList(monumentList);
        }

        public IActionResult Index()
        {
            return _MonumentenController.Index();
        }

        public IActionResult Toevoegen(Monument monument)
        {
            return _MonumentenController.Toevoegen(monument);
        }

        public IActionResult Verwijderen(Monument monument)
        {
            return _MonumentenController.Verwijderen(monument);
        }

        public IActionResult Toevoegen()
        {
            return _MonumentenController.Toevoegen();
        }
    }
}