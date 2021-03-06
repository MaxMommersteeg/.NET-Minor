// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Case2.MaRoWo.GarageAdministratie.Infrastructure.Agents.OnderhoudBeheerService.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    public partial class CreateOnderhoudCommand
    {
        /// <summary>
        /// Initializes a new instance of the CreateOnderhoudCommand class.
        /// </summary>
        public CreateOnderhoudCommand() { }

        /// <summary>
        /// Initializes a new instance of the CreateOnderhoudCommand class.
        /// </summary>
        public CreateOnderhoudCommand(string kenteken, int kilometerstand, string onderhoudsBeschrijving, bool hasApk, DateTime opdrachtAangemaakt, string bestuurder, string telefoonNrBestuurder)
        {
            Kenteken = kenteken;
            Kilometerstand = kilometerstand;
            OnderhoudsBeschrijving = onderhoudsBeschrijving;
            HasApk = hasApk;
            OpdrachtAangemaakt = opdrachtAangemaakt;
            Bestuurder = bestuurder;
            TelefoonNrBestuurder = telefoonNrBestuurder;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "kenteken")]
        public string Kenteken { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "kilometerstand")]
        public int Kilometerstand { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "onderhoudsBeschrijving")]
        public string OnderhoudsBeschrijving { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "hasApk")]
        public bool HasApk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "opdrachtAangemaakt")]
        public DateTime OpdrachtAangemaakt { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "bestuurder")]
        public string Bestuurder { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "telefoonNrBestuurder")]
        public string TelefoonNrBestuurder { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (Kenteken == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Kenteken");
            }
            if (OnderhoudsBeschrijving == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "OnderhoudsBeschrijving");
            }
            if (Bestuurder == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Bestuurder");
            }
            if (TelefoonNrBestuurder == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "TelefoonNrBestuurder");
            }
            if (this.Kenteken != null)
            {
                if (this.Kenteken.Length > 50)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "Kenteken", 50);
                }
                if (this.Kenteken.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "Kenteken", 0);
                }
            }
            if (this.Kilometerstand > 2147483647)
            {
                throw new ValidationException(ValidationRules.InclusiveMaximum, "Kilometerstand", 2147483647);
            }
            if (this.Kilometerstand < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "Kilometerstand", 0);
            }
            if (this.Bestuurder != null)
            {
                if (this.Bestuurder.Length > 300)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "Bestuurder", 300);
                }
                if (this.Bestuurder.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "Bestuurder", 0);
                }
            }
            if (this.TelefoonNrBestuurder != null)
            {
                if (this.TelefoonNrBestuurder.Length > 150)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "TelefoonNrBestuurder", 150);
                }
                if (this.TelefoonNrBestuurder.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "TelefoonNrBestuurder", 0);
                }
            }
        }
    }
}
