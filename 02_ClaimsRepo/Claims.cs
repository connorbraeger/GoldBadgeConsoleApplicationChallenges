using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimsRepo
{
    public enum TypeOfClaim
    {
        Car,
        Home,
        Theft
    }
    public class Claims
    {
        public static int NextClaim = 1;
        public static int DescriptionLength = 10;
        public int ClaimNumber { get; set; }
        public TypeOfClaim ClaimType { get; set; }
        public string Description
        { get; set; }
        public decimal ClaimAmout { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }
        public Claims()
        {
            ClaimNumber = Claims.NextClaim;
            Claims.NextClaim++;
            DateOfIncident = DateTime.Now;
            DateOfClaim = DateTime.Now;

            IsValid = (DateOfClaim.Subtract(DateOfIncident).TotalDays <= 30);
            Description = "Information needed.";

        }
        public Claims(TypeOfClaim claimType, string description, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimNumber = Claims.NextClaim;
            Claims.NextClaim++;
            ClaimType = claimType;
            Description = description;
            if (description.Length > Claims.DescriptionLength)
            {
                Claims.DescriptionLength = description.Length;
            }
            ClaimAmout = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = (DateOfClaim.Subtract(DateOfIncident).TotalDays <= 30);

        }
    }
}
