using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOS
{
    /// <summary>
    /// Clase que  recoge las lecturas que se hacen del BOE
    /// </summary>
    public class BOEReading
    {
        [JsonProperty("readDate")]
        public DateTime ReadDate { get; set; }
    }
}
