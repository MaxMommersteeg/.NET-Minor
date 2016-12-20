using System;
using System.ComponentModel.DataAnnotations;
using Minor.Dag21.CAS.BackEnd.Entities.Entities;

public class CursusInstantie
{
    [Key]
    public int CursusInstantieID { get; set; }
    [Required]
    public Cursus Cursus { get; set; }
    [Required]
    public DateTime Startdatum { get; set; }
}