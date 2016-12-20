using System;
using System.ComponentModel.DataAnnotations;
using Minor.Dag21.CAS.BackEnd.Entities.Entities;
using System.Collections.Generic;

public class Cursist
{
    [Key]
    public int CursistId { get; set; }
    [Required]
    public int CursusInstantieID { get; set; }
    [Required]
    public string Voornaam { get; set; }
    [Required]
    public string Achternaam { get; set; }

}