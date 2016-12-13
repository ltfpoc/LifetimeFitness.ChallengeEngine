namespace LifetimeFitness.ChallengeEngine.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Newtonsoft.Json;

    public class Measurement
    {
        public int MeasurementId { get; set; }

        public int UserId { get; set; }

        public int? Height { get; set; }

        public int? weight { get; set; }

        public decimal? bodyfatpercent { get; set; }

        public DateTime WeighInDate { get; set; }

        public bool IsApproved { get; set; }

        public bool IsQuestionable { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
