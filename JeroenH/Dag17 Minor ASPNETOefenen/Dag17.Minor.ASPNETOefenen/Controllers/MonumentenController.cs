using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Dag17.Minor.ASPNETOefenen;
using System.Linq;

public class MonumentenController : Controller
{
    private IAgent _MonumentAgent;

    public MonumentenController(IAgent monumentAgent)
    {
        _MonumentAgent = monumentAgent;
    }

    public IActionResult Index()
    {
        return View((List<Monument>)_MonumentAgent.FindAll());
    }

    [HttpGet]
    public IActionResult Toevoegen(Monument monument)
    {
        _MonumentAgent.Add(monument);
        return Index();
       // return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Verwijderen(Monument monument)
    {
        _MonumentAgent.Remove(monument);
        return Index();
        //return RedirectToAction("Index", "MonumentenController");
    }

    public IActionResult Toevoegen()
    {
        return View("Toevoegen");
    }
}