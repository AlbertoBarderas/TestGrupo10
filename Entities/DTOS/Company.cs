using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOS
{
    /// <summary>
    /// Clase que recoge las empresas 
    /// </summary>
    public class Company
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("companyName")]
        public string CompanyName { get; set; }

        [JsonProperty("creationDate")]
        public DateTime CreationDate { get; set; }


        //Habría que poner el código de la provincia y no el nombre usando una tabla de provincias, enumeración, hastable o similar.
        [JsonProperty("provinceName")]
        public string ProvinceName { get; set; }


    }
}
